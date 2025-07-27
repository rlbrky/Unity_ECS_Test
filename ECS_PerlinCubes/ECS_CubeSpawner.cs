using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

[UpdateInGroup(typeof(InitializationSystemGroup))]
public partial struct ECS_CubeSpawner : ISystem
{
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<ECS_CubeSpawnerData>();
    }

    public void OnUpdate(ref SystemState state)
    {
        var ecb = new EntityCommandBuffer(Allocator.Temp);
        
        // Process all spawners that haven't spawned yet.
        foreach (var (spawnerData, spawnerEntity) in SystemAPI.Query<RefRW<ECS_CubeSpawnerData>>().WithEntityAccess())
        {
            if(spawnerData.ValueRO.hasSpawned) continue;
            
            // Spawn grid of cubes
            for (int i = 0; i < spawnerData.ValueRO.rows; i++)
            {
                for (int j = 0; j < spawnerData.ValueRO.cols; j++)
                {
                    var cubeEntity = ecb.Instantiate(spawnerData.ValueRO.cubePrefab);
                    
                    // Calculate position using Perlin noise
                    float height = Mathf.PerlinNoise(i * spawnerData.ValueRO.rowMult, j * spawnerData.ValueRO.colMult) * spawnerData.ValueRO.heightMult;
                    var position = new float3(i, height, j);
                    
                    ecb.SetComponent(cubeEntity, LocalTransform.FromPosition(position));

                    // UNOPTIMIZED PHYSICS FOR ENTITY SYSTEM
                    /*var shadowGO = new GameObject($"CubeShadow_{i}_{j}");
                    shadowGO.transform.position = position;
                    shadowGO.AddComponent<BoxCollider>();*/
                }
            }
            
            spawnerData.ValueRW.hasSpawned = true;
        }
        
        ecb.Playback(state.EntityManager);
        ecb.Dispose();
    }
}

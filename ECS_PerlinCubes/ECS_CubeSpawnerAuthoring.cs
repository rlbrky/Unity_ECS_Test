using UnityEngine;
using Unity.Entities;

public class ECS_CubeSpawnerAuthoring : MonoBehaviour
{
    public GameObject cubePrefab;
    
    [Header("Grid Settings")]
    public int rows;
    public int cols;

    [Header("Landscape Settings")] 
    public float rowMult = 0.21f;
    public float colMult = 0.21f;
    public float heightMult = 1f;

    private class Baker : Baker<ECS_CubeSpawnerAuthoring>
    {
        public override void Bake(ECS_CubeSpawnerAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.None);
            
            AddComponent(entity, new ECS_CubeSpawnerData
            {
                cubePrefab = GetEntity(authoring.cubePrefab, TransformUsageFlags.Dynamic),
                rows = authoring.rows,
                cols = authoring.cols,
                rowMult = authoring.rowMult,
                colMult = authoring.colMult,
                heightMult = authoring.heightMult,
                hasSpawned = false
            });
        }
    }
}

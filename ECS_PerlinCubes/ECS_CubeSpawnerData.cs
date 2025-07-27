using Unity.Entities;

public struct ECS_CubeSpawnerData : IComponentData
{
    public Entity cubePrefab;
    public int rows;
    public int cols;
    public float rowMult;
    public float colMult;
    public float heightMult;
    public bool hasSpawned; //We only need one spawner.
}

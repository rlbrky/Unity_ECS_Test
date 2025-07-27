using UnityEngine;

public class SpawnCubes : MonoBehaviour
{
    public GameObject cube;
    public int rows;
    public int cols;

    [Header("Landscape")] 
    public float rowMult = 0.21f;
    public float colMult = 0.21f;
    public float heightMult = 1f;
    
    void Start()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                GameObject instance = Instantiate(cube);
                Vector3 pos = new Vector3(i, Mathf.PerlinNoise(i * rowMult, j * colMult) * heightMult, j); //Plane calculation
                
                instance.transform.position = pos;
            }
        }
    }
}

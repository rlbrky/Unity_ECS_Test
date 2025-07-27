using System;
using UnityEngine;

public class SpawnCar : MonoBehaviour
{
    public GameObject car;
    public Camera camera;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject carObj = Instantiate(car, new Vector3(10, 10, 10), Quaternion.identity);
            camera.GetComponent<SmoothFollow>().target = carObj.transform; 
        }
    }
}

using System;
using UnityEngine;

public class FreeCameraMovement : MonoBehaviour
{
    public float speed = 10f;
    public float rotationSpeed = 100f;

    private void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);
    }
}

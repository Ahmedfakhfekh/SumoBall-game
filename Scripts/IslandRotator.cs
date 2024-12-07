using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandRotator : MonoBehaviour
{
    float rotationSpeed = 10f;
    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}

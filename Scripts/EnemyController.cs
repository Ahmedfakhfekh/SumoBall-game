using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    float speed = 5f;
    Rigidbody rb;
    GameObject player;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Sphere");
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce((player.transform.position - transform.position).normalized * speed);
    }
}

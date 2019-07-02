using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    private float h;
    private float v;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        h = Input.GetAxis("Horizontal") * speed;
        v = Input.GetAxis("Vertical") * speed;
        Vector3 vel = rb.velocity;
        vel.x = h;
        vel.z = v;
        transform.rotation = Quaternion.Euler(0f, Mathf.Atan2(-v, h) * Mathf.Rad2Deg, 0f);
        rb.velocity = vel;
    }
}

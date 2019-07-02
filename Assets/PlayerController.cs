using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float startAngle;
    [SerializeField] string horizontal;
    [SerializeField] string vertical;
    private float h;
    private float v;
    private Rigidbody rb;
    private float rotY;
    private float rotY_prev;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rotY_prev = startAngle;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        h = Input.GetAxis(horizontal) * speed;
        v = Input.GetAxis(vertical) * speed;
        Vector3 vel = rb.velocity;
        vel.x = h;
        vel.z = v;
        rotY = Mathf.Atan2(-v, h) * Mathf.Rad2Deg;
        rotY = h+v == 0 && rotY_prev != 0 ? rotY_prev : rotY;
        transform.rotation = Quaternion.Euler(0f, rotY, 0f);
        rotY_prev = rotY;
        rb.velocity = vel;
    }
}

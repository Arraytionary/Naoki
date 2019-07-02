using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WonderWall : MonoBehaviour
{
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Physics.IgnoreLayerCollision(8, 9);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ora : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other) {
        other.rigidbody.velocity *= -2;
        // print(other.collider.tag);
        // print("blep");
    }
}

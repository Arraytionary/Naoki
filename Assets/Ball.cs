using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rb;
    private float neutrialSpeed = 20f;
    private Renderer rend;
    private bool isAcc;
    

    void Start()
    {
        rend = GetComponent<Renderer>();
        Physics.IgnoreLayerCollision(8, 9);
    }

    private void Update()
    {
        ChangeColorByTag();
        ChangeTagByVelocity();
    }

    private void ChangeTagByVelocity()
    {
        float magnitude = rb.velocity.magnitude;

        

        if (magnitude <= neutrialSpeed && transform.gameObject.tag != "Ball_Neu" && isAcc)
        {
            isAcc = false;
            transform.gameObject.tag = "Ball_Neu";
        }

        if (magnitude > neutrialSpeed){
            isAcc = true;
        }
    }

    private void ChangeColorByTag()
    {
        if (transform.gameObject.tag == "Ball_1")
        {
            rend.material.color = Color.red;
        }
        else if (transform.gameObject.tag == "Ball_2")
        {
            rend.material.color = Color.blue;
        }
        else
        {
            rend.material.color = Color.white;
        }

    }
}

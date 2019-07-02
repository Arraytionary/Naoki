using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    private GameObject Ball; //Turn to private later
    public GameObject Hand;
    public GameObject HandRange;

    public string throwKey;
    //public string dropKey;

    public string ballTag;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    [System.Obsolete]
    void FixedUpdate()
    {
        // If hand empty, re-activeate the HandRange
        if (HandIsEmpty() && !HandRange.active)
        {
            ActiveHandRange();
        }
        else if (!HandIsEmpty())
        {
            Ball.transform.rotation = Hand.transform.rotation;
            Ball.transform.position = Hand.transform.position;
            if (Input.GetAxis(throwKey) >= 1)
            {
                Throw();
            }

            //if (Input.GetAxis(dropKey) >= 1)
            //{
            //    Drop();
            //}
        }
    }

    public bool HandIsEmpty()
    {
        return Ball == null;
    }

    public void Carry(GameObject ball)
    {
        Ball = ball;
        Ball.tag = ballTag;
        Ball.GetComponent<Rigidbody>().useGravity = false;
    }

    private void ActiveHandRange()
    {
        HandRange.SetActive(true);
    }

    private void Drop()
    {


        Ball.GetComponent<Rigidbody>().useGravity = true;
        Ball = null;

    }

    private void Throw()
    {
        Ball.tag = ballTag;
        Rigidbody ball_rb = Ball.GetComponent<Rigidbody>();
        ball_rb.useGravity = true;
        ball_rb.AddRelativeForce(Vector3.right * 2000);
        Ball = null;
    }

}

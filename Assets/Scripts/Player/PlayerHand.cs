using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    private GameObject Ball; //Turn to private later
    private Rigidbody BallRB;
    public GameObject Hand;
    public GameObject HandRange;
    private AudioSource ThrowAudio; 

    public string throwKey;
    //public string dropKey;

    public string ballTag;

    // Start is called before the first frame update
    void Start()
    {
        ThrowAudio = transform.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    //[System.Obsolete]
    void FixedUpdate()
    {
        //Time.timeScale += (1f / 4f) * Time.unscaledDeltaTime;
        //Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
        // If hand empty, re-activeate the HandRange
        if (HandIsEmpty() && !HandRange.active)
        {
            ActiveHandRange();
        }
        else if (!HandIsEmpty())
        {
            Ball.transform.rotation = Hand.transform.rotation;
            Ball.transform.position = Hand.transform.position;
            Ball.tag = ballTag;

            BallRB.velocity = new Vector3(0f, 0f, 0f);
            if (Input.GetAxisRaw(throwKey) >= 1)
            {

                Throw();
                //g();
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
        BallRB = Ball.GetComponent<Rigidbody>();
        BallRB.useGravity = false;
        BallRB.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        BallRB.transform.eulerAngles = new Vector3(0f, 0f, 0f);
        BallRB.velocity = new Vector3(0f, 0f, 0f);
    }

    private void ActiveHandRange()
    {
        HandRange.SetActive(true);
        HandRange.GetComponent<BoxCollider>().enabled = true;
    }

    public void Throw()
    {
        ThrowAudio.Play();
        Ball.tag = ballTag;
        BallRB.useGravity = true;
        BallRB.constraints = RigidbodyConstraints.None;
        BallRB.velocity = new Vector3(0f, 0f, 0f);
        BallRB.AddRelativeForce(Vector3.right * 2000);
        Ball = null;
        BallRB = null;
    }

}

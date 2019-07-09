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
    [SerializeField] string enemyTag;
    [SerializeField] string enemyName;
    [SerializeField] string skip;
    [SerializeField] string dash;
    [SerializeField] string slow;
    [SerializeField] public float slowCooldown;
    [SerializeField] public float dashCooldown;
    [SerializeField] public float skipCooldown;
    [SerializeField] GameObject explodeEffect;
    public bool allowMovement;
    public Ability ability;
    public Dash doDash;
    private float h;
    private float v;
    public float nextSlow;
    public float nextSkip;
    public float nextDash;
    private Rigidbody rb;
    private float rotY;
    private float rotY_prev;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rotY_prev = startAngle;
        allowMovement = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (allowMovement)
        {
            h = Input.GetAxis(horizontal) * speed;
            v = Input.GetAxis(vertical) * speed;
            Vector3 vel = rb.velocity;
            vel.x = h;
            vel.z = v;
            rotY = Mathf.Atan2(-v, h) * Mathf.Rad2Deg;
            rotY = h + v == 0 && rotY_prev != 0 ? rotY_prev : rotY;
            transform.rotation = Quaternion.Euler(0f, rotY, 0f);
            rotY_prev = rotY;
            rb.velocity = vel;
            if (Input.GetAxis(skip) == 1 && Time.realtimeSinceStartup > nextSkip)
            {
                StartCoroutine(ability.TimeSkip());
                nextSkip = Time.realtimeSinceStartup + skipCooldown;
            }
            else if (Input.GetAxis(slow) == 1 && Time.realtimeSinceStartup > nextSlow)
            {
                StartCoroutine(ability.SlowTime());
                nextSlow = Time.fixedTime + slowCooldown;
            }
            else if (Input.GetAxis(dash) == 1 && Time.realtimeSinceStartup > nextDash)
            {
                doDash.SetupDash();
                nextDash = Time.realtimeSinceStartup + dashCooldown;
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject collidedGameObject = other.gameObject;
        if (collidedGameObject.tag == enemyTag)
        {
            Destroy();
        }
    }
    public void Destroy()
    {
        // Destroy(this.gameObject);
        // this.gameObject.SetActive(false);
        MeshRenderer m = this.GetComponent<MeshRenderer>();
        this.GetComponent<BoxCollider>().enabled = false;
        this.transform.Find("HandRange").gameObject.GetComponent<BoxCollider>().enabled = false;
        m.enabled = false;
        GM.Instance.stats[enemyName] += 1;
        Instantiate(explodeEffect, transform.position, Quaternion.identity);
        StopAllCoroutines();
        StartCoroutine(wait());
        
        
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("reach Here!!!!");
        GM.ReloadScene();
    }
}

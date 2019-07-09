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
    [SerializeField] float slowCooldown;
    [SerializeField] float dashCooldown;
    [SerializeField] float skipCooldown;
    [SerializeField] GameObject explodeEffect;
    public Ability ability;
    private float h;
    private float v;
    private float nextSlow;
    private float nextSkip;
    private float nextDash;
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
        if (Input.GetAxis(skip) == 1 && Time.fixedTime > nextSkip)
        {
            StartCoroutine(ability.TimeSkip());
            nextSkip = Time.fixedTime + skipCooldown;
        }
        else if (Input.GetAxis(slow) == 1 && Time.fixedTime > nextSlow)
        {
            StartCoroutine(ability.SlowTime());
            nextSlow = Time.fixedTime + slowCooldown;
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
        Destroy(this.gameObject);
        GM.Instance.stats[enemyName] += 1;
        Instantiate(explodeEffect, transform.position, Quaternion.identity);
        //StopAllCoroutines();
        StartCoroutine(wait());
        
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1f);
        GM.ReloadScene();
    }
}

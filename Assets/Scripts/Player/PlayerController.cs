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
    [SerializeField] GameObject explodeEffect;
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
        Destroy(this.transform.Find("HandRange").gameObject);
        // hand.SetActive(false);
        m.enabled = false;
        GM.Instance.stats[enemyName] += 1;
        Instantiate(explodeEffect, transform.position, Quaternion.identity);
        StopAllCoroutines();
        StartCoroutine(wait());
        
        
    }

    IEnumerator wait()
    {
        // Debug.Log("reach Here!!!!");
        yield return new WaitForSeconds(1f);
        Debug.Log("reach Here!!!!");
        GM.ReloadScene();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public GameObject player;
    public GameObject dashPar;
    public string dashKey;
    public float abilityDuration;
    public float abilityCooldown;


    //public float abilityCountdown;
    public float dashSpeed;
    private float dashCountdown;
    private float dashCooldown;
    private bool dashKeyActivated;
    private PlayerController playerController;
    private Rigidbody playerRb;
    private TrailRenderer trailRenderer;
    private ParticleSystem part;




    // Start is called before the first frame update
    void Start()
    {
        part = transform.GetComponentInChildren<ParticleSystem>();
        print(part);
        trailRenderer = transform.GetComponent<TrailRenderer>();
        dashCountdown = 0.0f;
        dashCooldown = 0.0f;
        playerRb = player.GetComponent<Rigidbody>();
        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if (dashCooldown <= 0f)
        //{
        //    if (Input.GetAxis(dashKey) >= 1)
        //    {
        //        if (!dashKeyActivated)
        //        {
        //            // Disable main player movement
        //            playerController.allowMovement = false;
        //            // Dash
        //            Dashing();
        //            part.Play();
        //            //Instantiate(dashPar, transform.position, transform.rotation);
        //            trailRenderer.emitting = true;
        //            dashCountdown = abilityDuration;
        //            dashCooldown = abilityCooldown;
        //            dashKeyActivated = true;
        //        }
        //    }
        //    else
        //    {
        //        dashKeyActivated = false;
        //    }
        //}
        //else if (dashCountdown < 0f)
        //{
        //    // Ability on cooldown and player finished using it
        //    dashCooldown -= Time.fixedDeltaTime;

        //}
        if (dashCountdown > 0f)
        {
            // Player still dashing
            Dashing();
            // Reduce duration
            dashCountdown -= Time.fixedDeltaTime;
        }
        else
        {
            if (trailRenderer.emitting)
            {
                trailRenderer.emitting = false;
            }
            if (part.isPlaying)
            {
                part.Stop();
            }
            // Allow player to move again
            playerController.allowMovement = true;
        }
    }
    public void SetupDash()
    {
        // Disable main player movement
        playerController.allowMovement = false;
        // Dash
        Dashing();
        part.Play();
        //Instantiate(dashPar, transform.position, transform.rotation);
        trailRenderer.emitting = true;
        dashCountdown = abilityDuration;
        dashCooldown = abilityCooldown;
        dashKeyActivated = true;
    }


    private void Dashing()
    {
        // Get which way player is facing in 3D space
        Vector3 currentDiraction = transform.right;
        playerRb.velocity = currentDiraction * dashSpeed;
    }

}

using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class CoolDown : MonoBehaviour
{
    public GameObject dashBar;
    public GameObject slowBar;
    public GameObject skipBar;
    public PlayerController player;
    Image dash;
    Image slow;
    Image skip;
    void Start()
    {
        dash = dashBar.GetComponent<Image>();
        slow = slowBar.GetComponent<Image>();
        skip = skipBar.GetComponent<Image>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        renderBar(dash, (player.dashCooldown - player.nextDash + Time.realtimeSinceStartup) /player.dashCooldown);
        renderBar(slow, (player.slowCooldown - player.nextSlow + Time.realtimeSinceStartup) / player.slowCooldown);
        Debug.Log((player.slowCooldown - player.nextSlow + Time.realtimeSinceStartup) / player.slowCooldown);
        renderBar(skip, (player.skipCooldown - player.nextSkip + Time.realtimeSinceStartup) / player.skipCooldown);
    }
    void renderBar(Image bar, float progress)
    {
        bar.fillAmount = Mathf.Clamp(progress, 0f,  1f);
    }
}

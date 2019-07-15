using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFx : MonoBehaviour

{
    public GameObject blend;
    public GameObject player;
    public GameObject playerHand;
    public GameObject ui;
    public GameObject ball;
    public Animator dolly;
    public Animator anim;
    public AudioSource continueSound;

    public void test(){
        // ui.SetActive(false);
        // ui.GetComponent<Canvas>().enabled = false;
        dolly.enabled = false;
        blend.SetActive(true);
        ui.GetComponent<CanvasGroup>().alpha = 0f;
        continueSound.Play();
        Time.timeScale = 0.61f;
        player.GetComponentInParent<PlayerController>().doDash.SetupDash();
        StartCoroutine(shoot());
        // playerHand.GetComponentInParent<PlayerHand>().Throw();
    }
    public void startGame(){
        GM.StartGame();
    }
    public void Exit(){
        Application.Quit();
    }
    IEnumerator shoot(){
        yield return new WaitForSeconds(2f);
        playerHand.GetComponentInParent<PlayerHand>().Throw();
        yield return new WaitForSeconds(0.25f);
        anim.SetTrigger("con");
        Time.timeScale = 0f;
        // GM.StartGame();
        
        // yield return new WaitForSeconds(1f);
        // Time.timeScale = 1f;
        // ball.GetComponent<Rigidbody>().velocity = new Vector3(0f,0f,0f);

    }
}

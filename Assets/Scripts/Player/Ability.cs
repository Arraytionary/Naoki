using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}
    public Animator camera;
    public Animator filter;
    public AudioSource skipSound;
    public AudioSource stopSound;


    public IEnumerator TimeSkip()
    {
        skipSound.Play();
        yield return new WaitForSeconds(0.87f);
        camera.SetTrigger("Crimson");
        Time.timeScale = 90;
        //Time.fixedDeltaTime = Time.timeScale * 0.02f;
        yield return new WaitForSeconds(0.0098f);
        Time.timeScale = 1;
    }

    public IEnumerator SlowTime()
    {
        stopSound.Play();
        filter.SetBool("theWorld", true);
        Time.timeScale = 0.09f;
        //Time.fixedDeltaTime = Time.timeScale * 0.02f;
        yield return new WaitForSeconds(0.4f);
        Time.timeScale = 1;
        filter.SetBool("theWorld", false);
    }
}

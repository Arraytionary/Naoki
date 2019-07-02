using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    public Text p1;
    public Text p2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        p1.text = GM.Instance.stats["player1"].ToString();
        p2.text = GM.Instance.stats["player2"].ToString();

    }
}

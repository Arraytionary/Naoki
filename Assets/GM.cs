using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM : Singleton<GM>
{
    // Start is called before the first frame update

        public IDictionary<string, float> stats = new Dictionary<string, float>(){
        {"player1", 0f},
        {"player2", 0f},
    };

    public static void StartGame(){
        Time.timeScale = 1;
        GM.Instance.stats["player1"] = 0f;
        SceneManager.LoadScene(1);
    }
    public static void ReloadScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
}

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


    public static void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}

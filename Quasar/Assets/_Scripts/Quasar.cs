using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Quasar : MonoBehaviour
{
    public Player play;
    static public Quasar S;
    // Start is called before the first frame update
    void Start()
    {
        S = this;
    }

    static public void ChangeScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }

    static public void Respawn()
    {
        ChangeScene(SceneManager.GetActiveScene().name);
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level1" && play == null)
        {
            Invoke("Respawn", 1.0f);
            DeathCounter.UPDATE_SCORE();
        }
    }
}

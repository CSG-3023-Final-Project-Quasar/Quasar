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
        if(scenename == "End")
        {
            DeathCount.FinalScore();
        }
        SceneManager.LoadScene(scenename);
        DeathCount.ResetScore();
    }

    static public void Respawn()
    {
        ChangeScene(SceneManager.GetActiveScene().name);
    }

    void Update()
    {
        if(play != null && play.transform.position.y > 10.0f || play.transform.position.y < -10.0f) 
        {
            Respawn();
            DeathCount.UpdateScore();
            TotalDeaths.UPDATE_SCORE();
            
        }

        if (SceneManager.GetActiveScene().name == "Level1" && play == null)
        {
            Invoke("Respawn", 1.0f);
            DeathCount.UpdateScore();
            TotalDeaths.UPDATE_SCORE();
        }

        
    }
}

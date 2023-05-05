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
            DeathCount.FinalScore(); //Set final score once level is complete
            DeathCount.ResetScore(); //Set the score back to 0
        }
        SceneManager.LoadScene(scenename);
    }

    static public void Respawn()
    {
        ChangeScene(SceneManager.GetActiveScene().name); //Start scene again
    }

    void Update()
    {
        //Check for going out of bounds
        if(play != null && play.transform.position.y > 10.0f || play.transform.position.y < -10.0f) 
        {
            Respawn();
            DeathCount.UpdateScore(); //Increment deaths
            TotalDeaths.UPDATE_SCORE();
        }
    }
}

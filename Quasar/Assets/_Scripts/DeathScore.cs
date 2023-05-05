using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DeathScore : MonoBehaviour
{
    static private TextMeshProUGUI uiText;
    static private int finalScore;
    // Start is called before the first frame update
    void Start()
    {
        uiText = GetComponent<TextMeshProUGUI>();
        finalScore = DeathCount.GetScore();
        uiText.text = "Deaths: " + finalScore.ToString("#,0") + "\n"
        + "Total Deaths: " + TotalDeaths.GET_SCORE().ToString("#,0"); //Displays deaths in End scene
    }
}

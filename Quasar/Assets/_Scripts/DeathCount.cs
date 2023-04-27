using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DeathCount : MonoBehaviour
{
    static private TextMeshProUGUI uiText;
    static private int score = 0;
    static private int finalScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        uiText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        uiText.text = "Deaths: " + score.ToString("#,0"); // Displays deaths
    }

    static public void FinalScore()
    {
        finalScore = score;
    }

    static public int GetScore()
    {
        return finalScore;
    }

    static public void UpdateScore()
    {
        score += 1;
    }

    static public void ResetScore()
    {
        score = 0;
    }
}

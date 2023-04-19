using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TotalDeaths : MonoBehaviour
{
    static private TextMeshProUGUI UIText;
    static private int _SCORE = 0;

    void Awake() {
        UIText = GetComponent<TextMeshProUGUI>();

        // Checks for an existing TotalDeaths
        if(PlayerPrefs.HasKey("TotalDeaths")) {
            SCORE = PlayerPrefs.GetInt("TotalDeaths");
        }
        // Assigns the score of deaths to TotalDeaths
        PlayerPrefs.SetInt("TotalDeaths", SCORE);
    }

    static public int SCORE {
        get {return _SCORE;}
        private set {
            _SCORE = value;
            PlayerPrefs.SetInt("TotalDeaths", value);
            if(UIText != null) {
                UIText.text = "Total Deaths: " + value.ToString("#,0");
            }
        }
    }

    static public void UPDATE_SCORE() {
        SCORE += 1; // Updates total death counter
    }

    // Reset PlayerPrefs TotalDeaths
    [Tooltip("Check this box to reset the TotalDeaths in PlayerPrefs")]
    public bool resetTotalDeaths = false;

    void OnDrawGizmos() {
        if(resetTotalDeaths) {
            resetTotalDeaths = false;
            PlayerPrefs.SetInt("TotalDeaths", 0);
            Debug.LogWarning("PlayerPrefs TotalDeaths reset to 0");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DeathCounter : MonoBehaviour
{
    static private TextMeshProUGUI UIText;
    static private int _SCORE = 0;

    void Awake() {
        UIText = GetComponent<TextMeshProUGUI>();

        // Checks for an existing DeathCounter
        if(PlayerPrefs.HasKey("DeathCounter")) {
            SCORE = PlayerPrefs.GetInt("DeathCounter");
        }
        // Assigns the score of deaths to DeathCounter
        PlayerPrefs.SetInt("DeathCounter", SCORE);
    }

    static public int SCORE {
        get {return _SCORE;}
        private set {
            _SCORE = value;
            PlayerPrefs.SetInt("DeathCounter", value);
            if(UIText != null) {
                UIText.text = "Deaths: " + value.ToString("#,0");
            }
        }
    }

    static public void UPDATE_SCORE() {
        SCORE += 1; // Updates death counter
    }

    // Reset PlayerPrefs DeathCounter
    [Tooltip("Check this box to reset the DeathCounter in PlayerPrefs")]
    public bool resetDeathCounter = false;

    void OnDrawGizmos() {
        if(resetDeathCounter) {
            resetDeathCounter = false;
            PlayerPrefs.SetInt("DeathCounter", 0);
            Debug.LogWarning("PlayerPrefs DeathCounter reset to 0");
        }
    }
}

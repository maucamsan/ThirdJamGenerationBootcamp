using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI movesTexts;
    int moves = 0;

    void OnEnable()
    {
        GameManager.OnCardsClicked += AddMovemet;
    }

    void OnDisable()
    {
        GameManager.OnCardsClicked -= AddMovemet;
    }
    void Start()
    {
        if (PlayerPrefs.GetInt("Best") == 0)
        {
            // Display nothing
        }
        else
        {
            // Display player prefs
            // PlayerPrefs.SetInt("Best", 0);
        }
    }

    public void AddMovemet()
    {
        moves += 1;
        movesTexts.text = "Moves: " + moves; 
    }
}

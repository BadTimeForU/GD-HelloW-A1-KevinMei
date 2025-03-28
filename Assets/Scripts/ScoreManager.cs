using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText; // Referentie naar het TMP_Text component  
   
    private int score = 0; // Beginwaarde van de score  

    void Start()
    {
        UpdateScoreText(); // Update de score weergave bij het starten van de game  
    }

    public void AddScore(int points)
    {
        score += points; // Voeg punten toe aan de score  
        UpdateScoreText(); // Update de weergave  
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score; // Zet de score weer op het scherm  
    }
}
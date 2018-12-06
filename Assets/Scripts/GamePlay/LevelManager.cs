using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    /// <summary>
    /// This script is responsible for managing the game aspects like score, health and detecting when game is over.
    /// </summary>
    #region Public Fields	
    public static LevelManager manager = null; // Singleton for levelmanager
    public UnityEngine.UI.Text scoreText;       // UI text to show current score of player.
    public UnityEngine.UI.Slider shipHealthSlider; // UI slider show current state of health of player.
    public int shipTotalHealth = 10;                // Total health of ship
    public string gameOverSceneName = null;
    #endregion

    #region Private Fields	
    private int currentScore;       // User's current score 
    private SaveScoreToJson saveToJson; // Class to save the current score and high score obtained by player.
    #endregion

    // Use this for initialization
    void Awake()
    {
        // Creating the singleton.
        if (manager != null)
        {
            DestroyImmediate(gameObject);
            return;
        }

        manager = this;
    }

    private void Start()
    {
        // Setting the maximum health of slider defined in the inspector.
        shipHealthSlider.maxValue = shipTotalHealth;
        shipHealthSlider.value = shipTotalHealth;
        saveToJson = GetComponent<SaveScoreToJson>();
    }


    #region Public Methods
    // Adding the score when player shoot downs the enemy
    public static void AddScore(int score)
    {
        manager.currentScore += score;
        manager.scoreText.text = manager.currentScore.ToString();
    }

    // Damage recived by the ship when the ememy is in contact with the ship
    public static void DoDamage(int damageAmount)
    {
        manager.shipHealthSlider.value -= damageAmount;
        if (manager.shipHealthSlider.value <= 0)
            manager.GameOver();
    }
    #endregion

    #region Private Methods	

    // Saving the high score and current score of the player when player's health is less or equals to 0. 
    private void GameOver()
    {
        saveToJson.SaveObject(currentScore);
        SceneManager.LoadScene(gameOverSceneName, LoadSceneMode.Single);

    }
    #endregion


}

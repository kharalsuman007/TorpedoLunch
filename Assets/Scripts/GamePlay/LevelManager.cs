using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    #region Public Fields	
    public static LevelManager manager = null;
    public UnityEngine.UI.Text scoreText;
    public UnityEngine.UI.Slider shipHealthSlider;
    public int shipTotalHealth = 10;
    public string gameOverSceneName = null;
    #endregion

    #region Private Fields	
    private int currentScore;
    private SaveScoreToJson saveToJson;
    #endregion

    // Use this for initialization
    void Awake()
    {
        if (manager != null)
        {
            DestroyImmediate(gameObject);
            return;
        }

        manager = this;
    }

    private void Start()
    {
        shipHealthSlider.maxValue = shipTotalHealth;
        shipHealthSlider.value = shipTotalHealth;
        saveToJson = GetComponent<SaveScoreToJson>();
    }


    #region Public Methods	
    public static void AddScore(int score)
    {
        manager.currentScore += score;
        manager.scoreText.text = manager.currentScore.ToString();
    }

    public static void DoDamage(int damageAmount)
    {
        manager.shipHealthSlider.value -= damageAmount;
        if (manager.shipHealthSlider.value <= 0)
            manager.GameOver();
    }
    #endregion

    #region Private Methods	

    private void GameOver()
    {
        saveToJson.SaveObject(currentScore);
        SceneManager.LoadScene(gameOverSceneName, LoadSceneMode.Single);

    }
    #endregion


}

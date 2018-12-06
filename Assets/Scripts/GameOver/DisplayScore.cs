using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayScore : MonoBehaviour
{
    /// <summary>
    /// This calss is responsible for retriving score data from JSON object to display
    /// user score.
    /// </summary>
    #region Public Fields	
    public UnityEngine.UI.Text highScoreText; // UI text box to show high score of Player.
    public UnityEngine.UI.Text currentScoreText; // UI text box to show current score of player.
    #endregion

    #region Private Fields	
    private SaveScoreToJson saveScoreToJson; // Class to load the highest score and current score obtained by player.
    #endregion

    // Use this for initialization
    void Start()
    {
        // Retriving the high score and current score from the JSON object and setting the values in UI.
        saveScoreToJson = GetComponent<SaveScoreToJson>();
        highScoreText.text = saveScoreToJson.highScore.ToString();
        currentScoreText.text = saveScoreToJson.currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    #region Public Methods	

    #endregion

    #region Private Methods	

    #endregion


}

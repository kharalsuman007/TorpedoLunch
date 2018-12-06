using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveScoreToJson : MonoBehaviour
{
    /// <summary>
    /// This script is responsible for saving the User score in the hard disk as a Json Object.
    /// Json object is created so that when user exits the game and replays back the highest score made by player is still recorded. 
    /// </summary>
    #region Public Fields		
    #endregion

    #region Private Fields
    [HideInInspector]
    public int highScore = 0;
    [HideInInspector]
    public int currentScore = 0;
    #endregion

    // Use this for initialization
    void Awake()
    {
        LoadObject();
    }

    // Update is called once per frame
    void Update()
    {

    }

    #region Public Methods

    public void SaveObject(int score)
    {
        // The directory path where you can store the data.
        string scoreOutputPath = Application.persistentDataPath + @"\Score.json";

        //Check if the current score is higher than saved highscore
        if (score > highScore)
            highScore = score;

        currentScore = score;

        // Write data to the given path
        StreamWriter writer = new StreamWriter(scoreOutputPath);
        writer.WriteLine(JsonUtility.ToJson(this));
        writer.Close();
    }

    public void LoadObject()
    {
        // The directory whe the data is stored.
        string scoreInputPath = Application.persistentDataPath + @"\Score.json";

        // When first playing the game the file doesn't exist so create one with score of 0
        if (File.Exists(scoreInputPath))
        {
            StreamReader reader = new StreamReader(scoreInputPath);
            string JSONString = reader.ReadToEnd();
            JsonUtility.FromJsonOverwrite(JSONString, this);
            reader.Close();
        }
        else
        {
            SaveObject(0);
        }

    }
    #endregion

    #region Private Methods	

    #endregion


}

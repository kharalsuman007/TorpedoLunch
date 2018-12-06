using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveScoreToJson : MonoBehaviour
{

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
        string scoreOutputPath = Application.persistentDataPath + @"\Score.json";
        if (score > highScore)
            highScore = score;
        currentScore = score;
        StreamWriter writer = new StreamWriter(scoreOutputPath);
        writer.WriteLine(JsonUtility.ToJson(this));
        writer.Close();
    }

    public void LoadObject()
    {
        string scoreInputPath = Application.persistentDataPath + @"\Score.json";
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

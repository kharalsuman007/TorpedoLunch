using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveScoreToJson : MonoBehaviour {

    #region Public Fields		
    #endregion

    #region Private Fields	
    private int highScore = 0;
    private int currentScore = 0;
	#endregion	
		
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
	    	
	}	
		
	#region Public Methods	
	public void SaveObject(int score)
    {
        
        string scoreOutputPath = Application.persistentDataPath + @"\Score.json";
        StreamWriter writer = new StreamWriter(scoreOutputPath);
        writer.WriteLine(JsonUtility.ToJson(this));
        writer.Close();
    }

    public void LoadObject()
    {
        string scoreInputPath = Application.persistentDataPath + @"\Score.json";
        StreamReader reader = new StreamReader(scoreInputPath);
        string JSONString = reader.ReadToEnd();
        JsonUtility.FromJsonOverwrite(JSONString, this);
        reader.Close();
    }
	#endregion	
		
	#region Private Methods	
		
	#endregion	
		
	
}

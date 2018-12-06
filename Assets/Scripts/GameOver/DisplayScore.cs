using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayScore : MonoBehaviour {

    #region Public Fields	
    public UnityEngine.UI.Text highScoreText;
    public UnityEngine.UI.Text currentScoreText;
    #endregion

    #region Private Fields	
    private SaveScoreToJson saveScoreToJson;
    #endregion

    // Use this for initialization
    void Start ()
    {
        saveScoreToJson = GetComponent<SaveScoreToJson>();
        highScoreText.text = saveScoreToJson.highScore.ToString();
        currentScoreText.text = saveScoreToJson.currentScore.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}	
		
	#region Public Methods	
		
	#endregion	
		
	#region Private Methods	
		
	#endregion	
		
	
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

    #region Public Fields
    public string loadSceneName;
    #endregion

    #region Private Fields	
    private UnityEngine.UI.Button thisButton;
	#endregion	
		
	// Use this for initialization
	void Start () {

        thisButton = GetComponent<UnityEngine.UI.Button>();
        thisButton.onClick.AddListener(() => LoadToScene());
	}
	
	// Update is called once per frame
	void Update () {
		
	}	
		
	#region Public Methods	
		
	#endregion	
		
	#region Private Methods	
	private void LoadToScene()
    {
        SceneManager.LoadScene(loadSceneName, LoadSceneMode.Single);
    }
	#endregion	
		
	
}

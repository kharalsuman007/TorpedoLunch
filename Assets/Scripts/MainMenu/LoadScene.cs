using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    /// <summary>
    /// This script is responsible for loading the scene name defined by the user in inspector.
    /// This script is attached to a button responsible for loading certain scene.
    /// </summary>
    #region Public Fields
    public string loadSceneName;
    #endregion

    #region Private Fields	
    private UnityEngine.UI.Button thisButton;
    #endregion

    // Use this for initialization
    void Start()
    {
        // Assigning the click event to button to run a function
        thisButton = GetComponent<UnityEngine.UI.Button>();
        thisButton.onClick.AddListener(() => LoadToScene());
    }

    // Update is called once per frame
    void Update()
    {

    }

    #region Public Methods	

    #endregion

    #region Private Methods	
    // Function to load the scene defied by user in inspector.
    private void LoadToScene()
    {
        SceneManager.LoadScene(loadSceneName, LoadSceneMode.Single);
    }
    #endregion


}

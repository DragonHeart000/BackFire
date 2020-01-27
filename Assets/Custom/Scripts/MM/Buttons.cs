using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Buttons : MonoBehaviour {

    public Canvas mainCanvas;
    public Canvas settingsCanvas;

    public TMP_InputField sensInput;

    // Use this for initialization
    void Start () {
        settingsCanvas.enabled = false;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void startGame()
    {
        SceneManager.LoadScene("Dev");
    }

    public void restartGame()
    {
        SceneManager.LoadScene("MM");
    }

    public void settigns()
    {
        settingsCanvas.enabled = true;
        mainCanvas.enabled = false;
    }

    public void backToMain()
    {
        settingsCanvas.enabled = false;
        mainCanvas.enabled = true;
    }

    public void setSens()
    {
        Debug.Log("test");
        PlayerSettings.setLookSensitivity(float.Parse(sensInput.text));
    }
}

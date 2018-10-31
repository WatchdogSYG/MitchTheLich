using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VictoryManager : MonoBehaviour {

    public GameObject Victory;
    public GameObject Loading;
    private Text VictoryText;
    private Text LoadingText;

	// Use this for initialization
	void Start () {
        VictoryText = Victory.GetComponent<Text>();
        LoadingText = Loading.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKeyDown)
        {
            VictoryText.enabled = false;
            LoadingText.enabled = true;
            SceneManager.LoadScene(0);
        }
    }
}

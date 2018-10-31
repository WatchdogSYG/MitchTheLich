using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour {
    public GameObject GameOver;
    public GameObject Loading;
    private Text GameOverText;
    private Text LoadingText;

    private void Start()
    {
        GameOverText = GameOver.GetComponent<Text>();
        LoadingText = Loading.GetComponent<Text>();
    }

    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameOverText.enabled = false;
            LoadingText.enabled = true;
            SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            GameOverText.enabled = false;
            LoadingText.enabled = true;
            SceneManager.LoadScene("mtl_01");
        }
    }

}

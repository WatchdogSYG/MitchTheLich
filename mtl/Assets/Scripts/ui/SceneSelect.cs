using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneSelect : MonoBehaviour {

	public void ChangeScene(int sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}

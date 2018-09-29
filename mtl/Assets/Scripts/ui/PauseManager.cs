using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PauseManager : MonoBehaviour {
    //Author Timothy Waclawik 
    //Purpose: Create a pause menu when the escape key is used

   // public AudioMixerSnapshot paused;     //Audio for paused menu
   // public AudioMixerSnapshot unpaused;
    Canvas canvas;

    // Use this for initialization
    void Start () {
        canvas = GetComponent<Canvas>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) //Pause Using escape key
        {
            canvas.enabled = !canvas.enabled;
            Pause();
        }
    }

    public void Pause()
    {
        Time.timeScale = Time.timeScale == 0 ? 1 : 0; //Pause and time stops in the scene
        //Lowpass();

    }


   // void Lowpass()
  //  {
      //  if (Time.timeScale == 0)
      //  {
            //paused.TransitionTo(.01f);
       // } else
       //{
          //  unpaused.TransitionTo(.01f);
       // }
    //}
    public void Quit() //quit game in both application and editor
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif
    }


}

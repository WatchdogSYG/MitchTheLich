using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public void LoadLevel(string name)
    {
        print("level load request for: " + name);
        Application.LoadLevel(name);
    }
	
}

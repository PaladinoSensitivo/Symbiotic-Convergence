using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public string previousScene;

    public void StartGame(string sceneName) 
    {
		SceneManager.LoadScene(sceneName);
	}

	public void Update()
    {
		if (Input.GetKeyDown(KeyCode.F1))
        {
            SceneManager.LoadScene(previousScene);
        }
    }
}

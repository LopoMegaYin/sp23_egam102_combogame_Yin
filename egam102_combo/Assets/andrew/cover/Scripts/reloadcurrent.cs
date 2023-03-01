using UnityEngine;
using UnityEngine.SceneManagement; //You need to add this line manually. Without it SceneManager scripts won't work.
using System.Collections;

public class ReloadScript : MonoBehaviour
{

	// Update is called once per frame

	void Update()
	{
			string currentScene = SceneManager.GetActiveScene().name;
			Debug.Log(currentScene);
			//Here we are asking the SceneManager to load the desired scene. In this instance we're providing it our variable 'currentScene'
			SceneManager.LoadScene(currentScene);
	}
}
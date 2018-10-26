using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	public GameObject mainMenu;
	public GameObject optionsMenu;

	public void PlayGame() {
		StartCoroutine(WaitSceneLoad());
	}

	public static void QuitGame() {
		Debug.Log("Quit");
		Application.Quit();
	}

	public void GoToOptionsMenu() {
		mainMenu.SetActive(false);
		optionsMenu.SetActive(true);
	}

	public void GoToMainMenu() {
		optionsMenu.SetActive(false);
		mainMenu.SetActive(true);
	}

	static IEnumerator WaitSceneLoad() {
		AsyncOperation asyncLoad = 	SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

		while (!asyncLoad.isDone) {
			yield return null;
		}
	}
	
}

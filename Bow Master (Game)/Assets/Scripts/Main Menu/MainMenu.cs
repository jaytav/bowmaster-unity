using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	public GameObject mainMenu;
	public GameObject optionsMenu;

	public static void PlayGame() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
	
}

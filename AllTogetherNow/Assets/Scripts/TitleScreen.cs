using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour
{
	public Button start;
	public Button quit;

	void Start()
	{
		Button btn = start.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
		quit.GetComponent<Button>().onClick.AddListener(Quit);
	}

	void TaskOnClick()
	{
		SceneManager.LoadScene("LevelSelect");
	}

	void Quit()
    {
		Application.Quit();
    }

}

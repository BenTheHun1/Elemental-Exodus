using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour
{
	public Button start;
	public Button quit;
	public Button startOver;

	void Start()
	{
		Button btn = start.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
		quit.GetComponent<Button>().onClick.AddListener(Quit);
		startOver.GetComponent<Button>().onClick.AddListener(DeleteProg);
	}

	void TaskOnClick()
	{
		SceneManager.LoadScene(1);
	}

	void Quit()
    {
		Application.Quit();
    }

	void DeleteProg()
    {
		PlayerPrefs.DeleteAll();
    }

}

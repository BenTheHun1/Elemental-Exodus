using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public Button fire1;
    public Button fire2;
    public Button fire3;
    public Button water1;
    public Button water2;
    public Button water3;
    // Start is called before the first frame update
    void Start()
    {
        fire1.GetComponent<Button>().onClick.AddListener(Fire1);
        fire2.GetComponent<Button>().onClick.AddListener(Fire2);
        fire3.GetComponent<Button>().onClick.AddListener(Fire3);
        water1.GetComponent<Button>().onClick.AddListener(Water1);
        water2.GetComponent<Button>().onClick.AddListener(Water2);
        //water3.GetComponent<Button>().onClick.AddListener(Water3);
        LoadGame();
    }

    void LoadGame()
    {
        if (PlayerPrefs.GetInt("FZA2") == 1)
        {
            fire2.GetComponent<Button>().interactable = true;
        }
        else
        {
            fire2.GetComponent<Button>().interactable = false;
        }

        if (PlayerPrefs.GetInt("FZA3") == 1)
        {
            fire3.GetComponent<Button>().interactable = true;
        }
        else
        {
            fire3.GetComponent<Button>().interactable = false;
        }

        if (PlayerPrefs.GetInt("WZA2") == 1)
        {
            water2.GetComponent<Button>().interactable = true;
        }
        else
        {
            water2.GetComponent<Button>().interactable = false;
        }

        if (PlayerPrefs.GetInt("WZA3") == 1)
        {
            water3.GetComponent<Button>().interactable = true;
        }
        else
        {
            water3.GetComponent<Button>().interactable = false;
        }
    }

    void Fire1()
    {
        SceneManager.LoadScene(2);
    }

    void Fire2()
    {
        SceneManager.LoadScene(3);
    }

    void Fire3()
    {
        SceneManager.LoadScene(4);
    }

    void Water1()
    {
        SceneManager.LoadScene(6);
    }

    void Water2()
    {
        SceneManager.LoadScene(7);
    }

    void Water3()
    {
        //SceneManager.LoadScene("WaterZoneAct3");
    }
}

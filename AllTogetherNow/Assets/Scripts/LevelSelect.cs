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
    public Button final;
    // Start is called before the first frame update
    void Start()
    {
        final.GetComponent<Button>().onClick.AddListener(Final);
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
            fire2.gameObject.SetActive(true);
        }
        else
        {
            fire2.gameObject.SetActive(false);
        }

        if (PlayerPrefs.GetInt("FZA3") == 1)
        {
            fire3.gameObject.SetActive(true);
        }
        else
        {
            fire3.gameObject.SetActive(false);
        }

        if (PlayerPrefs.GetInt("WZA2") == 1)
        {
            water2.gameObject.SetActive(true);
        }
        else
        {
            water2.gameObject.SetActive(false);
        }

        if (PlayerPrefs.GetInt("WZA3") == 1)
        {
            water3.gameObject.SetActive(true);
        }
        else
        {
            water3.gameObject.SetActive(false);
        }

        if (PlayerPrefs.GetInt("FZGEM") == 1)
        {
            GameObject.Find("Fire Gem").SetActive(true);
        }
        else
        {
            GameObject.Find("Fire Gem").SetActive(false);
        }

        if (PlayerPrefs.GetInt("WZGEM") == 1)
        {
            GameObject.Find("Water Gem").SetActive(true);
        }
        else
        {
            GameObject.Find("Water Gem").SetActive(false);
        }

        if (PlayerPrefs.GetInt("FZGEM") == 1 && PlayerPrefs.GetInt("WZGEM") == 1)
        {
            final.gameObject.SetActive(true);
        }
        else
        {
            final.gameObject.SetActive(false);
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
        SceneManager.LoadScene(5);
    }

    void Water2()
    {
        SceneManager.LoadScene(6);
    }

    void Water3()
    {
        //SceneManager.LoadScene("WaterZoneAct3");
    }

    void Final()
    {
        SceneManager.LoadScene(7);
    }
}

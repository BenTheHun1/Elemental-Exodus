using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{

     void OnCollisionEnter2D(Collision2D collision)
    {	
		if (collision.gameObject.name == "tempPlayer")
        {
            if (SceneManager.GetActiveScene().name == "WaterZoneAct1")
            {
                PlayerPrefs.SetInt("WZA2", 1);

            }
            if (SceneManager.GetActiveScene().name == "WaterZoneAct2")
            {
                PlayerPrefs.SetInt("WZGEM", 1);
            }
            SceneManager.LoadScene(1);
        }
    }
}

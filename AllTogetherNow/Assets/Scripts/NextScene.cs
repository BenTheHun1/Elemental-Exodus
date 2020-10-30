using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D collision)
    {	
	    if (collision.gameObject.CompareTag("Player"))
        {
            if (SceneManager.GetActiveScene().name == "FireZoneAct1")
            {
                PlayerPrefs.SetInt("FZA2", 1);
            }
            SceneManager.LoadScene("Level Select");
        }
    }
}

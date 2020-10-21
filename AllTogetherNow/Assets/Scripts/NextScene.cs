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
           SceneManager.LoadScene(1);
        }
    }
}

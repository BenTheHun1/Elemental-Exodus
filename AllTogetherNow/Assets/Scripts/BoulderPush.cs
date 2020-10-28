using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderPush : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Hole"))
        {
            other.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            other.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            other.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
            gameObject.SetActive(false);
        }
    }
}

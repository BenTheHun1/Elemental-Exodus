using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MovingPlatform : MonoBehaviour
{
    public Vector3 position_1;
    public Vector3 position_2;
    private float speed;
    public BoxCollider2D exit_1;
    public BoxCollider2D exit_2;

    // Start is called before the first frame update
    void Start()
    {
        speed = 1.0f;   
    }

    private void Update()
    {
        if (transform.position == position_1)
        {
            exit_1.enabled = false;
        }
        else if (transform.position == position_2)
        {
            exit_2.enabled = false;
        }
        else
        {
            exit_1.enabled = true;
            exit_2.enabled = true;
        }
    }

    //IEnumerator Move()
  //  {
        
   // }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Move");
    }


    IEnumerator Move()
    {
        while (transform.position.y > -40)
        {
            transform.Translate(new Vector2(0, -0.07f));
            yield return new WaitForSeconds(0.0001f);
        }
        Destroy(gameObject);
        
    }

}

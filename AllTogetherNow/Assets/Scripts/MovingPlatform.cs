using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MovingPlatform : MonoBehaviour
{
    public Vector3 position_1;
    public Vector3 position_2;
    public float speed;
    public BoxCollider2D exit_1;
    public BoxCollider2D exit_2;
    public GameObject receiver_1;
    public GameObject receiver_2;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Move");
    }

    private void Update()
    {
        if (transform.position == position_1)
        {
            exit_1.enabled = false;
            receiver_1.GetComponent<BoxCollider2D>().enabled = false;
        }
        else if (transform.position == position_2)
        {
            exit_2.enabled = false;
            receiver_2.GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            exit_1.enabled = true;
            exit_2.enabled = true;
            receiver_1.GetComponent<BoxCollider2D>().enabled = true;
            receiver_2.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    IEnumerator Move()
    {
        while (true)
        {
            transform.position = position_1;
            yield return new WaitForSeconds(2);
            for (float i = 0f; i < speed; i++)
            {
                transform.Translate((position_2 - position_1) / speed);
                yield return new WaitForSeconds(0.005f);
            }
            transform.position = position_2;
            yield return new WaitForSeconds(2);
            for (float i = 0f; i < speed; i++)
            {
                transform.Translate(-(position_2 - position_1) / speed);
                yield return new WaitForSeconds(0.005f);
            }

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAiSimple : MonoBehaviour
{
    private float speed = 2;
    public Rigidbody2D rb2d;
    private Vector2 random_dir;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        random_dir = new Vector2(Random.Range(-5, 6), Random.Range(-5, 6));
        rb2d.MovePosition(rb2d.position + Time.fixedDeltaTime * speed * random_dir);
    }
}

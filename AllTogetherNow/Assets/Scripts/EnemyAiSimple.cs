using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAiSimple : MonoBehaviour
{
    private float speed = 1.1f;
    public Rigidbody2D rb2d;
    private Vector2 random_dir;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        random_dir = new Vector2(Random.Range(-5, 6), Random.Range(-5, 6));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + Time.fixedDeltaTime * speed * random_dir);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        random_dir = new Vector2(Random.Range(-5, 6), Random.Range(-5, 6));
    }
}

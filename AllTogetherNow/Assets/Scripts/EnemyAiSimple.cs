﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAiSimple : MonoBehaviour
{
    private float speed = 1.1f;
    public int hp;
    private Rigidbody2D rb2d;
    private Vector2 random_dir;
    public bool isBoss;
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        random_dir = new Vector2(Random.Range(-5, 6), Random.Range(-5, 6));
        StartCoroutine("Jostle");
        if (isBoss)
        {
            StartCoroutine("BulletHell");
        }
    }

    IEnumerator BulletHell()
    {
        while (hp > 0)
        {
            Instantiate(bullet, new Vector3(transform.position.x, transform.position.y - 2, -1), transform.rotation);
            yield return new WaitForSeconds(1);
        }
    }

    IEnumerator Jostle()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            random_dir = new Vector2(Random.Range(-5, 6), Random.Range(-5, 6));
        }
       
    }


    void checkLife()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
            if (isBoss)
            {
                GameObject.Find("Bridge").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("Bridge").GetComponent<BoxCollider2D>().enabled = false;
            }
        }
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            hp -= 1;
            checkLife();
        }
    }

}

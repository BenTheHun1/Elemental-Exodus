using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIPlatformerGround : MonoBehaviour
{
    private float speed = 1.1f;
    public Rigidbody2D rb2d;
    private Vector2 dir;
	public bool isUnderWater;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        dir = new Vector2(-4, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + Time.fixedDeltaTime * speed * dir);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
		
		if (collision.gameObject.name == "OutOfWater")
        {
			isUnderWater = false;
        }

		if (collision.gameObject.name == "InWater")
        {
			isUnderWater = true;
        }
		
		foreach(ContactPoint2D hitPos in collision.contacts)
		{
			if (hitPos.normal.x < 0)
			{
			dir = new Vector2(-4, 0);
			}
				
			if (hitPos.normal.x > 0)
			{
			dir = new Vector2(4, 0);
			}
		}
		
		if ((collision.gameObject.name == "tempPlayer" && isUnderWater == false))
        {
			foreach(ContactPoint2D hitPos in collision.contacts)
			{
				if (hitPos.normal.y < 0)
				{
				Destroy(gameObject);
				}
			}
		   
		   
        }
		
    }
}

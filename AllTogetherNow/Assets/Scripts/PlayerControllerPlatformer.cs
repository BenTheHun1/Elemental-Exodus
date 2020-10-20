using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerPlatformer : MonoBehaviour
{
	
	public float Speed = 20f;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		Jump();
		float DirectionX = Input.GetAxis ("Horizontal") * Speed * Time.deltaTime;
		transform.position = new Vector2 (transform.position.x + DirectionX, transform.position.y);
	   
    }
	
	void Jump()
    {
		
		if (Input.GetButtonDown("Jump"))
		{
			gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f,Speed),ForceMode2D.Impulse);
		}
	   
    }
}

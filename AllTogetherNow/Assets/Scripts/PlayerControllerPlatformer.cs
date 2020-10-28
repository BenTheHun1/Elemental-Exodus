using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerPlatformer : MonoBehaviour
{
	public GameObject Camera;
	public float Speed;
	public float JumpPower;
	public bool horizontalaxis;
	public bool verticalaxis;
	public Vector3 MinCameraPos;
	public Vector3 MaxCameraPos;
	public Rigidbody2D rigidbody2d;

    void Update()
    {
		Jump();
		float DirectionX = Input.GetAxis ("Horizontal") * Speed * Time.deltaTime;
		transform.position = new Vector2 (transform.position.x + DirectionX, transform.position.y);
		
		if (horizontalaxis)
		{
          Camera.transform.position = new Vector3(Mathf.Clamp(transform.position.x, MinCameraPos.x, MaxCameraPos.x), 1, -1);
		}
		
		if (verticalaxis)
		{
          Camera.transform.position = new Vector3(Mathf.Clamp(transform.position.x, MinCameraPos.x, MaxCameraPos.x), Mathf.Clamp(transform.position.y, MinCameraPos.y, MaxCameraPos.y), -1);
		}
		
    }
	
	void Jump()
    {
		if (Input.GetButtonDown("Jump"))
		{
			Speed = 8f;
			rigidbody2d.velocity = Vector2.up * JumpPower * 1.3f;
		}
	   
    }
	
	void OnCollisionExit2D (Collision2D collision)
	{
	
		if (collision.gameObject.name == "Sand")
		{
				Speed = 8f;
		   
        }
	
	}
	
		
	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.name == "Sand")
        {
			foreach(ContactPoint2D hitPos in collision.contacts)
			{
				if (hitPos.normal.y > 0)
				{
				Speed = 5f;
				}
			}
		   
		   
        }
	}
	
	void OnTriggerStay2D(Collider2D collision)
    {	
		
		if (collision.gameObject.name == "ChangeCameraPerspectiveHorizontal")
        {
			MinCameraPos = new Vector3(-1,-46,-1);
			MaxCameraPos = new Vector3(137,-21,-1);
			horizontalaxis = true;
			verticalaxis = false;
        }
		
		if (collision.gameObject.name == "ChangeCameraPerspectiveVerticalBottom")
        {
			MinCameraPos = new Vector3(-1,-46,-1);
			MaxCameraPos = new Vector3(137,-21,-1);
			verticalaxis = true;
			horizontalaxis = false;
        }
		
		if (collision.gameObject.name == "ChangeCameraPerspectiveVerticalTop")
        {
			MinCameraPos = new Vector3(-1,24,-1);
			MaxCameraPos = new Vector3(137,43,-1);
			verticalaxis = true;
			horizontalaxis = false;
        }
		
    }
	
}

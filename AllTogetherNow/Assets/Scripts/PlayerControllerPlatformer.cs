using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerPlatformer : MonoBehaviour
{
	public GameObject cam;
	public float Speed;
	public float JumpPower;
	public bool horizontalaxis;
	public bool verticalaxis;
	public bool flipped;
	public bool isUnderWater;
	public bool isJumping;
	public Vector3 MinCameraPos;
	public Vector3 MaxCameraPos;
	public Rigidbody2D rigidbody2d;
	public Animator animator;
	public GameObject healthScript;
	public bool invincible;

    void Update()
    {
		Jump();
		float DirectionX = Input.GetAxis ("Horizontal") * Speed * Time.deltaTime;
		transform.position = new Vector2 (transform.position.x + DirectionX, transform.position.y);
		
		if ((DirectionX > 0 && isJumping == false))
		{
		flipped = false;
		animator.SetBool("Idle", false);
		animator.SetBool("Walking", true);
		animator.SetBool("FlippedWalk", false);
		animator.SetBool("FlippedIdle", false);
		}
		
		if ((DirectionX < 0 && isJumping == false))
		{
		flipped = true;
		animator.SetBool("Idle", false);
		animator.SetBool("Walking", false);
		animator.SetBool("FlippedWalk", true);
		animator.SetBool("FlippedIdle", false);
		}
		
		if ((DirectionX == 0) && flipped == false && isJumping == false)
		{
		animator.SetBool("Idle", true);
		animator.SetBool("Walking", false);
		animator.SetBool("FlippedWalk", false);
		animator.SetBool("FlippedIdle", false);
		}
		
		if ((DirectionX == 0) && flipped == true  && isJumping == false)
		{
		animator.SetBool("Idle", false);
		animator.SetBool("Walking", false);
		animator.SetBool("FlippedWalk", false);
		animator.SetBool("FlippedIdle", true);
		}

		
		if ((rigidbody2d.velocity.y < -0.1) && isUnderWater == true)
		{
		rigidbody2d.gravityScale = 0.3f;
		}
		
		
		if (horizontalaxis)
		{
          cam.transform.position = new Vector3(Mathf.Clamp(transform.position.x, MinCameraPos.x, MaxCameraPos.x), 1, -1);
		}
		
		if (verticalaxis)
		{
			cam.transform.position = new Vector3(Mathf.Clamp(transform.position.x, MinCameraPos.x, MaxCameraPos.x), Mathf.Clamp(transform.position.y, MinCameraPos.y, MaxCameraPos.y), -1);
		}
		
    }
	
	void Jump()
    {
		if (Input.GetButtonDown("Jump"))
		{
			
			if ((isUnderWater == false) && isJumping == false)
			{
			isJumping = true;
			animator.SetBool("Idle", false);
			animator.SetBool("Walking", false);
			animator.SetBool("FlippedWalk", false);
			animator.SetBool("FlippedIdle", false);
			if (flipped == false)
			{
			animator.SetBool("Jump", true);
			}
			if (flipped == true)
			{
			animator.SetBool("Jump", false);
			animator.SetBool("FlippedJump", true);
			print("Flipped");
			}
			Speed = 8f;
			rigidbody2d.velocity = Vector2.up * JumpPower * 1.3f;
			}
			
			if (isUnderWater == true)
			{
			rigidbody2d.gravityScale = 1;
			Speed = 8f;
			rigidbody2d.velocity = Vector2.up * JumpPower * 1.3f;
			}
		}
	   
    }
	
	void OnCollisionExit2D (Collision2D collision)
	{
	
		if ((collision.gameObject.name == "Sand") && isUnderWater == true)
		{
				Speed = 8f;
		   
        }
	
	}
	
		
	void OnCollisionEnter2D(Collision2D collision)
	{
		if ((collision.gameObject.name == "Sand") && isUnderWater == true)
        {
			foreach(ContactPoint2D hitPos in collision.contacts)
			{
				if (hitPos.normal.y > 0)
				{
				Speed = 5f;
				}
			}
		   
		   
        }
		
		if ((collision.gameObject.name == "Sand") && isUnderWater == false)
		{
			foreach(ContactPoint2D hitPos in collision.contacts)
			{
				if (hitPos.normal.y > 0)
				{
				isJumping = false;
				}
			}
		}
		
	}
	
	void OnTriggerStay2D(Collider2D collision)
    {
		
		if (collision.gameObject.name == "OutOfWater")
        {
			isUnderWater = false;
        }

		if (collision.gameObject.name == "InWater")
        {
			isUnderWater = true;
        }
		
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
		
		if (collision.gameObject.name == "ScrollerDetector")
        {
			MinCameraPos = new Vector3(3,-46,-1);
			MaxCameraPos = new Vector3(420,111,-1);
			verticalaxis = true;
			horizontalaxis = false;
        }
		
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !invincible)
        {
			healthScript.GetComponent<Health>().takeDamage(1);
			StartCoroutine("Invincible");
		}
    }

	IEnumerator Invincible()
	{
		invincible = true;
		yield return new WaitForSeconds(0.75f);
		invincible = false;
	}
}

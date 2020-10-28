using System;
using System.Collections;
using UnityEngine;

public class PlayerControllerARPG : MonoBehaviour
{
    public Vector2 movement;
    public float speed;
    public GameObject Camera;
    public Animator animator;
    public Rigidbody2D rb2d;
    public GameObject sword;
    public Boolean attacking;

    private BoxCollider2D bg_collider;
    private Vector2 MinCameraPos;
    private Vector2 MaxCameraPos;

    private Vector3 parentPos;

    // Start is called before the first frame update
    void Start()
    {
        bg_collider = GameObject.Find("BG").GetComponent<BoxCollider2D>();
        MinCameraPos = -bg_collider.size * 3;
        MaxCameraPos = bg_collider.size * 3;
        Debug.Log(bg_collider.size);
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (Input.GetKeyDown(KeyCode.Space) && !attacking)
        {
            StartCoroutine(Slash());
        }

    }

    IEnumerator Slash()
    {
        attacking = true;
        sword.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        sword.SetActive(false);
        attacking = false;
    }

    private void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + Time.fixedDeltaTime * speed * movement);
    }

    private void LateUpdate()
    {
        Camera.transform.position = new Vector3(Mathf.Clamp(transform.position.x, MinCameraPos.x, MaxCameraPos.x), Mathf.Clamp(transform.position.y, MinCameraPos.y, MaxCameraPos.y), -10);
        //.transform.position = transform.position + new Vector3(0, 0, -1);

        parentPos = gameObject.transform.position + new Vector3(0, 0, 1);

        //sword.SetActive(true);
        if (movement.y == 1)
        {
            animator.SetInteger("Idle", 1);
            sword.transform.position = parentPos + Vector3.up;
            sword.transform.eulerAngles = new Vector3(0, 0, 90);
        }
        else if (movement.y == -1)
        {
            animator.SetInteger("Idle", 3);
            sword.transform.position = (parentPos - new Vector3(0, 0, 1.5f)) + Vector3.down;
            sword.transform.eulerAngles = new Vector3(0, 0, 90);
        }
        else if (movement.x == -1)
        {
            animator.SetInteger("Idle", 4);
            sword.transform.position = parentPos + Vector3.left;
            sword.transform.eulerAngles = Vector3.zero;
        }
        else if (movement.x == 1)
        {
            animator.SetInteger("Idle", 2);
            sword.transform.position = parentPos + Vector3.right;
            sword.transform.eulerAngles = Vector3.zero;
        }

    }
}

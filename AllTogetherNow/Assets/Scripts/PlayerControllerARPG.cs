using System;
using System.Collections;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class PlayerControllerARPG : MonoBehaviour
{
    public Vector2 movement;
    public float speed;
    private GameObject Camera;
    public Animator animator;
    public Rigidbody2D rb2d;
    public GameObject sword;
    public Boolean attacking;

    private Renderer bg_rend;
    private Vector2 MinCameraPos;
    private Vector2 MaxCameraPos;

    private Vector3 parentPos;

    // Start is called before the first frame update
    void Start()
    {
        Camera = GameObject.Find("Main Camera");
        bg_rend = GameObject.Find("BG").GetComponent<Renderer>();
        MinCameraPos = new Vector2(-bg_rend.bounds.size.x / 2 + (Screen.width / 80f), -bg_rend.bounds.size.y / 2 + (Screen.height / 80f));
        MaxCameraPos = new Vector2(bg_rend.bounds.size.x / 2 - (Screen.width / 80f), bg_rend.bounds.size.y / 2 - (Screen.height / 80f));
        Debug.Log(bg_rend.bounds.size.x / 2);
        Debug.Log(Screen.width / 80f);
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Screen.width);
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

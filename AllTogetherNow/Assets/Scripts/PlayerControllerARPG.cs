using System;
using System.Collections;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControllerARPG : MonoBehaviour
{
    public Vector2 movement;
    public float speed;
    private GameObject cam;
    public Animator animator;
    public Rigidbody2D rb2d;
    public GameObject sword;
    public Boolean attacking;
    private GameObject hpscript;
    private bool invincible;
    public GameObject gem;

    //private Renderer bg_rend;
    public Vector2 MinCameraPos;
    public Vector2 MaxCameraPos;

    private Vector3 parentPos;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera");
        hpscript = GameObject.Find("Canvas");
        //bg_rend = GameObject.Find("BG").GetComponent<Renderer>();
        //MinCameraPos = new Vector2(-bg_rend.bounds.size.x / 2 + (Screen.width / 80f), -bg_rend.bounds.size.y / 2 + (Screen.height / 80f));
        //MaxCameraPos = new Vector2(bg_rend.bounds.size.x / 2 - (Screen.width / 80f), bg_rend.bounds.size.y / 2 - (Screen.height / 80f));
        //Camera.world
        //Debug.Log(bg_rend.bounds.size.x / 2);
        //Debug.Log(Screen.width / 80f);
        
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

    IEnumerator Invincible()
    {
        invincible = true;
        yield return new WaitForSeconds(0.75f);
        invincible = false;
    }


    IEnumerator Slash()
    {
        attacking = true;
        sword.SetActive(true);
        sword.GetComponent<AudioSource>().Play();
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
        cam.transform.position = new Vector3(Mathf.Clamp(transform.position.x, MinCameraPos.x, MaxCameraPos.x), Mathf.Clamp(transform.position.y, MinCameraPos.y, MaxCameraPos.y), -10);
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
            sword.transform.eulerAngles = new Vector3(0, 0, -90);
        }
        else if (movement.x == -1)
        {
            animator.SetInteger("Idle", 4);
            sword.transform.position = parentPos + Vector3.left;
            sword.transform.eulerAngles = new Vector3(0, 0, -180);
        }
        else if (movement.x == 1)
        {
            animator.SetInteger("Idle", 2);
            sword.transform.position = parentPos + Vector3.right;
            sword.transform.eulerAngles = Vector3.zero;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") && !invincible)
        {
            hpscript.GetComponent<Health>().takeDamage(1);
            StartCoroutine("Invincible");
        }
        if (other.gameObject.CompareTag("Bullet") && !invincible)
        {
            Destroy(other.gameObject);
            hpscript.GetComponent<Health>().takeDamage(1);
            StartCoroutine("Invincible");
        }
        if (other.gameObject.CompareTag("Exit"))
        {
            if (SceneManager.GetActiveScene().name == "FireZoneAct1")
            {
                PlayerPrefs.SetInt("FZA2", 1);

            }
            if (SceneManager.GetActiveScene().name == "FireZoneAct2")
            {
                PlayerPrefs.SetInt("FZA3", 1);
            }
            if (SceneManager.GetActiveScene().name == "FireZoneAct3")
            {
                if (gem.GetComponent<PickUpGem>().hasGem == true)
                {
                    PlayerPrefs.SetInt("FZGEM", 1);
                }
               
            }
            SceneManager.LoadScene(1);
        }
    }
}

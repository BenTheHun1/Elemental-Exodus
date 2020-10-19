using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float xInput;
    public float yInput;
    public float speed = 20;
    public GameObject camera;
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

        rb2d.MovePosition(Vector2.up * Time.deltaTime * speed * yInput);

       // transform.Translate(Vector2.up * Time.deltaTime * speed * yInput);
        transform.Translate(Vector2.right * Time.deltaTime * speed * xInput);

    }

    private void LateUpdate()
    {
        camera.transform.position = transform.position + new Vector3(0,0, -1);
    }
}

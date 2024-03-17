using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl2 : MonoBehaviour
{
    public float jumpForce = 150.0f;
    public float speed = 1.0f;
    public float moveDirection;

    private bool jump;
    private bool grounded = true;
    private bool moving;
    private Rigidbody2D rb;
    private SpriteRenderer spriterenderer;
    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>(); 
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriterenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (rb.velocity != Vector2.zero)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }

        rb.velocity = new Vector2(speed * moveDirection, rb.velocity.y);
        if (jump == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jump = false;
        }
    }
    private void Update()
    {
        if (grounded == true && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            if (Input.GetKey(KeyCode.A))
            {
                moveDirection = -1.0f;
                transform.rotation = new Quaternion(transform.rotation.x, 180f, transform.rotation.z, transform.rotation.w);
                anim.SetFloat("speed", speed);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                moveDirection = 1.0f;
                transform.rotation = new Quaternion(transform.rotation.x, 0f, transform.rotation.z,transform.rotation.w);
                anim.SetFloat("speed", speed);
            }
            
        }
        else if (grounded == true)
        {
            moveDirection = 0.0f;
            anim.SetFloat("speed", 0.0f);
        }

        if (grounded == true && Input.GetKey(KeyCode.W))
        {
            jump = true;
            grounded = false;
            anim.SetTrigger("jump");
            anim.SetBool("grounded", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("zemin"))
        { 
            grounded = true;
            anim.SetBool("grounded", true);
        }
    }
}

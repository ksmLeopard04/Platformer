using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float movementSpeed = 6;
    [SerializeField]GameSceneManager GameSceneManager;
    [SerializeField] Animator animator;
    private Rigidbody2D rb;
    private Vector2 move;
    private float jumpforce = 8f;
    private bool jumping = false;
    public static bool isGrounded = false;
    public static bool timeRecorded = false;
    bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(isGrounded == true)
        {
            move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
        if(move.x > 0 && !facingRight)
        {
            Flip();
        }
        if(move.x < 0 && facingRight)
        {
            Flip();
        }
        if(Mathf.Abs(move.x) > 0.1 && isGrounded == true)
        {
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            jumping = true;
            isGrounded = false;
        }
    }
    void FixedUpdate()
    {
        if(isGrounded == true)
        {
            rb.velocity = new Vector2(move.x * movementSpeed, rb.velocity.y);
            animator.SetBool("jumping", false);
        }
        if (jumping == true)
        {
            animator.SetBool("jumping", true);
            rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
            isGrounded = false;
            jumping = false;
        }
    }
    void Flip()
    {
        Vector3 currentScale = animator.transform.localScale;
        currentScale.x *= -1;
        animator.transform.localScale = currentScale;


        facingRight = !facingRight;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Checkpoint")
        {
            GameSceneManager.LoadLevelTwo();
        }
        if(col.gameObject.tag == "Finish")
        {
            GameSceneManager.gameOver = true;
            GameSceneManager.LoadMenu();
        }
    }
}

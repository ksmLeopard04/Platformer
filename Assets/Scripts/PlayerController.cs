using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float movementSpeed = 5;
    [SerializeField]GameSceneManager GameSceneManager;
    [SerializeField] Animator animator;
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;
    private Vector2 move;
    private float jumpforce = 8f;
    private bool jumping = false;
    public static bool gameOver;
    public static bool isGrounded = false;
    bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(isGrounded == true)
        {
            move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
        if(move.x == 0)
        {
            animator.SetBool("moving", false);
        }
        if(move.x > 0 && !facingRight && isGrounded == true)
        {
            animator.SetBool("moving", true);
            Flip();
        }
        if(move.x < 0 && facingRight && isGrounded == true)
        {
            animator.SetBool("moving", true);
            Flip();
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
}

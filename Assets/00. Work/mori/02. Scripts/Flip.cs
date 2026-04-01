using UnityEngine;

public class Flip : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private float jumpForce = 15f;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    
    void OnMouseDown()
    {
        anim.SetBool("isFlip", true);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        anim.SetBool("isFlip", false);
    }
}
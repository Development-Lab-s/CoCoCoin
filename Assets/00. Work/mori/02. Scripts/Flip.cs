using UnityEngine;

public class Flip : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private float jumpForce = 15f;
    public Animator HandAnim;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    
    void OnMouseDown()
    {
        rb.gravityScale = 3;
        HandAnim.SetBool("isFlipping", true);
        anim.SetBool("isFlip", true);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        HandAnim.SetBool("isFlipping", false);
        anim.SetBool("isFlip", false);
        rb.gravityScale = 0;
    }
}
using UnityEngine;

public class Flip : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private float jumpForce = 15f;
    private bool nowFlip = false;
    public Animator HandAnim;
    
    [SerializeField] private InventoryItemSO chipModel;
    [SerializeField] private GameObject enemy;

    public AudioSource audio;
    public AudioClip Spinning;
    public AudioClip Failed;
    public AudioClip Success;

    public void SpinFailed()
    {
        audio.clip = Failed;
    }
    public void SpinSuccess()
    {
        audio.clip = Success;
    }
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    
    void OnMouseDown()
    {
        audio.loop = true;
        audio.clip = Spinning;
        rb.gravityScale = 3;
        HandAnim.SetBool("isFlipping", true);
        anim.SetBool("isFlip", true);
        audio.Play();
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        nowFlip = true;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        audio.Stop();
        if (!nowFlip)
            return;
        audio.loop = false;
        chipModel.ChipEncounter.FlipCoin(this);
        nowFlip = false;
        HandAnim.SetBool("isFlipping", false);
        anim.SetBool("isFlip", false);
        audio.Play();
        rb.gravityScale = 0;
    }
}
using UnityEngine;

public class CoinGoDownScript : MonoBehaviour
{
    private RectTransform cameraSize;
    [SerializeField]private GameObject target;
    private float speed = 100f;
    private Rigidbody2D rigid;
    private float size;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        cameraSize = GameObject.Find("Canvas").GetComponent<RectTransform>();
        size = cameraSize.transform.position.y * 2;
        
    }


    void FixedUpdate()
    {
        rigid.linearVelocityY = -speed;
        if(transform.position.y <= -size + 500)
        {
            transform.position = target.transform.position + size * Vector3.up;
        }
    }
}

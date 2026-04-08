using UnityEngine;

public class Anime : MonoBehaviour
{
    private Animator animator;
    int a = 0;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnMouseDown()
    {
        a += 1;
        if (0 == 1)
        {
            
        }
    }
}
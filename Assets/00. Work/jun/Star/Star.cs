using UnityEngine;

public class Star : MonoBehaviour
{
    private float sarazimTime = 0.8f;
    private void Awake()
    {
        Destroy(gameObject, sarazimTime);
    }
}

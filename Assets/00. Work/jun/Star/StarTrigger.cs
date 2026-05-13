using UnityEngine;

public class StarTrigger : MonoBehaviour
{
    [SerializeField] private GameObject star;
    public void SowhanStar()
    {
        Instantiate(star, transform);
    }
}

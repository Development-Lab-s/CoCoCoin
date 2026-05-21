using UnityEngine;
using UnityEngine.UI;

public class EffectGOJO : MonoBehaviour
{
    private Image image;
    private void Awake()
    {
        image = GetComponent<Image>();
    }

    private void Update()
    {
        Color color = image.color;
        if (color.a < 255)
        {
            color.a += Time.deltaTime;
        }
        image.color = color;
    }
}

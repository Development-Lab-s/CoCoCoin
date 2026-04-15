using UnityEngine;

public class MaxTextSetting : MonoBehaviour
{
    private float time = 3.0f;

    // Update is called once per frame
    void Update()
    {
        if(gameObject.activeSelf == true)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                gameObject.SetActive(false);
                time = 3.0f;
            }
        }
        
    }
}

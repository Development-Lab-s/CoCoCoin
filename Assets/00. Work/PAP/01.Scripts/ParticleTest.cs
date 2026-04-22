using UnityEngine;

public class ParticleTest : MonoBehaviour
{
    [SerializeField] ParticleSystem particle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        particle.Stop();
        particle.Play();
    //이거 기능 만들어!!!!
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

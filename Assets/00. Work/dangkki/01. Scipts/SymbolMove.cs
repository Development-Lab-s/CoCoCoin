using UnityEngine;

public class SymbolMove : MonoBehaviour
{
    public float speed = 3f;

    // Update is called once per frame
    private void Update()
    {
        transform.position += new Vector3(0, -1, 0) * speed * Time.deltaTime;
    }

}

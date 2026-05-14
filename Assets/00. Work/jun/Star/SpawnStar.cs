using UnityEngine;

namespace _00._Work.jun.Star
{
    public class SpawnStar : MonoBehaviour
    {
        public GameObject prefab;

        public void Spawn()
        {
            Instantiate(prefab, transform.position, transform.rotation);
        }
    }
}
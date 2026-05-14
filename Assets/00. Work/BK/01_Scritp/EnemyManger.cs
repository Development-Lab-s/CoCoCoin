using UnityEngine;

public class EnemyManger : MonoBehaviour
{
    Player player;
    private void Awake()
    {
        player=GetComponent<Player>();
    }
    private void Update()
    {
        GameData.instance.playerCurrentHp -= 10;
    }
}

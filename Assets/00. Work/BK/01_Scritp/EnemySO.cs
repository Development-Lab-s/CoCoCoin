using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemySO", menuName = "Scriptable Objects/EnemySO")]
public class EnemySO : ScriptableObject
{
    public string enemyName = "몬스터";
    public int maxHp = 50;
    public int attackPower = 10;
    public Sprite sprite;
    
}

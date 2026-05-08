using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Objects/EnemyData")]
public class EnemyData : ScriptableObject
{
    public Sprite enemySprite;
    public int Health;
    
    public List<string> patternName = new List<string>();
    public List<int> damage = new List<int>();
}

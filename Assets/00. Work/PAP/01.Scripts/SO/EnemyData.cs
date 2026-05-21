using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Objects/EnemyData")]
public class EnemyData : ScriptableObject
{
    public Sprite enemySprite;
    public int Health;
    public Sprite hitSprite;
    public Sprite readyToAttack;
    public Sprite Attack;
    [TextArea(10,20)] public string Title;
    
    public List<string> patternName = new List<string>();
    public List<int> damage = new List<int>();

    public bool isLast = false;
    public AudioResource Theme;
}

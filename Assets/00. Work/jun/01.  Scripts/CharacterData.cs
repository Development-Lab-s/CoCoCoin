using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacter", menuName = "Battle/CharacterData")]
public class CharacterData : ScriptableObject
{
    public string unitName;
    public int maxHp;
    public int attackPower;
}

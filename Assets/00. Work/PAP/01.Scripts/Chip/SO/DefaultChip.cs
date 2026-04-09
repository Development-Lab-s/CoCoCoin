using UnityEngine;

[CreateAssetMenu(fileName = "DefaultChip", menuName = "Scriptable Objects/DefaultChip")]
public class DefaultChip : ChipEncounter
{
    public override void Initialize()
    {
        headChance = 50;
    }
    public override void HeadChip(Flip flipScript)
    {
        Debug.Log("Deal 10 damage to the enemy.");
        flipScript.SpinSuccess();
    }

    public override void TailChip(Flip flipScript)
    {
        Debug.Log("Defensed 10 damage for this turn");
        flipScript.SpinFailed();
    }
}

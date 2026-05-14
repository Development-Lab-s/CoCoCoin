using UnityEngine;

namespace _00._Work.PAP._01.Scripts.Chip.SO.Combo
{
    [CreateAssetMenu(fileName = "DamageMultiplierChip", menuName = "ChipEncounterSO/DamageMultiplierChip", order = 0)]
    public class DamageMultiplierChip : ChipEncounter
    {
        public override void HeadChip(Player player, Enemy enemy)
        {
            StatusEffect status = new DamageMutliply();
            player.statusEffectHandler.AddStatusEffect(status,77);
        }

        public override void TailChip(Player player, Enemy enemy)
        {
            player.combo.SetCombo(3);
            StatusEffect status = new RemoveCombo();
            player.statusEffectHandler.AddStatusEffect(status,2);
        }
    }
}
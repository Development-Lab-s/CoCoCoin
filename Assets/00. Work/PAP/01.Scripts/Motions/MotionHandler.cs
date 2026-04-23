using System;
using System.Collections;
using Unity.Cinemachine;
using UnityEditor.Animations;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class MotionHandler : MonoBehaviour
{
    [SerializeField] CinemachineImpulseSource impulseSource;
    public void PlayMotion(bool isHead,Player player, Enemy enemy,ChipEncounter chip,int headChipMotion,int tailChipMotion)
    {
        switch (isHead ? headChipMotion : tailChipMotion)
        {
            case 0:
                StartCoroutine(NormalPunchMotion(player, enemy, chip,isHead));
                break;
            case 1:
                StartCoroutine(DefenseMotion(player, enemy, chip,isHead));
                break;
        }
    }

    private void ChipAbility(Player player, Enemy enemy, ChipEncounter chip, bool isHead)
    {
        if (isHead)
        {
            chip.HeadChip(player, enemy);
        }
        else
        {
            chip.TailChip(player, enemy);
        }
    }


    private IEnumerator NormalPunchMotion(Player player, Enemy enemy,ChipEncounter chip,bool isHead)
    {
        yield return new WaitForSeconds(1);
        impulseSource.GenerateImpulseWithVelocity(new Vector3(0.2f, 0, 0));
        ChipAbility(player, enemy, chip, isHead);
        BattleManager.instance.isActive = true;
        BattleManager.instance.currentState = BattleManager.State.PlayerTurn;
    }
    private IEnumerator DefenseMotion(Player player, Enemy enemy,ChipEncounter chip, bool isHead)
    {
        yield return new WaitForSeconds(0.5f);
        ChipAbility(player, enemy, chip, isHead);
        BattleManager.instance.isActive = true;
        BattleManager.instance.currentState = BattleManager.State.PlayerTurn;
    }
}

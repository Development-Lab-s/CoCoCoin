using System;
using System.Collections;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using Object = UnityEngine.Object;

[CreateAssetMenu(fileName = "Nya", menuName = "ChipEncounterSO/Nya")]
public class Nya : ChipEncounter
{
    [SerializeField] private GameObject NaviEffect;
    [SerializeField] private CinemachineImpulseSource impulseSource;
    
    public override void HeadChip(Player player, Enemy enemy)
    {
        GameData.instance.playerCurrentHp = 100;
        player.displayHP = 100;
        player.UpdateUI();
    }

    public override void TailChip(Player player, Enemy enemy)
    {
        CoroutineRunner.instance.StartCoroutine(Navi(player));
    }

    private IEnumerator Navi(Player plr)
    {
        GameObject effect = Instantiate(NaviEffect, Vector3.zero, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        plr.TakeDamage(50);
        impulseSource.GenerateImpulseWithForce(2f);
        yield return new WaitForSeconds(2f);
        Destroy(effect);
    }
}

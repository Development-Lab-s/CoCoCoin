using System.Collections;
using DG.Tweening;
using Unity.Cinemachine;
using UnityEngine;

public class EnemyMotionHandler : MonoBehaviour
{
    [SerializeField] CinemachineImpulseSource impulseSource;
    [SerializeField] Player player;
    [SerializeField] private Transform soundManager;
    [SerializeField] private CurrentEnemySetting currentEnemy;
    public IEnumerator PlayMotion(string motionName,int attackPower)
    {
        yield return StartCoroutine(motionName,attackPower);
    }

    private IEnumerator Normal(int attackPower)
    {
        yield return new WaitForSeconds(0.5f);
        impulseSource.GenerateImpulseWithForce(attackPower / 10f);
        player.TakeDamage(attackPower);
        soundManager.Find("Swoosh").GetComponent<AudioSource>().Play();
        soundManager.Find("Stab").GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.5f);
    }

    private IEnumerator Combo(int attackPower)
    {
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(0.2f);
            impulseSource.GenerateImpulseWithForce(attackPower / 10f /3f);
            player.TakeDamage(attackPower/3);
        }
        yield return new WaitForSeconds(0.5f);
    }
}

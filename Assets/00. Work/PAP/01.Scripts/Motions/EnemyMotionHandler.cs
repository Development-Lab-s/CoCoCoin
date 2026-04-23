using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class EnemyMotionHandler : MonoBehaviour
{
    [SerializeField] CinemachineImpulseSource impulseSource;
    [SerializeField] Player player;
    public IEnumerator PlayMotion(string motionName,int attackPower)
    {
        yield return StartCoroutine(motionName,attackPower);
    }

    private IEnumerator Normal(int attackPower)
    {
        yield return new WaitForSeconds(1.0f);
        impulseSource.GenerateImpulseWithForce(attackPower / 10f);
        player.TakeDamage(attackPower);
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

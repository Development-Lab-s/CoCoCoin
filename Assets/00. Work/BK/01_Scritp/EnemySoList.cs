using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemySoList", menuName = "Scriptable Objects/EnemySoList")]
public class EnemySoList : ScriptableObject
{
    public List<EnemySO> enemySos;
    public List<EnemySO> enemyEnemySos;

    [ContextMenu("practice")]
    public void Restart()
    {
        enemySos.Clear();
        for(int i = 0; i < enemyEnemySos.Count; i++)
        {
            enemySos.Add(enemyEnemySos[i]);
        }
    }

    public EnemySO PopEnemyData()
    {
        int index = Random.Range(0,enemySos.Count);
        EnemySO enemy = enemySos[index];
        enemySos.RemoveAt(index); // 중복 제거
        return enemy;
    }
}

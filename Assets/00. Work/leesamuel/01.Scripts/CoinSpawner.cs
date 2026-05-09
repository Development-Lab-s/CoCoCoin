using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private List<CoinData> coinPool = new List<CoinData>();
    [SerializeField] private float spawnTime = 0.3f;
    [SerializeField] private GameObject spawnPoint; // 코인이 실제로 나타날 물리적 위치

    private IEnumerator Start()
    {
        int count = Random.Range(4, 8);
        float x = (count == 4) ? -6f : (count == 5) ? -7f : (count == 6) ? -4f : -6f;
        float gap = (count == 4) ? 4f : (count == 5) ? 3.5f : (count == 6) ? 4f : 2f;

        for (int i = 0; i < count; i++)
        {
            float y = 0;
            if (count == 5) y = (i >= 1 && i <= 3) ? 1f : -1f;
            else if (count == 6) y = (i % 2 == 0) ? 2f : -2f;
            else if (count == 7) y = (i % 2 == 1) ? 1f : -1f;

            transform.position = new Vector3(x, y, 0); // 스포너 위치 이동
            SpawnRandomCoin();

            if (!(count == 6 && i % 2 == 0)) x += gap;
            yield return new WaitForSeconds(spawnTime);
        }
    }

    public void SpawnRandomCoin()
    {
        if (coinPool.Count == 0) return;

        // 리스트에서 무작위 데이터 선택
        int randIndex = Random.Range(0, coinPool.Count);
        CoinData selectedData = coinPool[randIndex];

        // 생성 (spawnPoint가 있다면 그 위치에, 없다면 스포너 현재 위치에 생성)
        Vector3 pos = spawnPoint != null ? spawnPoint.transform.position : transform.position;
        GameObject coinObj = Instantiate(selectedData.prefab, pos, Quaternion.identity);

        // 생성된 코인의 CoinDrag 컴포넌트를 찾아 SO 주입
        CoinDrag dragScript = coinObj.GetComponent<CoinDrag>();
        if (dragScript != null)
        {
            dragScript.Setup(selectedData.SO);
        }
    }
}
[System.Serializable]
public class CoinData
{
    public GameObject prefab;
    public InventoryItemSO SO; 
}
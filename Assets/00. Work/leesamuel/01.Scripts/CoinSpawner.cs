using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using System.Threading.Tasks;

public class CoinSpawner : MonoBehaviour
{
    private int _Number_of_coins;
    private float X = 0;
    private float Y = 0;
    [SerializeField] private GameObject Coin_Spown_point;
    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] List<InventoryItemSO> _commonCoinDatas = new List<InventoryItemSO>();
    [SerializeField] List<InventoryItemSO> _rareCoinDatas = new List<InventoryItemSO>();
    [SerializeField] List<InventoryItemSO> _legendaryCoinDatas = new List<InventoryItemSO>();
    private int Rarity_probability;
    private int CoinType;
    private float _spawnTime =0.3f;
    

    public int Common_probability = 100;//확률 설정 무조건 총합"100"이어야함
    public int Rare_probability = 0;
    public int Legendery_probability = 0;


    public void CoinSpawn()//랜덤 희귀도의 랜덤코인을 "생성"까지 해줌
    {
        Rare_probability += Common_probability;
        Legendery_probability += Rare_probability;
        Rarity_probability = Random.Range(1, 101);
        GameObject Coin = Instantiate(_coinPrefab); //코인 생성
        if (0 < Rarity_probability && Common_probability >= Rarity_probability)
        {
            Coin.GetComponent<CoinDrag>().Init(_rareCoinDatas[Random.Range(0, _rareCoinDatas.Count)]);
        }
        else if (Rare_probability >= Rarity_probability)//Rare등급 코인 
        {
            Coin.GetComponent<CoinDrag>().Init(_rareCoinDatas[Random.Range(0, _rareCoinDatas.Count)]);
        }
        else if (Legendery_probability >= Rarity_probability)//Legendary등급 코인 
        {

        }
        Coin.transform.position = Coin_Spown_point.transform.position;
    }
    private IEnumerator Start()
    {
        _Number_of_coins = Random.Range(4, 8);
        if (_Number_of_coins == 4)
        {

            X = -6;
            for (int i = 0; i < _Number_of_coins; i++)
            {
                Y = 0;
                transform.position = new Vector3(X, Y, 0);//좌표 수정
                X += 4;
                CoinSpawn();
                yield return new WaitForSeconds(_spawnTime);
            }
        }
        else if (_Number_of_coins == 5)
        {
            X = -6;

            for (int i = 0; i < _Number_of_coins; i++)
            {
                {
                    Y = -1;
                    if (i >= 1 && i <= 3)
                    {
                        Y = 1;
                    }

                    transform.position = new Vector3(X, Y, 0);//좌표 수정
                    X += 3f;
                    CoinSpawn();
                    yield return new WaitForSeconds(_spawnTime);
                }
            }
        }
        else if (_Number_of_coins == 6)
        {
            X = -4;
            Y = -2;

            for (int i = 0; i < (_Number_of_coins / 2); i++)
            {
                for (int j = 0; j < 2; j++)
                {

                    Y *= -1;
                    transform.position = new Vector3(X, Y, 0);//좌표 수정
                    CoinSpawn();
                    yield return new WaitForSeconds(_spawnTime);
                }
                X += 4;
            }
        }

        else if (_Number_of_coins == 7)
        {
            X = -6;

            for (int i = 0; i < _Number_of_coins; i++)
            {
                Y = -1;
                if (i % 2 == 1)
                {
                    Y = 1;
                }

                transform.position = new Vector3(X, Y, 0);//좌표 수정
                X += 2;
                CoinSpawn();
                yield return new WaitForSeconds(_spawnTime);
            }
        }
    }
}

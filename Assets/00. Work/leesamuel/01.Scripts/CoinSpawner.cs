using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Threading.Tasks;

public class CoinSpawner : MonoBehaviour
{

    private int _Number_of_coins;
    private float X = 0;
    private float Y = 0;//Y좌표 사용 대비
    public GameObject CoinPrefeb;
    public GameObject Coin_Spown_point;
    public float Rarity;

    public void CoinSpawn(string CoinPrefeb)
    {

    }
    private void Start()
    {
        _Number_of_coins = Random.Range(4,7);
        if(_Number_of_coins ==4)
        {

        }
        else if(_Number_of_coins == 5)//떨구는 코인량 랜덤되면 복붙할것
        {
            X = -7;

            for (int i = 0; i < _Number_of_coins; i++)
            {
                Y = -1;
                if (i >= 1 && i <= 3)
                {
                    Y = 1;
                }
                
                transform.position = new Vector3(X, Y, 0);//좌표 수정
                X += 3.5f;
                GameObject Coin = Instantiate(CoinPrefeb); //코인 생성
                Coin.transform.position = Coin_Spown_point.transform.position;
            }
        }
        else if (_Number_of_coins == 6)
        {

           //
        }

        else if (_Number_of_coins < 7)
        {

        }
    }
}

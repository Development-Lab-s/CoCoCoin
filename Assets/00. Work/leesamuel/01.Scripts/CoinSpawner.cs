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
    private float Y = 0;
    [SerializeField] private GameObject NormarCoinPrefeb;//생성할 코인 프레펩
    [SerializeField] private GameObject RedCoinPrefeb;
    [SerializeField] private GameObject Coin_Spown_point;
    private int Rarity_probability;
    private int CoinType;
    private GameObject _CoinName;


    public int Common_probability=100;//확률 설정 무조건 총합"100"이어야함
    public int Rare_probability=0;
    public int Epic_probability=0;


    public void CoinSpawn()//랜덤 희귀도의 랜덤코인을 "생성"까지 해줌
    {
        Rare_probability += Common_probability;
        Epic_probability += Rare_probability;
        Rarity_probability =Random.Range(1,101);
        if(0< Rarity_probability && Common_probability >=Rarity_probability)
        {
            CoinType = Random.Range(0, 2);  //common등급 코인 
            if (CoinType == 0)
            {
                _CoinName = NormarCoinPrefeb;
            }
            else if (CoinType == 1)
            {
                _CoinName =RedCoinPrefeb;
            }
        }
        else if(Common_probability < Rarity_probability&& Rare_probability >= Rarity_probability)//Rare등급 코인 
        {

        }
        else if(Rare_probability < Rarity_probability&& Epic_probability >= Rarity_probability)//Epic등급 코인 
        {

        }
        GameObject Coin = Instantiate(_CoinName); //코인 생성
        Coin.transform.position = Coin_Spown_point.transform.position;
    }
    private void Start()
    {
        _Number_of_coins = Random.Range(4,8);
        if(_Number_of_coins ==4)
        {
           
            X = -6;
            for (int i = 0; i < _Number_of_coins; i++)
            {
                Y = 0;
                transform.position = new Vector3(X, Y, 0);//좌표 수정
                X += 4;
                CoinSpawn();
            }
        }
        else if(_Number_of_coins == 5)
        {
            X = -7;

            for (int i = 0; i < _Number_of_coins; i++)
            {
                {
                    Y = -1;
                    if (i >= 1 && i <= 3)
                    {
                        Y = 1;
                    }

                    transform.position = new Vector3(X, Y, 0);//좌표 수정
                    X += 3.5f;
                    CoinSpawn();
                }
            }
        }
        else if (_Number_of_coins == 6)
        {
            X = -4;
            Y = -2;

            for (int i = 0; i < (_Number_of_coins/2); i++)
            {
                for(int j = 0;j < 2;j++)
                {
                    Y *= -1;
                    transform.position = new Vector3(X, Y, 0);//좌표 수정
                    CoinSpawn();
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
            }
        }
    }
}

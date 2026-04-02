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
    [SerializeField] private GameObject NormarCoinPrefeb;//
    [SerializeField] private GameObject RedCoinPrefeb;
    [SerializeField] private GameObject Coin_Spown_point;
    private int Rarity_probability;
    private int CoinType;
    private GameObject _CoinName;


    public int Common_probability=100;//등급 갯수=변수갯수,변수값 1올라갈때마다 100분율 확률로 1%올라감,등급 확률이 "모두 합쳐서" 100이 되게 하기 
    public int Rare_probability=0;//등급갯수 추가하고 싶으면 변수하나 새로 만들고 만든 변수에 전 등급 더하는 코드 메서드 안에 적기,가장 및 elseif의 등급이름들참고해서 만들어오기
    public int Epic_probability=0;


    public void CoinSpawn(string CoinPrefeb)
    {
        Rare_probability += Common_probability;
        Epic_probability += Rare_probability;
        Rarity_probability =Random.Range(1,101);
        if(0< Rarity_probability && Common_probability >=Rarity_probability)
        {
            CoinType = Random.Range(0, 2);  
            if (CoinType == 0)
            {
                _CoinName = NormarCoinPrefeb;
            }
            else if (CoinType == 1)
            {
                _CoinName =RedCoinPrefeb;
            }
        }
        else if(Common_probability < Rarity_probability&& Rare_probability >= Rarity_probability)
        {

        }
        else if(Rare_probability < Rarity_probability&& Epic_probability >= Rarity_probability)
        {

        }
        GameObject Coin = Instantiate(_CoinName); //코인 생성
        Coin.transform.position = Coin_Spown_point.transform.position;
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

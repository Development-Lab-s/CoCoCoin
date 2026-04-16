using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData instance;
    public int playerCurrentHp = 100;
    public int playerMaxHp = 100;
    public int amountDrawOnce = 5;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}

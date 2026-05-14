using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData instance;
    public int playerCurrentHp = 100;
    public int amountDrawOnce = 5;
    public int amountDrawMax = 10;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

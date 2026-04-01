using UnityEngine;
using TMPro;

public class HPTextBar : MonoBehaviour
{
    public TextMeshProUGUI hpText;

    public int maxHP = 10;
    public int currentHP;

    void Start()
    {
        currentHP = maxHP;
        UpdateHP();
    }

    void UpdateHP()
    {
        string bar = "";

        for (int i = 0; i < currentHP; i++)
            bar += "■";

        for (int i = currentHP; i < maxHP; i++)
            bar += "□";

        hpText.text = bar;
    }

    public void TakeDamage(int dmg)
    {
        currentHP -= dmg;
        if (currentHP < 0) currentHP = 0;

        UpdateHP();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(1);
        }

       
    }
}
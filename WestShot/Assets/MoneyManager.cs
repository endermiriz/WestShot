using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public Text moneyText;
    int money = 0;
    void Start()
    {
        moneyText.text = "MONEY: " + money.ToString();
    }

    public void SetMoney()
    {
        money += 1;
        moneyText.text = "MONEY: " + money.ToString();
    }

}

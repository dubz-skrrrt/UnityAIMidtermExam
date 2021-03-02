using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MoneyUI : MonoBehaviour
{
    public Text MoneyText;

    void Update()
    {
        MoneyText.text = "$" + GameSystem.money.ToString();
    }
}

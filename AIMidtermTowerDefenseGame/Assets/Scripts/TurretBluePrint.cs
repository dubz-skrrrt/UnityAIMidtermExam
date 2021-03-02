using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretBluePrint
{
    public GameObject prefab;
    public GameObject upgradedPrefab;
    public int upgradeCost;
    public int Cost;

    public int GetSellAmount()
    {

        return Cost/2;
    }

    public int GetSellUpgradedAmount()
    {
        
        return (int)((Cost/2) +  (upgradeCost*0.25f));
    }
}

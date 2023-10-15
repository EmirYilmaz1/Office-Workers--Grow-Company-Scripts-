using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public event Action OnMoneyChange; 

   [SerializeField] private int currentMoney;
    public int CurrentMoney{get{return currentMoney;} set{currentMoney = value; OnMoneyChange?.Invoke();}}

    public bool CanBuy(int cost)
    {
        if(CurrentMoney-cost>=0)
        {
            CurrentMoney -= cost;
            return true;
        }

        return false;
    }
}

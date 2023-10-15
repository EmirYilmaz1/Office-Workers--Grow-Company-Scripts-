using TMPro;
using UnityEngine;

public class MoneyText : MonoBehaviour 
{
    private TextMeshProUGUI moneyTextUI;
    private MoneyManager moneyManager;
    private void Awake()
    {
        moneyManager = FindObjectOfType<MoneyManager>();
        moneyTextUI = GetComponent<TextMeshProUGUI>();
        SetMoneyText();
        moneyManager.OnMoneyChange += SetMoneyText;
    }

    private void SetMoneyText()
    {
        moneyTextUI.text = moneyManager.CurrentMoney.ToString();
    }
}
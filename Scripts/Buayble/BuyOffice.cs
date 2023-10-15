using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public sealed class BuyOffice : Buyable
{
    [SerializeField] private GameObject worker;
    private void Awake() 
    {
        buaybleThing = worker;
        GetComponent<TextMeshPro>().text = $"Desk: {cost}";
    }

    protected override void AfterBought()
    {
        Destroy(this.gameObject);
    }
}

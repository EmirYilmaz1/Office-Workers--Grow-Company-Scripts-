using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HireAssistant : Buyable
{
    [SerializeField] private GameObject assistant;

    private void Awake() 
    {
        buaybleThing = assistant;
        GetComponent<TextMeshPro>().text =$"Staff: {cost}";
    }

    protected override void AfterBought()
    {
        return;
    }

}


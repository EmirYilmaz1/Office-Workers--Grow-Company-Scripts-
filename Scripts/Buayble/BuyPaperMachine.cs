using TMPro;
using UnityEngine;

public sealed class BuyPaperMachine : Buyable
{
    [SerializeField] private GameObject PaperMachine;

    private void Awake() 
    {
        buaybleThing = PaperMachine;    
        GetComponent<TextMeshPro>().text = $"Printer: {cost}";
    }

    
    protected override void AfterBought()
    {
        Destroy(this.gameObject);
    }
}
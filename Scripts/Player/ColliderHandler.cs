using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class ColliderHandler : MonoBehaviour
{
    public event Action OnCollectPaper;
    public event Action OnGivePaper;
    public event Action OnLeaveTrigger;

    [SerializeField] private bool isPlayer;
    public GameObject Object {get; set;}

    private MoneyManager moneyManager;
    private Animator animator;
    

    private void Awake() 
    {
       moneyManager = GetComponent<MoneyManager>();  
       animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("PaperMachine"))
        {
            Object = other.gameObject;
            if(!isPlayer)
            {
                animator.SetBool("isWalking", false);
            }
            OnCollectPaper?.Invoke();
        }

        if(other.gameObject.CompareTag("Worker"))
        {
            Object = other.gameObject;
            if(!isPlayer)
            {
                animator.SetBool("isWalking", false);
            }
            OnGivePaper?.Invoke();
        }

        if(isPlayer&&other.gameObject.CompareTag("Buyable"))
        {
            if(other.TryGetComponent<Buyable>(out Buyable component))
            {
                if(moneyManager.CanBuy(component.cost))
                {
                    component.Buy();
                }
            }
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.CompareTag("PaperMachine"))
        {
             OnLeaveTrigger?.Invoke();
        }
        if(other.gameObject.CompareTag("Worker"))
        {
            OnLeaveTrigger?.Invoke();
        }

        OnLeaveTrigger?.Invoke();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStateMachine : MonoBehaviour
{
    private PaperManager paperManager;
    private PaperMachine paperMachine;
    private ColliderHandler colliderHandler;
    private AIMovement aIMovement;
    private Animator animator;


    private int currentIndex;
    private int lastIndex = 0;
    private void Start() 
    {
        animator = GetComponent<Animator>();
        paperMachine = FindObjectOfType<PaperMachine>();
        paperManager = GetComponent<PaperManager>();
        colliderHandler = GetComponent<ColliderHandler>();
        aIMovement = GetComponent<AIMovement>();

        GetPapersState();

        paperManager.OnPaperColected += GivePapersState;
        paperManager.OnPaperGave += GivePapersState;
        paperManager.OnPapersFinished += GetPapersState;
    }

    private void Update() {
        
    }

    public void GetPapersState()
    {
        aIMovement.Move(paperMachine.transform.position);
        animator.SetBool("isWalking", true);
    }

    public void GivePapersState()
    {
       Worker[] workers = FindObjectsOfType<Worker>();
       do
       {
        currentIndex = UnityEngine.Random.RandomRange(0,workers.Length-1);
       } 
       while (currentIndex==lastIndex);
       lastIndex = currentIndex;
       animator.SetBool("isWalking", true);
       aIMovement.Move(workers[currentIndex].transform.position);
    }
}

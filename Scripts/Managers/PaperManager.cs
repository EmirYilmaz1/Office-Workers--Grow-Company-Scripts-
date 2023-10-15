using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PaperManager : MonoBehaviour
{
    public event Action OnPaperColected;
    public event Action OnPaperGave;
    public event Action OnPapersFinished;

    [SerializeField] private GameObject paperPrefab;
    [SerializeField] private Transform hand;

    private GameObject[] papersColected = new GameObject[10];

    private int currentPaper;
    private ColliderHandler colliderHandler;

    private PaperMachine paperMachine;
    private Worker worker;

    private bool canCollect;
    private bool canGive;

    private void Awake() 
    {
        CreatePaper();
        colliderHandler =  GetComponent<ColliderHandler>();
        colliderHandler.OnCollectPaper += CollectPapers;
        colliderHandler.OnGivePaper += GivePapers;
        colliderHandler.OnLeaveTrigger +=() =>{canCollect = false; canGive = false;};
    }
    
    private void CollectPapers()
    {
       
        if(colliderHandler.Object.TryGetComponent<PaperMachine>(out PaperMachine component))
        {
            paperMachine = component;
            StartCoroutine(CollectSequence());
            canCollect = true;      
        }
    }

    private void GivePapers()
    {
        if(colliderHandler.Object.TryGetComponent<Worker>(out Worker component))
        {
            worker = component;
            canGive = true;

            if(!worker.CanGetPaper()) return;

            StartCoroutine(GiveSequence());
        }
    }

    private IEnumerator GiveSequence()
    {
        if(currentPaper-1<0)
        {
            canCollect = false;
            OnPapersFinished?.Invoke();
            yield break;
        }


        worker.GetPaper();
        papersColected[currentPaper-1].SetActive(false);
        currentPaper--;
        yield return new WaitForSeconds(.3f);
        CanGivePaper();
    }

    private IEnumerator CollectSequence()
    {
        if(currentPaper>=papersColected.Length)
        {
            OnPaperColected?.Invoke();
            yield break;
        }

        if(paperMachine.CanGetPaper())
        {
            papersColected[currentPaper].SetActive(true);
            currentPaper++;
        }
        yield return new WaitForSeconds(0.3f);
        CanCollectPaper();
    }

    private void CanCollectPaper()
    {
        if(canCollect)
        {
            StartCoroutine(CollectSequence());
        }
    }

    private void CanGivePaper()
    {
        if(!worker.CanGetPaper()) 
        {
            OnPaperGave?.Invoke();
            return;
        }

        if(canGive)
        {
            StartCoroutine(GiveSequence());
        }
    }

    private void CreatePaper()
    {
        for(int i = 0; i<papersColected.Length; i++)
        {
            GameObject paper = Instantiate(paperPrefab,new Vector3(hand.position.x,hand.position.y+(i*.05f),hand.position.z),Quaternion.identity,hand);
            paper.SetActive(false);
            papersColected[i] = paper;
        }
    }

}

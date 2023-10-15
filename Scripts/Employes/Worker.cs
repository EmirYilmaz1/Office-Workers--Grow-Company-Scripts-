using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : MonoBehaviour
{
    [SerializeField] private Transform deskHolder;
    [SerializeField] private GameObject paperPrefab;

    private List<GameObject> papers = new List<GameObject>();
    
    private int currentPaper;
    private int canWork;
    private float workingTime;

    private bool isWorking =  false;

    private void Awake() 
    {
        CreatePaper();
        FindObjectOfType<LevelManager>().IncreaseOpenedDesk();
    }

    private void Update() 
    {
        if(isWorking)
        {
            workingTime += Time.deltaTime;

            if(workingTime>2)
            {
                currentPaper--;
                papers[currentPaper].SetActive(false);
                workingTime = 0;
                if(currentPaper == 0) isWorking = false;
                FindObjectOfType<MoneyManager>().CurrentMoney += 10;
            }
        }
    }

    public void GetPaper()
    {
        papers[currentPaper].SetActive(true);
        currentPaper++;
        isWorking = true;
    }

    public bool CanGetPaper()
    {
        if(currentPaper>=8)
        {
            return false;
        }
        return true;
    }

    private void CreatePaper()
    {
        for(int i = 0; i<8; i++)
        {
            Vector3 pos = new Vector3(deskHolder.position.x,deskHolder.position.y+(i*.05f),deskHolder.position.z);
            GameObject paper = Instantiate(paperPrefab,pos,Quaternion.identity,deskHolder);
            papers.Add(paper);
            paper.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PaperMachine : MonoBehaviour
{
    [SerializeField] private GameObject paperPrefab;
    [SerializeField] private Transform printArea;
    [SerializeField] private float printTime = 2f;


    private float time;
    private int printedPapers;
    private List<GameObject> papers = new List<GameObject>();

    void Awake()
    {
        CreatePaper();
    }
  
    void Update()
    {
        time += Time.deltaTime;

        if(time>printTime)
        {
            PrintThePaper();
            time = 0;
        }
    }

    private void CreatePaper()
    {
        for(int i = 0; i<20; i++)
        {
            GameObject paper = Instantiate(paperPrefab,transform.position,Quaternion.identity,transform);
            paper.SetActive(false);
            papers.Add(paper);
        }
    }

    private void PrintThePaper()
    {
        if(printedPapers == papers.Count) return;

        foreach(GameObject paper in papers)
        {
            if(!paper.activeInHierarchy)
            {
                paper.SetActive(true);
                paper.transform.position = new Vector3(printArea.position.x,printArea.position.y+(printedPapers*0.05f), printArea.position.z);
                printedPapers++;
                break;
            }
        }
    }

    public bool CanGetPaper()
    {


        for(int i = papers.Count; i>0 ;i--)
        {
            if(papers[i-1].activeInHierarchy)
            {
                papers[i-1].SetActive(false);
                printedPapers--;   
                return true;          
            }
        }

        return false;
    }

}

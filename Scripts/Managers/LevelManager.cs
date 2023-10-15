using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    
    public event Action OnTinyOfficeFinish;
    public event Action OnNormalOfficeFinish;

    private int openedDesk;

    private bool isTinyOfficeFinished = false;
    private bool isNormalOfficeFinished = false;
    
    private int openedDeskForNormalOffice = 4;
    private int openedDeskForBigOffice = 8;
    public void IncreaseOpenedDesk()
    {
        openedDesk++;
        if(!isTinyOfficeFinished&openedDesk>=openedDeskForNormalOffice)
        {
           isTinyOfficeFinished = true;
           OnTinyOfficeFinish?.Invoke();
           return;
        }
        if(!isNormalOfficeFinished&&openedDesk>=openedDeskForBigOffice)
        {
            isNormalOfficeFinished = true;
            OnNormalOfficeFinish?.Invoke();
            return;
        }

    }  

}

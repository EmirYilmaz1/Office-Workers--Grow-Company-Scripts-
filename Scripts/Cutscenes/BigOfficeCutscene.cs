using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class BigOfficeCutscene : MonoBehaviour
{
    private PlayableDirector playableDirector;
    private LevelManager levelManager;
    void Start()
    {
       playableDirector = GetComponent<PlayableDirector>();
       LevelManager levelManager =  FindObjectOfType<LevelManager>();
       levelManager.OnNormalOfficeFinish += () =>StartCoroutine(BigOfficeSeqence());
    }

    private IEnumerator BigOfficeSeqence()
    {
        playableDirector.Play();
        yield return new WaitForSecondsRealtime((float)playableDirector.duration);
    }


}

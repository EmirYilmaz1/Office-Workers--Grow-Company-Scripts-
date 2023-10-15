using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class OfficeCutscene : MonoBehaviour
{
    private PlayableDirector playableDirector;
    private LevelManager levelManager;

    void Awake()
    {
        playableDirector = GetComponent<PlayableDirector>();
        levelManager = FindObjectOfType<LevelManager>();
        levelManager.OnTinyOfficeFinish += () => StartCoroutine(CutsceneSequence());
    }

    IEnumerator CutsceneSequence()
    {
        playableDirector.Play();
        yield return new WaitForSecondsRealtime((float)playableDirector.duration);
         levelManager.OnTinyOfficeFinish -= () => StartCoroutine(CutsceneSequence());
                
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalOfficeDoor : MonoBehaviour
{
    private LevelManager levelManager;
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        levelManager.OnNormalOfficeFinish += DestroySequence;
    }

    private void DestroySequence()
    {
        levelManager.OnNormalOfficeFinish -= DestroySequence;
        Destroy(this.gameObject);
    }
}

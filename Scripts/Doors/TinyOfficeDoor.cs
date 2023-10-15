using UnityEngine;

public class TinyOfficeDoor : MonoBehaviour 
{
    private LevelManager levelManager;
    private void Awake() 
    {
        levelManager = FindObjectOfType<LevelManager>();
        levelManager.OnTinyOfficeFinish += DestroySequence;
    }

    private void DestroySequence()
    {   
        levelManager.OnTinyOfficeFinish -= DestroySequence;
        Destroy(this.gameObject);
    }
}
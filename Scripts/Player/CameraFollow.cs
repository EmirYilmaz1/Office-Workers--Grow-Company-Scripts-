using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class CameraFollow : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    private Transform targetTransform;
    void Start()
    {
       targetTransform = FindObjectOfType<PlayerMovement>().gameObject.transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, targetTransform.position+offset,Time.deltaTime*3);
    }
}

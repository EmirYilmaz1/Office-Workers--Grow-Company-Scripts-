using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;

    private Touch touch;
    private Animator animator;

    private Vector3 firstTouchPosition;
    private Vector3 lastTouchPosition;

    private bool isDragging;

   private void Awake() 
   {
        animator = GetComponent<Animator>(); 
   }


    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount>0)
        {
            touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                firstTouchPosition = touch.position;

                isDragging = true;
                animator.SetBool("isWalking", true);
            }
        }

        if(isDragging == true)
        {
            if(touch.phase == TouchPhase.Moved)
            {
                lastTouchPosition = touch.position;
            }
            else if(touch.phase == TouchPhase.Ended)
            {
                lastTouchPosition = touch.position;
                isDragging = false;
                animator.SetBool("isWalking", false);
            }
            transform.rotation = Quaternion.RotateTowards(transform.rotation,CalculateRotation(),10);
            transform.Translate(Vector3.forward*Time.deltaTime*movementSpeed);
        }
    }

    private Quaternion CalculateRotation()
    {
        Quaternion rotation = Quaternion.LookRotation(CalculateDirection(),Vector3.up);
        return rotation;
    }

    private Vector3 CalculateDirection()
    {
        Vector3 direction = (lastTouchPosition-firstTouchPosition);
        direction.z = direction.y;
        direction.y = 0;
        return direction;
    }
}


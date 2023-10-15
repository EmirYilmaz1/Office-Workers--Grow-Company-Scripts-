using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Buyable : MonoBehaviour
{
    protected GameObject buaybleThing;
    public int cost;

    public void Buy()
    {

        Instantiate(buaybleThing, new Vector3(transform.position.x, 0, transform.position.z), Quaternion.identity);
        AfterBought();
    }

    protected  abstract void AfterBought();

}

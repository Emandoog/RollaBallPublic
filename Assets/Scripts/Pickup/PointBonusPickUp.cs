using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PointBonusPickUp : PickUp
{
    public static event Action OnPointGet;
   

   
    public override void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {

            Interact();
            Destroy(gameObject);
        }

    }

    public override void OnTriggerExit(Collider other)
    {

    }


    public override void Interact()
    {
        OnPointGet?.Invoke();
    }
}

using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PointPickUp : PickUp
{
    public static event Action OnPointGet;
    public static event Action OnPointSpawn;

    private void Start()
    {
        OnPointSpawn?.Invoke();
    }
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

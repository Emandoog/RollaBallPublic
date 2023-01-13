using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class PickUp : MonoBehaviour,IInteractable
{
    public abstract  void OnTriggerEnter(Collider other);

    public abstract void OnTriggerExit(Collider other);
  
    public abstract void Interact();
    

    

}

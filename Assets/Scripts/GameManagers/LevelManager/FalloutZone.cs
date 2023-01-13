using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalloutZone : MonoBehaviour
{
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FalloutManager.Instance.BallFallout();
        
        }
    }
}

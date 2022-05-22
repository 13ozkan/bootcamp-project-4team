using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectController : MonoBehaviour
    
{
    public int sayi;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collect"))
            
        {
             
            other.gameObject.transform.position = transform.position + Vector3.forward;
            Destroy(gameObject.GetComponent<CollectController>());
            other.gameObject.AddComponent<CollectController>();
            other.gameObject.GetComponent<BoxCollider>().isTrigger = false;
            other.gameObject.AddComponent<NudeCollect>();
            other.gameObject.GetComponent<NudeCollect>().Nude = transform;
            other.gameObject.tag = "Collected";
        }
    }
}
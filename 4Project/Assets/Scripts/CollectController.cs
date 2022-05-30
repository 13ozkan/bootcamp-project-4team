using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CollectController : MonoBehaviour
    
{
    public int sayi;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collect"))
            
        {
             
            other.gameObject.transform.position = transform.position + Vector3.forward;
            sayi++;
            Destroy(gameObject.GetComponent<CollectController>());
            other.gameObject.AddComponent<CollectController>();
            other.gameObject.GetComponent<BoxCollider>().isTrigger = false;
            other.gameObject.AddComponent<NudeCollect>();
            other.gameObject.GetComponent<NudeCollect>().Nude = transform;
            other.gameObject.tag = "Collected";
            
        }

        Debug.Log("collectcontroller");
    }
}

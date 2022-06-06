using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public AnimatorOverrideController kazanmaAnimationOverride;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Collected" || other.gameObject.tag == "Player")
        {
            //kazanma animasyonuna çevir
            other.gameObject.GetComponent<Animator>().runtimeAnimatorController = kazanmaAnimationOverride;

            if(other.gameObject.GetComponent<Player>() != null)
            {
                other.gameObject.GetComponent<Player>().hiz = 0;
            }
            
        }
    }
}

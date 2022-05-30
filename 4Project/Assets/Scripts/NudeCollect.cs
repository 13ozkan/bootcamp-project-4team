using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NudeCollect : MonoBehaviour
{
    public Transform Nude;
    public int asss;



    void Update()
    {
        

            transform.position = new Vector3(
            Mathf.Lerp(transform.position.x, Nude.position.x, Time.deltaTime * 20),
            Nude.position.y,
            Nude.position.z + 1


            );

        Debug.Log("nudecollect");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pl"))
        {
            asss = 2;
        }
    }

}

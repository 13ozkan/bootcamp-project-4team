using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private void Update()
    {
        //Bubble looks at camera all the time
        transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);
    }
}


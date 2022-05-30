using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeCollect : MonoBehaviour
{
    public Transform Node; //birbirine eklenen objeler icin dugum degiskeni
    public float gecikmeHizi = 15;//Öne eklenen zombilerin x eksenindeki hareketindeki gecikme

    void LateUpdate()
    {
            transform.position = new Vector3(
            Mathf.Lerp(transform.position.x, Node.position.x, Time.deltaTime * gecikmeHizi),
            Node.position.y,
            Node.position.z + 1);
        
    }

}

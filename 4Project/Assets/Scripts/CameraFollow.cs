using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField]
    private Transform player; //takip edilecek obje
    private Vector3 takipUzakligi; //player ve kamera arasındaki uzaklik
    public bool takipEdebilir; //kamera player'ı takip edebilir mi? kontrolü

    //başlangıçta kamerayı takipEdebilir olarak işaretle.
    //player ve kamera arasındaki uzaklığı takipUzaklığı değişkenine ata
    void Start()
    {
        takipEdebilir = true;
        takipUzakligi = transform.position - player.transform.position;
    }

    private void FixedUpdate()
    {
        //menu gorunmuyorsa ve takipEdebilir şeklinde işaretliyse; istenilen takip uzaklığıyla player'ı takip et
        if(Player.menuGorunuyor == false)
        {
            if (!takipEdebilir) return;

            transform.position = new Vector3(transform.position.x, transform.position.y, player.position.z + takipUzakligi.z);
        }

       
        
    }
}

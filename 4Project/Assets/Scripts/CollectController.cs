using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CollectController : MonoBehaviour
{

    NodeCollect nodeCollect;
    int zombiSayisi;

    private void OnTriggerEnter(Collider other)
    {
        //Kontrol ettiğimiz karakter, Collect etiketine sahip gameobject'lerinn trigger'ına çarparsa
        if (other.gameObject.CompareTag("Collect"))
        {
            //PlayerPrefs'e kayıtlı son zombi sayısını al
            //zombiSayisi = PlayerPrefs.GetInt("ZombiSayisi");

            //Bu zombi sayısını 1 arttır
            //PlayerPrefs.SetInt("ZombiSayisi", zombiSayisi + 1);

            //Yuruyen insan kodunu dokunulan objeden kaldır
            Destroy(other.gameObject.GetComponent<YuruyenInsan>());

            //CollectController kodunu yeni eklenen kişiye ekle
            other.gameObject.AddComponent<CollectController>();

            //Eklenen kişinin collider trigger'ını kapat
            //other.gameObject.GetComponent<BoxCollider>().isTrigger = false;

            //Eklenen kişiye NodeCollect kodunu ekle
            other.gameObject.AddComponent<NodeCollect>();

            //Eklenen kişiye eklenmiş olan Nodecollect kodundaki Node değişkenini bu objenin transform'una eşitle
            other.gameObject.GetComponent<NodeCollect>().Node = transform;

            other.gameObject.transform.SetParent(GameObject.FindWithTag("Player").transform);

            //Eklenen kişinin etiketini "Collected" olarak değiştir
            other.gameObject.tag = "Collected";
        }
    }
}
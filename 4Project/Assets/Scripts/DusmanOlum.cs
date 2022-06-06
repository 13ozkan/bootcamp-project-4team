using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DusmanOlum : MonoBehaviour
{
    public GameObject dumanYokOlma;
    public AudioManager audioManager;
    int zombiSayisi;

    private void OnTriggerEnter(Collider other)
    {
        //Dusman etiketine sahip objeye dokunursa
      if (other.gameObject.CompareTag("Dusman"))
        {
            //obje zombiyse
            if(gameObject.GetComponent<CollectController>() != null)
            {
                //objenin olduğu yere duman particle efffect olustur
                GameObject duman = Instantiate(dumanYokOlma);
                duman.transform.position = gameObject.transform.position + new Vector3(0, 1, 0);

                //particle effect animasyonunu oynat
                duman.GetComponent<ParticleSystem>().Play();

                //ses cikar
                audioManager.Play("zombiYokOlus");

                //objeyi yok et
                Destroy(gameObject);

                //PlayerPrefs'e kayıtlı son zombi sayısını al
                //zombiSayisi = PlayerPrefs.GetInt("ZombiSayisi");

                //Bu zombi sayısını 1 azalt
                //PlayerPrefs.SetInt("ZombiSayisi", zombiSayisi - 1);
            }
        }
    }
}

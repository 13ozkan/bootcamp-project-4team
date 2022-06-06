using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeyinTrigger : MonoBehaviour
{

    public GameObject dumanYokOlma;
    public AudioManager audioManager;
    public GameObject beyin;
    public int beyinCanı;

    private void Start()
    {
        PlayerPrefs.SetInt("BeyinCan", beyinCanı);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Dokunursak ve boss'un canı 0 değilse animasyonları override yaparak savas moduna sok
        if (other.gameObject.tag == "Collected" && PlayerPrefs.GetInt("BeyinCan")!=0)
        {
            //beyin modeline animator childobject olan joint içerisinde ekli
            beyin.transform.GetChild(0).GetComponent<Animator>().Play("Hit1");

            //beynin üzerinde rastgele yerlerde duman particle effect olustur
            GameObject duman = Instantiate(dumanYokOlma);

            //rastgele x ve y koordinat offsetleri al ve duman koordinatlarına ekle
            int yPozisyonu = Random.Range(-2, 5);
            int xPozisyonu = Random.Range(-2, 3);
            duman.transform.position = gameObject.transform.position + new Vector3(xPozisyonu, yPozisyonu, 0);

            //particle effect animasyonunu oynat
            duman.GetComponent<ParticleSystem>().Play();

            //ses cikar
            audioManager.Play("zombiYokOlus");

            //zombiyi yok et
            Destroy(other.gameObject);

            //Beynin mevcut canını 1 azalt
            int beyinSonCan = PlayerPrefs.GetInt("BeyinCan");
            beyinSonCan = beyinSonCan - 1;
            PlayerPrefs.SetInt("BeyinCan", beyinSonCan);
        }
        //eğer beynin canı 0 ise
        else
        {
            beyin.transform.GetChild(0).GetComponent<Animator>().Play("Death");
        }
    }
}

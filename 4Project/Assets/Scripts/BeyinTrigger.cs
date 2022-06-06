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
            //beyin attack ve hit animasyonlarını rastgele oynat
            int randomAnimasyonSayisi = Random.Range(0, 3);
            if (randomAnimasyonSayisi == 1)
            {
                
                beyin.transform.GetChild(0).GetComponent<Animator>().Play("Hit1");
            }
            else if (randomAnimasyonSayisi == 2)
            {
                
                beyin.transform.GetChild(0).GetComponent<Animator>().Play("Hit2");
            }
            else if (randomAnimasyonSayisi == 3)
            {
                
                beyin.transform.GetChild(0).GetComponent<Animator>().Play("Attack1");
            }

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

            beyin.gameObject.GetComponent<BoxCollider>().isTrigger = true;

            Invoke("DestroyBrain", 2f);
        }
    }

    //Beyni yok et
    public void DestroyBrain()
    {
        Destroy(beyin);

    }
}

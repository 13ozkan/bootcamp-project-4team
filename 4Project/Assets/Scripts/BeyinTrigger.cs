using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeyinTrigger : MonoBehaviour
{

    public GameObject dumanYokOlma;
    public AudioManager audioManager;

    private void OnTriggerEnter(Collider other)
    {
        //Dokunursak animasyonları override yaparak savas moduna sok
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Collected")
        {

            //objenin olduğu yere duman particle efffect olustur
            GameObject duman = Instantiate(dumanYokOlma);

            int yPozisyonu = Random.Range(1, 2);
            int xPozisyonu = Random.Range(-2, 2);
            duman.transform.position = gameObject.transform.position + new Vector3(xPozisyonu, yPozisyonu, 0);

            //particle effect animasyonunu oynat
            duman.GetComponent<ParticleSystem>().Play();

            //ses cikar
            audioManager.Play("zombiYokOlus");

            Destroy(other.gameObject);

        }
    }
}

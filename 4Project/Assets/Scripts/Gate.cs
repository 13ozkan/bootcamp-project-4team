using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public int xKatArttir;
    public GameObject zombilesenInsan;
    bool arttirildi = false;

    private void OnTriggerEnter(Collider other)
    {
        //Eğer dokunulan kişi Player veya zombileştirilen insanlardansa
        if (other.gameObject.tag == "Collected")
        {

            int playerChildSayisi = GameObject.FindWithTag("Player").transform.childCount - 1;


            for (int i = 0; i < playerChildSayisi; ++i)
            {
                SpawnZombi(GameObject.FindWithTag("Player").transform.GetChild(playerChildSayisi).transform.position + new Vector3(i, 0, 0));
            }

            arttirildi = true;
        }
    }

    void SpawnZombi(Vector3 spawnPosition)
    {
        GameObject eklenenZombi = Instantiate(zombilesenInsan, spawnPosition, GameObject.FindWithTag("Player").transform.rotation);
        eklenenZombi.transform.SetParent(GameObject.FindWithTag("Player").transform);
    }
}

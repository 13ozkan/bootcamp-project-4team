using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject startScreen;
    bool baloncukGoster = true;
    public GameObject player;


    void Start()
    {

    }

    void Update()
    {
        if(Player.menuShowing == false)
        {
            GameStart();
        }
    }


    //oyun oynanmaya başladı
    public void GameStart()
    {
        if(baloncukGoster == true)
        {
            //Fikir baloncuğunu yok et
            GameObject.FindWithTag("FikirBalonu").SetActive(false);

            baloncukGoster = false;
        }
        

        //Başlangıç ekranını yok et
        startScreen.SetActive(false);

    }

    //oyun kaybedildi
    public void GameOver()
    {
       

        if (player.transform.position.y < 0)
        {
            Player.menuShowing = true;
            Invoke("RestartScene", 2.2f);
        }

        //X saniye sonra bölümü tekrar başlat
        

    }

    //bölüm geçildi
    public void LevelCompleted()
    {
        Player.menuShowing = true;

    }


    //bölümü tekrar başlat
    void RestartScene()
    {
        //Aktif sahneyi tekrar yükle
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);

    }

}

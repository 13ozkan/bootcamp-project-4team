using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject startScreen; //Oyun baslangic menusu
    bool baloncukGoster = true; //Player'ın tepesinde gorunen fikir balonu oyun ilk acildiginda gorunur durumda
    public AudioManager audioManager;

    private void Start()
    {
        audioManager.PlayLooped("arkaplan");
    }

    void Update()
    {
        //Menu gorunur değilse GameStart'ı tetikle.
        if(Player.menuGorunuyor == false)
        {
            GameStart();
        }
    }


    //Oyun oynanmaya başladı
    public void GameStart()
    {
        //Fikir balonu gorunuyorsa
        if(baloncukGoster == true)
        {
            //Fikir baloncuğunu yok et
            GameObject.FindWithTag("FikirBalonu").SetActive(false);

            //baloncukGoster'ı false yap
            baloncukGoster = false;

        }
        

        //Başlangıç ekranını yok et
        startScreen.SetActive(false);

    }

    //oyun kaybedildi
    public void GameOver()
    {
        //Menu gorunmuyor
        Player.menuGorunuyor = true;

        //X saniye sonra bölümü tekrar başlat
        Invoke("RestartScene", 2.2f);

    }

    //bölüm geçildi
    public void LevelCompleted()
    {
        //Menu gorunuyor
        Player.menuGorunuyor = true;

    }


    //bölümü tekrar başlat
    void RestartScene()
    {
        //Sahneler hiyerarşisinde aktif olan sahneyi tekrar yükle.
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);

    }

}

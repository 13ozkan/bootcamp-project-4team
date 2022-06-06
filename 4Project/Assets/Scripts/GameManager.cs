using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject startScreen; //Oyun baslangic menusu
    bool baloncukGoster = true; //Player'ın tepesinde gorunen fikir balonu oyun ilk acildiginda gorunur durumda
    public AudioManager audioManager;
    public GameObject fikirBalonu;//karakterin kafasındaki düşünce blaonu
    public GameObject zombiSayisiBalonu;//karakterin kaç kişiyi zzombi yaptığının sayısını gösteren balon
    public GameObject zombiSayisi;//karakterin kaç kişiyi zombi yaptığını yazan text
    public GameObject winScreen;
    public GameObject gameOverScreen;

    private void Start()
    {
        //zombi sayısını her oyun başında 1'e eşitle (biz 1 sayılıyoruz)
        PlayerPrefs.SetInt("ZombiSayisi", 1);

        //Arkaplan ssesini başlat
        audioManager.PlayLooped("arkaplan");
    }

    void Update()
    {
        //Menu gorunur değilse GameStart'ı tetikle.
        if(Player.menuGorunuyor == false)
        {
            GameStart();
        }

        if(GameObject.FindWithTag("Player") == null)
        {
            GameOver();
        }
    }


    //Oyun oynanmaya başladı
    public void GameStart()
    {
        //Fikir balonu gorunuyorsa
        if(baloncukGoster == true)
        {
            //Zombi sayısı baloncuğunu göster
            zombiSayisiBalonu.SetActive(true);

            //Fikir baloncuğunu yok et
            fikirBalonu.SetActive(false);

            //baloncukGoster'ı false yap
            baloncukGoster = false;

        }
        

        //Başlangıç ekranını yok et
        startScreen.SetActive(false);

        if(GameObject.FindWithTag("Player") != null)
        {
            int playerChildSayisi = GameObject.FindWithTag("Player").transform.childCount;
            playerChildSayisi = playerChildSayisi - 1;

            //PlayerPrefs'e kaydedilen zombisayisi bilgisini text üzerinde sürekli olarak güncelle
            zombiSayisi.GetComponent<TextMeshProUGUI>().text = "" + playerChildSayisi;

        }else if(GameObject.FindWithTag("Player") == null)
        {
            GameOver();
        }

      

    }

    //oyun kaybedildi
    public void GameOver()
    {
        //Menu gorunmuyor
        Player.menuGorunuyor = true;

        gameOverScreen.SetActive(true);

        //X saniye sonra bölümü tekrar başlat
        Invoke("RestartScene", 2.2f);

    }

    //bölüm geçildi
    public void LevelCompleted()
    {
        //Menu gorunuyor
        //Player.menuGorunuyor = true;

        winScreen.SetActive(true);

        //Zombi sayısı baloncuğunu gizle
        zombiSayisiBalonu.SetActive(false);
    }


    //bölümü tekrar başlat
    void RestartScene()
    {
        //Sahneler hiyerarşisinde aktif olan sahneyi tekrar yükle.
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);

    }

}

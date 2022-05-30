using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    Animator playerAnimator; //player'a bağlı animator
    public static bool menuGorunuyor; //menü gösterilip gösterilmediğini kontrol etmek için

    bool karakterArkasinaDondu = false; //karakter oyuna kameraya dogru bakarak basladi

    private DynamicJoystick dynamicJoystick;//Player'ı kontrol edecek joystick

    float horizontal, vertical; //joystick kontrolu icin yatay ve dikey degiskenler

    public float hiz; //ileri gitme hizi
    public float yatayHiz; //yatayda hareket etme hizi

    private GameManager gameManager;//Menu gorunurlugu gibi bilgileri kontrol etmek icinn GameManager


    void Start()
    {
        //objeye bağlı animatoru anim değişkenine ekle
        playerAnimator = GetComponent<Animator>();

        //level başında menü görünüyor
        menuGorunuyor = true;

        //sahnedeki joystick objesini değişkene ata
        dynamicJoystick = FindObjectOfType<DynamicJoystick>();

        //sahnedeki gamemanageri değişkene ata
        gameManager = FindObjectOfType<GameManager>();
    }



    private void FixedUpdate()
    {
        //Kullanıcı sol mouse tuşuna basarsa (veya ekrana dokunursa) olacaklar
         if (Input.GetButton("Fire1"))
         {
            //oyun menüsü görünür durumdaysa yok et,gamemanager'a oyunun başladığını bildir
             if (menuGorunuyor)
             {
                 menuGorunuyor = false;

                 gameManager.GameStart();

                //Player karakterini dotween ile istenilen sürede arkasına döndürme sequence'ını baslat
                var sequence = DOTween.Sequence();
                sequence.Append(gameObject.transform.DORotate(new Vector3(0, 0, 0), 0.5f));

                //döndürme işlemi bitince hareket etme animasyonunu başlat
                sequence.OnComplete(() =>
                {
                    karakterArkasinaDondu = true;
                    Move();
                });

             }//eğer menü görünür değilse joystick kontrollerini etkinleştir
            else if (!menuGorunuyor)
                {
                    JoystickMovement();
                }
         }

         //eğer menü görünmüyor ve karakte arkasına dönükse ileri doğru belirlenen hızla ilerle
        if (!menuGorunuyor && karakterArkasinaDondu)
        {
            Vector3 addedPos = new Vector3(0, 0, hiz * Time.fixedDeltaTime);
            transform.position += addedPos;

        }
    }

    //joystick kontrolleri
    public void JoystickMovement()
    {

        horizontal = dynamicJoystick.Horizontal;
        vertical = dynamicJoystick.Vertical;

        Vector3 addedPos = new Vector3(horizontal * yatayHiz * Time.deltaTime, 0, vertical * hiz * Time.fixedDeltaTime);
        transform.position += addedPos;

    }

    //karakterin animasyonunu beklemeye çevir
    private void Idle()
    {
        playerAnimator.SetBool("isMoving", false);
    }

    //karakterin animasyonunu yürümeye çevir
    private void Move()
    {
        playerAnimator.SetBool("isMoving", true);

    }

    //karakterin animasyonunu kazanmaya çevir
    private void Win()
    {
        playerAnimator.SetBool("isWin", true);

    }

    //karakterin animasyonunu kaybetmeye çevir
    private void Failed()
    {
        playerAnimator.SetBool("isFailed", true);

    }
}

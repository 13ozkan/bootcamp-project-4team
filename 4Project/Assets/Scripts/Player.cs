using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    Animator anim; //player'a bağlı animator
    public static bool menuShowing; //menü gösterilip gösterilmediğini kontrol etmek için

    bool karakterArkasinaDondu = false;

    private DynamicJoystick dynamicJoystick;

    float horizontal, vertical;

    public float hiz;
    public float yatayHiz;
    public float donusHizi;

    private GameManager gameManager;


    void Start()
    {
        //objeye bağlı animatoru anim değişkenine ekle
        anim = GetComponent<Animator>();

        //level başında menü görünüyor
        menuShowing = true;

        //sahnedeki joystick objesini değişkene ata
        dynamicJoystick = FindObjectOfType<DynamicJoystick>();

        //sahnedeki gamemanageri değişkene ata
        gameManager = FindObjectOfType<GameManager>();
    }



    private void FixedUpdate()
    {

         if (Input.GetButton("Fire1"))
         {
             if (menuShowing)
             {
                 menuShowing = false;

                 gameManager.GameStart();

                //karakteri arkasına döndür
                var sequence = DOTween.Sequence();
                sequence.Append(gameObject.transform.DORotate(new Vector3(0, 0, 0), 0.5f));

                sequence.OnComplete(() =>
                {
                    karakterArkasinaDondu = true;
                    Move();
                });

             }else if (!menuShowing)
                {
                    JoystickMovement();
                }
         }

        if (!menuShowing && karakterArkasinaDondu)
        {
            Vector3 addedPos = new Vector3(0, 0, hiz * Time.fixedDeltaTime);
            transform.position += addedPos;

        }
    }

    public void JoystickMovement()
    {

        horizontal = dynamicJoystick.Horizontal;
        vertical = dynamicJoystick.Vertical;

        Vector3 direction = Vector3.forward * vertical + Vector3.right * horizontal;
        //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), turnSpeed * Time.fixedDeltaTime);

        Vector3 addedPos = new Vector3(horizontal * yatayHiz * Time.deltaTime, 0, vertical * hiz * Time.fixedDeltaTime);
        transform.position += addedPos;

    }

    //karakterin animasyonunu beklemeye çevir
    private void Idle()
    {
        anim.SetBool("isMoving", false);
    }

    //karakterin animasyonunu yürümeye çevir
    private void Move()
    {
        anim.SetBool("isMoving", true);

    }

    //karakterin animasyonunu kazanmaya çevir
    private void Win()
    {
        anim.SetBool("isWin", true);

    }

    //karakterin animasyonunu kaybetmeye çevir
    private void Failed()
    {
        anim.SetBool("isFailed", true);

    }

}



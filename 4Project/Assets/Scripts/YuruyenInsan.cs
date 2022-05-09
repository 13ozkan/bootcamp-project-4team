using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YuruyenInsan : MonoBehaviour
{
    public float hiz;
    Animator anim; //objeye animator

    private void Start()
    {
        //objeye bağlı animatoru anim değişkenine ekle
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (Player.menuShowing==false){

            Move();
            transform.Translate(Vector3.forward * Time.deltaTime * hiz);

        }else if(Player.menuShowing == true)
        {
            Idle();
        }

      
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
}

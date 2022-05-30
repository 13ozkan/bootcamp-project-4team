using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class YuruyenInsan : MonoBehaviour
{
    public float hiz; //yurume hizi
    Animator animator; //objeye ekli animator
    public GameObject dumanEfekti; //insanlar zombilesince belirecek efekt
    bool dumanGozuktu; //duman bir kez gorunduyse bir daha gostermemek icin
    public AnimatorOverrideController zombilestirAnimatorOverride; //Player'a dokunursak insan animasyonlarını zombi animasyonlarıyla değiştirmek icin
    public AudioManager audioManager;


    private void Start()
    {
        //objeye bağlı animatoru animator değişkenine ekle
        animator = GetComponent<Animator>();

        gameObject.GetComponent<YuruyenInsan>().dumanGozuktu = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Dokunursak animasyonları override yaparak zombileştir
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Collected")
        {
            if(gameObject.GetComponent<YuruyenInsan>().dumanGozuktu == false)
            {
                //sess cikar
                audioManager.Play("zombiAtak");

                //oldugumuz yerde duman efekti particle efekti goster
                GameObject duman = Instantiate(dumanEfekti);
                duman.transform.position = gameObject.transform.position + new Vector3(0, 1, 0);
                duman.GetComponent<ParticleSystem>().Play();

                gameObject.GetComponent<YuruyenInsan>().dumanGozuktu = true;

                //Yuruyen insanın hızını player'ın hızına çıkart
                hiz = 5;

            }


            //eger kameraya dogru bakıyorsak dondur
            transform.DORotate(new Vector3(0, 0, 0), 0.2f);

            //tüm animasyonları zombi annimasyonlarıyla override et
            gameObject.GetComponent<Animator>().runtimeAnimatorController = zombilestirAnimatorOverride;

            //yurume animasyonun görsel hizini arttır (cunku normal yurume animasyonunun hizi, zombi yurumesine gore yavas kaliyor)
            animator.SetFloat("walkMultiplier", 4f);

        }
    }

    private void FixedUpdate()
    {
        //Menu'nun gorunup gorunmedigini kontrol et.
        //Gorunmuyorsa yürüme animasyonu başlat ve ileri doğru istenilen hizda ilerlet.
        if (Player.menuGorunuyor==false){

            Move();
            transform.Translate(Vector3.forward * Time.deltaTime * hiz);

        }//Gorunuyorsa sabit durma animasyonunda kal.
        else if(Player.menuGorunuyor == true)
        {
            Idle();
        }

      
    }

    //karakterin animasyonunu beklemeye çevir
    private void Idle()
    {
        animator.SetBool("isMoving", false);
    }

    //karakterin animasyonunu yürümeye çevir
    private void Move()
    {
        animator.SetBool("isMoving", true);

    }

    //karakterin animasyonunu kazanmaya çevir
    private void Win()
    {
        animator.SetBool("isWin", true);

    }

    //karakterin animasyonunu kaybetmeye çevir
    private void Failed()
    {
        animator.SetBool("isFailed", true);

    }
}

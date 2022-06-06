using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Finish : MonoBehaviour
{
    public AnimatorOverrideController kazanmaAnimationOverride; //elleri havaya kaldırarak sevinem animasyon override
    public AnimatorOverrideController danceAnimationOverride;//dans ederek sevinme animasyon override
    private GameManager gameManager;//Menu gorunurlugu gibi bilgileri kontrol etmek icinn GameManager
    public GameObject konfetiYagdir;

    private void Start()
    {
        //sahnedeki gamemanageri değişkene ata
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Collected" || other.gameObject.tag == "Player")
        {

            if (other.gameObject.GetComponent<Player>() != null)
            {
                //kazanma animasyonuna çevir
                other.gameObject.GetComponent<Animator>().runtimeAnimatorController = danceAnimationOverride;
                other.gameObject.GetComponent<Player>().hiz = 0;
                other.gameObject.transform.DORotate(new Vector3(0, 180, 0), 1f);
            }
            else
            {
                other.gameObject.GetComponent<Animator>().runtimeAnimatorController = kazanmaAnimationOverride;
                other.gameObject.GetComponent<Animator>().SetFloat("walkMultiplier", 1f);
            }

            gameManager.LevelCompleted();
            konfetiYagdir.SetActive(true);
        }
    }
}
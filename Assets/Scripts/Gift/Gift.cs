using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Gift : MonoBehaviour
{
    public int qteBeforeOpening = 8;

    public GameObject fullGift;
    public SpriteRenderer giftRender;
    public SpriteRenderer bot;
    public SpriteRenderer top;
    public SpriteRenderer bow;

    public Sprite demicadeau;
    public Sprite nakedcadeau;

     GameObject[] audios;
    GameObject ding;

    private void Start()
    {
        audios = GameObject.FindGameObjectsWithTag("Scratch");
        ding = GameObject.FindGameObjectWithTag("Ding");
        GetComponent<GiftColorSelector>().SetUpGift(this);
    }

    public void ReduceQte()
    {
        qteBeforeOpening -= 1;
        if (qteBeforeOpening == 6)
        {
            audios[Random.Range(0, audios.Length)].GetComponent<AudioSource>().Play();
            bow.gameObject.GetComponent<BowBoom>().GoAway();
        }

        if (qteBeforeOpening == 4)
        {
            audios[Random.Range(0, audios.Length)].GetComponent<AudioSource>().Play();
            giftRender.sprite = demicadeau;
            top.enabled = true;
            top.gameObject.GetComponent<BowBoom>().GoAway();
        }

        if (qteBeforeOpening == 2)
        {
            audios[Random.Range(0, audios.Length)].GetComponent<AudioSource>().Play();
            giftRender.sprite = nakedcadeau;
            bot.enabled = true;
            bot.gameObject.GetComponent<BowBoom>().GoAway();
        }

        if (qteBeforeOpening == 0)
        {
            StartCoroutine(MoveAndGo());
            ding.GetComponent<AudioSource>().Play();
        }
    }

    private IEnumerator MoveAndGo()
    {

        QTEController qte = FindObjectOfType<QTEController>();
        if (GameController.activeGC.selectedDifficulty != GameController.Gametype.TRAINING)
        {
            if (GameController.activeGC.selectedDifficulty != GameController.Gametype.NORMAL)
            {
                GameController.activeGC.giftsToGive.Add(qte.normalGifts[Random.Range(0, qte.normalGifts.Count)]);
            }

            else
            {
                GameController.activeGC.giftsToGive.Add(qte.hardGifts[Random.Range(0, qte.hardGifts.Count)]);
            }
        }

        qte.giftvalidated += 1;
        transform.DOMove(qte.endPos.transform.position, 0.6f);
        yield return new WaitForSeconds(0.6f);
        qte.ChangeGift();
        Destroy(gameObject);
    }
}

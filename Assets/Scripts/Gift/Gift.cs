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

    public void ReduceQte()
    {
        qteBeforeOpening -= 1;
        if (qteBeforeOpening == 6)
        {
            bow.gameObject.GetComponent<BowBoom>().GoAway();
        }

        if (qteBeforeOpening == 4)
        {
            giftRender.sprite = demicadeau;
            top.enabled = true;
            top.gameObject.GetComponent<BowBoom>().GoAway();
        }

        if (qteBeforeOpening == 2)
        {
            giftRender.sprite = nakedcadeau;
            bot.enabled = true;
            bot.gameObject.GetComponent<BowBoom>().GoAway();
        }

        if (qteBeforeOpening == 0)
        {
            StartCoroutine(MoveAndGo());
        }
    }

    private IEnumerator MoveAndGo()
    {
        //FIXME: add object to GameController
        QTEController qte = FindObjectOfType<QTEController>();
        transform.DOMove(qte.endPos.transform.position, 0.6f);
        yield return new WaitForSeconds(0.6f);
        qte.ChangeGift();
    }
}

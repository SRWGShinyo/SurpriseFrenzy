using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftColorSelector : MonoBehaviour
{
    public List<Sprite> fullGifts;
    public List<Sprite> allBow;
    public List<Sprite> allBot;
    public List<Sprite> allTop;
    public List<Sprite> demicadeaux;
    public void SetUpGift(Gift g)
    {
        int rnd = Random.Range(0, fullGifts.Count);
        g.giftRender.sprite = fullGifts[rnd];
        int rnd2 = Random.Range(0, fullGifts.Count);
        g.bow.sprite = allBow[rnd2];
        g.bot.sprite = allBot[rnd];
        g.top.sprite = allTop[rnd];
        g.demicadeau = demicadeaux[rnd];
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using DG.Tweening;
using UnityEngine;

public class GoToEnd : MonoBehaviour
{
    public Transform startPoint;
    public Transform middlePoint;
    public Transform endPoint;

    public Transform itemCenter;
    public GameObject basicRenderer;
    public GameObject giftPrefab;

    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemDescr;

    public SpriteRenderer filter;

    public GameObject endPanel;
    public TextMeshProUGUI finished;
    public TextMeshProUGUI Unpack;

    public void EndGame()
    {
        StartCoroutine(AnimateToEnd());
    }

    private IEnumerator AnimateToEnd()
    {
        finished.transform.DOScale(new Vector3(1f, 1f, 1f), 0.6f);
        yield return new WaitForSeconds(2f);
        finished.transform.DOScale(new Vector3(0f, 0f, 0f), 0.6f);
        Unpack.transform.DOScale(new Vector3(1f, 1f, 1f), 0.6f);
        yield return new WaitForSeconds(2f);
        Unpack.transform.DOScale(new Vector3(0f, 0f, 0f), 0.6f);

        Color c = filter.color;
        while (c.a > 0)
        {
            c.a -= 0.01f;
            filter.color = c;
            c = filter.color;
            yield return new WaitForSeconds(0.01f);
        }

        while (GameController.activeGC.giftsToGive.Count > 0)
        {
            Gifts toGive = GameController.activeGC.giftsToGive[0];
            GameObject gift = Instantiate(giftPrefab);
            gift.transform.position = startPoint.transform.position;
            gift.transform.DOMove(middlePoint.transform.position, 1f);
            yield return new WaitForSeconds(1f);
            gift.GetComponentInChildren<BowBoom>().GoAway();
            GameObject renderer = Instantiate(basicRenderer);
            renderer.transform.position = middlePoint.transform.position;
            renderer.GetComponent<SpriteRenderer>().sprite = toGive.image;
            itemName.text = toGive.nam;
            itemDescr.text = toGive.tagline;
            renderer.transform.DOMove(itemCenter.position, 1f);
            renderer.transform.DOScale(new Vector3(1.7f, 1.7f, 1.7f), 1f);
            yield return new WaitForSeconds(1f);

            itemName.transform.DOScale(new Vector3(1, 1, 1), 1f);
            itemDescr.transform.DOScale(new Vector3(1, 1, 1), 1f);
            yield return new WaitForSeconds(2f);
            renderer.transform.DOMove(middlePoint.position, 0.6f);
            renderer.transform.DOScale(new Vector3(0, 0, 0), 0.6f);
            itemName.transform.DOScale(new Vector3(0, 0, 0), 0.4f);
            itemDescr.transform.DOScale(new Vector3(0, 0, 0), 0.4f);

            yield return new WaitForSeconds(0.6f);
            Destroy(renderer);
            gift.transform.DOMove(endPoint.transform.position, 0.5f);
            yield return new WaitForSeconds(0.5f);
            Destroy(gift);
            GameController.activeGC.giftsToGive.RemoveAt(0);
        }

        endPanel.GetComponent<EndPanel>().SetUp();
        endPanel.transform.DOScale(new Vector3(1f, 1f, 1f), 1f);
    }
}

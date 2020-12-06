using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTEController : MonoBehaviour
{
    public Gift activeGift;
    public GameObject GiftPrefab;
    public int givenScore = 200;
    public float timeLeft = 20f;
    public List<GameObject> activeQTEs;

    public List<Gifts> giftsAvailable = new List<Gifts>();

    public int giftvalidated = -1;
    public GameObject startPos;
    public GameObject endPos;
    public GameObject middlePos;

    public bool isActive = false;

    public GameObject qteSliderPrefab;
    public GameObject qteClickPrefab;

    public float wantedTimeToDie = 2f;

    public int score = 0;

    public float wantedTimeQTE = 1f;
    public float timeBeforeQte = 1f;

    float givenPerfect;
    float givenGood;

    public enum QTEType
    {
        SLIDER,
        CLICK
    }

    private void Start()
    {
        GameController gc = FindObjectOfType<GameController>();
        if (gc)
        {
            if (gc.selectedDifficulty == GameController.Gametype.NORMAL)
                SetUpNormal();
            else
                SetUpHard();
        }

        else
        {
            SetUpNormal();
        }
        ChangeGift();
    }

    private void SetUpNormal()
    {
        wantedTimeToDie = Config.ttlNormal;
        wantedTimeQTE = Config.timeSpawningNormal;
        timeBeforeQte = Config.timeSpawningNormal;
        givenScore = Config.scoreGivenNormal;
        givenPerfect = Config.givenTimeNormalPerfect;
        givenGood = Config.givenTimeNormalGood;
    }

    private void SetUpHard()
    {
        wantedTimeToDie = Config.ttlHard;
        wantedTimeQTE = Config.timeSpawningHard;
        timeBeforeQte = Config.timeSpawningHard;
        givenScore = Config.scoreGivenHard;
        givenPerfect = Config.givenTimeHardPerfect;
        givenGood = Config.givenTimeHardGood;
    }

    private void Update()
    {
        if (!isActive)
            return;

        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            timeLeft = 0;
            isActive = false;
            foreach (GameObject go in activeQTEs)
                Destroy(go);

            if (activeGift)
            {
                activeGift.gameObject.transform.DOMove(startPos.transform.position, 0.4f);
                Destroy(activeGift.gameObject);
                activeGift = null;
            }
            FindObjectOfType<GoToEnd>().EndGame();
        }

        timeBeforeQte -= Time.deltaTime;
        if (timeBeforeQte <= 0)
        {
            SpawnQTE();
            timeBeforeQte = wantedTimeQTE;
        }
    }

    public void SpawnQTE()
    {
        System.Random rdm = new System.Random();
        int rng = rdm.Next(1, 101);

        if (activeQTEs.Count == 0)
        {
            if (rng <= 70)
                createQTE(QTEType.SLIDER);
            else
                createQTE(QTEType.CLICK);
        }

        else
        {
            if (rng <= 50)
                createQTE(QTEType.SLIDER);
            else
                createQTE(QTEType.CLICK);
        }
    }

    public void createQTE(QTEType type)
    {
        switch(type)
        {
            case QTEType.SLIDER:
                activeQTEs.Add(Instantiate(qteSliderPrefab));
                break;
            case QTEType.CLICK:
                activeQTEs.Add(Instantiate(qteClickPrefab));
                break;
        }
    }



    public void ValidateAQTE(QTEMother qt, QTEMother.ValidationType type)
    {
        switch(type)
        {
            case QTEMother.ValidationType.PERFECT:
                score += givenScore;
                timeLeft += givenPerfect;
                activeGift.ReduceQte();
                break;
            case QTEMother.ValidationType.GOOD:
                score += givenScore / 2;
                timeLeft += givenGood;
                activeGift.ReduceQte();
                break;
            case QTEMother.ValidationType.FAIL:
                timeLeft -= 2f;
                break;
        }

        activeQTEs.Remove(qt.gameObject);
        Destroy(qt.gameObject);
    }

    public void ChangeGift()
    {
        StartCoroutine(changement());
    }

    private IEnumerator changement()
    {
        GameObject gift = Instantiate(GiftPrefab);
        gift.transform.position = startPos.transform.position;
        activeGift = gift.GetComponent<Gift>();
        gift.transform.DOMove(middlePos.transform.position, 0.6f);
        yield return new WaitForSeconds(0.6f);
    }
}

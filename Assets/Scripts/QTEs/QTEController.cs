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

    public int awardByGift = 0;

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

    public float givenPerfect;
    public float givenGood;

    public AudioSource dingding;
    public AudioSource error;
    public enum QTEType
    {
        SLIDER,
        CLICK
    }

    public List<Gifts> normalGifts = new List<Gifts>();
    public List<Gifts> hardGifts = new List<Gifts>();


    private void Start()
    {
        GameController gc = GameController.activeGC;
        if (gc)
        {
            if (gc.selectedDifficulty == GameController.Gametype.NORMAL)
                SetUpNormal();
            else if (gc.selectedDifficulty == GameController.Gametype.HARD)
                SetUpHard();
            else
            {
                wantedTimeQTE = 1f;
                wantedTimeToDie = 1.5f;
            }
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
        awardByGift = Config.scoreGivenGiftNormal;
    }

    private void SetUpHard()
    {
        wantedTimeToDie = Config.ttlHard;
        wantedTimeQTE = Config.timeSpawningHard;
        timeBeforeQte = Config.timeSpawningHard;
        givenScore = Config.scoreGivenHard;
        givenPerfect = Config.givenTimeHardPerfect;
        givenGood = Config.givenTimeHardGood;
        awardByGift = Config.scoreGivenGiftHard;
    }

    public int computeTotalScore()
    {
        return score + (giftvalidated * awardByGift);
    }

    private void Update()
    {
        if (!isActive)
            return;

        timeBeforeQte -= Time.deltaTime;
        if (timeBeforeQte <= 0)
        {
            SpawnQTE();
            timeBeforeQte = wantedTimeQTE;
        }

        if (GameController.activeGC.selectedDifficulty == GameController.Gametype.TRAINING)
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
        switch (type)
        {
            case QTEMother.ValidationType.PERFECT:
                if (GameController.activeGC.selectedDifficulty != GameController.Gametype.TRAINING)
                {
                    score += givenScore;
                    timeLeft += givenPerfect;
                }
                dingding.Play();
                activeGift.ReduceQte();
                break;
            case QTEMother.ValidationType.GOOD:
                if (GameController.activeGC.selectedDifficulty != GameController.Gametype.TRAINING)
                {
                    score += givenScore / 2;
                    timeLeft += givenGood;
                }
                dingding.Play();
                activeGift.ReduceQte();
                break;
            case QTEMother.ValidationType.FAIL:
                if (GameController.activeGC.selectedDifficulty != GameController.Gametype.TRAINING)
                    timeLeft -= 2f;
                error.Play();
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

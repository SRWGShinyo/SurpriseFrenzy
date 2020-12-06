using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SlideShow : MonoBehaviour
{
    public List<GameObject> slides;
    public TextMeshProUGUI countArrow;
    int index = 0;

    public void GoForward()
    {
        slides[index].SetActive(false);
        index += 1;
        index = index % slides.Count;

        countArrow.text = (index + 1).ToString() + "/" + slides.Count.ToString();
        slides[index].SetActive(true);
    }

    public void GoBackward()
    {
        slides[index].SetActive(false);
        index -= 1;
        if (index < 0)
            index = slides.Count - 1;

        countArrow.text = (index + 1).ToString() + "/" + slides.Count.ToString();
        slides[index].SetActive(true);
    }
}

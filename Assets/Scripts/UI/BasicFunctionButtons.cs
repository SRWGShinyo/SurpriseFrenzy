using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BasicFunctionButtons : MonoBehaviour
{
    public GameObject panel;
    public GameController.Gametype type;
    public void Open()
    {
        EventSystem.current.SetSelectedGameObject(null);
        panel.transform.DOScale(new Vector3(1, 1, 1), 0.5f);
    }

    public void Close()
    {
        EventSystem.current.SetSelectedGameObject(null);
        panel.transform.DOScale(new Vector3(0, 0, 0), 0.5f);
    }

    public void SelectDifficulty()
    {
        GameController.activeGC.selectedDifficulty = type;
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}

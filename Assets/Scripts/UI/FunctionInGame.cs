﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class FunctionInGame : MonoBehaviour
{
    public GameObject panel;
    public static bool isPaused = false;

    public void Pause()
    {
        EventSystem.current.SetSelectedGameObject(null);
        panel.transform.localScale = new Vector3(1f, 1f, 1f);
        if (isPaused)
            return;
        isPaused = true;
        Time.timeScale = 0f;
    }

    public void Replay()
    {
        GameController.activeGC.giftsToGive.Clear();
        SceneManager.LoadScene(1);
    }

    public void Mainmenu()
    {
        isPaused = false;
        Time.timeScale = 1f;
        GameController.activeGC.giftsToGive.Clear();
        SceneManager.LoadScene(0);
    }

    public void Reprendre()
    {
        EventSystem.current.SetSelectedGameObject(null);
        Time.timeScale = 1f;
        if (!isPaused)
            return;
        
        isPaused = false;
        panel.transform.localScale = new Vector3(0f, 0f, 0f);
    }
}

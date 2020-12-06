using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameDiffSelector : MonoBehaviour
{
    public GameObject trainingButton;
    public GameObject normalButton;
    public GameObject hardButton;

    string trainingDescription = "In training mode, no way to lose ! But no gifts either !";
    string normalDescription = "Enjoy the game in a moderate difficulty...and win some gifts !";
    string hardDescription = "Basically hardcore overgod mode. But more gifts available !";

    public TextMeshProUGUI description;

    private void Update()
    {
        GameController gc = GameController.activeGC;
        if (gc.selectedDifficulty == GameController.Gametype.TRAINING)
        {
            description.text = trainingDescription;
            trainingButton.GetComponent<Image>().color = Color.magenta;
            normalButton.GetComponent<Image>().color = Color.black;
            hardButton.GetComponent<Image>().color = Color.black;
        }

        else if (gc.selectedDifficulty == GameController.Gametype.NORMAL)
        {
            description.text = normalDescription;
            trainingButton.GetComponent<Image>().color = Color.black;
            normalButton.GetComponent<Image>().color = Color.magenta;
            hardButton.GetComponent<Image>().color = Color.black;
        }

        else
        {
            description.text = hardDescription;
            trainingButton.GetComponent<Image>().color = Color.black;
            normalButton.GetComponent<Image>().color = Color.black;
            hardButton.GetComponent<Image>().color = Color.magenta;
        }
    }
}

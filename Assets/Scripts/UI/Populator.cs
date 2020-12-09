using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Populator : MonoBehaviour
{
    public Sprite incognitoSprite;
    public GameObject prefabEntry;

    public GameObject content;
    public GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        populateTable();
    }

    private void populateTable()
    {
        foreach (Gifts g in GameController.activeGC.allAvailableGifts)
        {
            Debug.Log(g.nam);
            GameObject prefab = Instantiate(prefabEntry);
            prefab.transform.SetParent(content.transform);
            prefab.transform.localScale = new Vector3(1f, 1f, 1f);
            if (GameController.activeGC.discoveredGifts.Contains(g.nam))
                prefab.GetComponent<PrefabEntryItem>().INCARNATE(g.nam, g.tagline, g.image);
            else
            {
                if (g.objectState == Gifts.state.NORMAL)
                    prefab.GetComponent<PrefabEntryItem>().INCARNATE("????", "Play in normal to discover that gift !", incognitoSprite);
                else if (g.objectState == Gifts.state.HARD)
                    prefab.GetComponent<PrefabEntryItem>().INCARNATE("????", "Play in hard to discover that gift !", incognitoSprite);
                else
                    prefab.GetComponent<PrefabEntryItem>().INCARNATE("????", "Play in normal or hard to discover that gift !", incognitoSprite);
            }
        }

        panel.transform.localScale = new Vector3(0f, 0f, 0f);
    }
}

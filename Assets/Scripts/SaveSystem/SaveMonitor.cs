using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveMonitor
{
    private static SaveClass CreateSaveObject()
    {
        return new SaveClass(GameController.activeGC.maxScore, GameController.activeGC.discoveredGifts);
    }

    public static void Save()
    {
        SaveClass save = CreateSaveObject();
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/surprisefrenzy.save");
        bf.Serialize(file, save);
        file.Close();
        Debug.Log("Game is now saved");
    }

    public static void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/surprisefrenzy.save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/surprisefrenzy.save", FileMode.Open);
            SaveClass save = (SaveClass)bf.Deserialize(file);
            file.Close();

            GameController.activeGC.maxScore = save.maxScore;
            GameController.activeGC.discoveredGifts = new List<string>(save.itemsFound);
            Debug.Log("Game Loaded");
        }

        else
        {
            Debug.Log("No Game Save found. Creating one.");
            Save();
        }
    }
}

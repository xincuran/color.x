using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;

public static class PublishController {

	public static void SetUniquePlayerName(string nameToSet)
    {
        PlayerIdentity id = new PlayerIdentity();
        id.playerName = nameToSet + FirebaseDatabase.DefaultInstance.RootReference.Child("players").Push().Key;
        id.visiblePlayerName = nameToSet;

        string json = JsonUtility.ToJson(id);
        File.WriteAllText(Application.dataPath + "/playerID.json", json);
    }

    public static string GetUniquePlayerName ()
    {
        string name = "";
        if (File.Exists(Application.dataPath + "/playerID.json"))
        {
            string json = File.ReadAllText(Application.dataPath + "/playerID.json");
            PlayerIdentity id = JsonUtility.FromJson<PlayerIdentity>(json);

            name = id.playerName;
            return name;
        }
        else
        {
            return null;
        }
    }

    public static string GetVisiblePlayerName()
    {
        string name = "";
        if (File.Exists(Application.dataPath + "/playerID.json"))
        {
            string json = File.ReadAllText(Application.dataPath + "/playerID.json");
            PlayerIdentity id = JsonUtility.FromJson<PlayerIdentity>(json);

            name = id.visiblePlayerName;
            return name;
        }
        else
        {
            return null;
        }
    }
}

public class ElementData
{
    public ELEMENT e_dataType;
    public COLORCODE e_dataColor;
    public float e_dataCapacity;
    public float e_dataEnergyToReduce;
    public Vector3 e_dataPosition;
    public Quaternion e_dataRotation;
}

public class PlayerIdentity
{
    public string playerName;
    public string visiblePlayerName;
}

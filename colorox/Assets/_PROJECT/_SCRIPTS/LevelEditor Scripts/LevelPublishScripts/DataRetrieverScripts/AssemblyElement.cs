using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;

public class AssemblyElement : MonoBehaviour {

    public string elementId;
    public string creatorPathName;
    public string levelPathName;

    ElementData data;

    [HideInInspector]
    public LevelAssembler assembler;

	// Use this for initialization
	void Start () {

        FirebaseDatabase.DefaultInstance
          .GetReference("levels")
          .GetValueAsync().ContinueWith(task =>
          {
              if (task.IsFaulted)
              {
                  Debug.LogError("Cannot retrieve data.");
              }
              else if (task.IsCompleted)
              {
                  DataSnapshot snapshot = task.Result;

                  string json = snapshot.Child(creatorPathName).Child(levelPathName).Child(elementId).GetRawJsonValue();

                  data = JsonUtility.FromJson<ElementData>(json);

                  SpawnElement();
              }
          });
    }

    void SpawnElement()
    {
        StoredEnergy element = assembler.SpawnElementToScene(data.e_dataType);
        element.transform.SetParent(assembler.elementHolder);

        element.transform.position = data.e_dataPosition;
        element.transform.rotation = data.e_dataRotation;

        element.elementType = data.e_dataType;
        element.capacity = data.e_dataCapacity;
        element.energyToReduce = data.e_dataEnergyToReduce;
        element.elementColor = data.e_dataColor;

        if(data.e_dataType == ELEMENT.GENERATOR)
        {
            element.currentEnergy = element.capacity;
        }
        if (data.e_dataType != ELEMENT.WATT)
        {
            element.SetColorString();
            element.SetColor();
        }

        Destroy(gameObject);
    }
}

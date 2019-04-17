using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PublishElement : MonoBehaviour {

    private StoredEnergy dataClass;

    // Use this for initialization
    void Start () {
        dataClass = GetComponent<StoredEnergy>();
	}
	
	public void UploadData()
    {
        ElementData data = new ElementData();
        data.e_dataCapacity = dataClass.capacity;
        data.e_dataColor = dataClass.elementColor;
        data.e_dataEnergyToReduce = dataClass.energyToReduce;
        data.e_dataType = dataClass.elementType;
        data.e_dataPosition = dataClass.transform.position;
        data.e_dataRotation = dataClass.transform.rotation;

        string json = JsonUtility.ToJson(data);

        //upload json data to database here.
    }
}

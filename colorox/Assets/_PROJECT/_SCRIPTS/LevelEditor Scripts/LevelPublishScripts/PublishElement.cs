using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PublishElement : MonoBehaviour {

    public int objectId;

    private StoredEnergy dataClass;
    private PublishManager manager;

    // Use this for initialization
    void Start () {
        dataClass = GetComponent<StoredEnergy>();
        manager = FindObjectOfType<PublishManager>();
	}
	
	public void WriteElementData()
    {
        manager.UploadData(objectId, dataClass.elementType, dataClass.elementColor, dataClass.capacity, dataClass.energyToReduce, dataClass.transform.position, dataClass.transform.rotation);
    }
}

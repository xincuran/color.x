using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditableElement : MonoBehaviour {

    public COLORCODE e_ElementColor;
    public ELEMENT e_type;
    public StoredEnergy e_ElementType;

    public float e_Capacity;
    public float e_EnergyToReduce;

    LevelCreator levelCreator;
    StoredEnergy correspondingElement;

    private void Start()
    {
        levelCreator = FindObjectOfType<LevelCreator>();
    }

    public void SpawnPlayableElements()
    {
        StoredEnergy elementGO = Instantiate(e_ElementType, transform.position, transform.rotation);
        elementGO.transform.SetParent(levelCreator.elementHolder.transform);

        elementGO.capacity = e_Capacity;
        if(elementGO.elementType == ELEMENT.GENERATOR)
        {
            elementGO.currentEnergy = elementGO.capacity;
        }
        if(elementGO.elementType != ELEMENT.COLLECTOR)
        {
            elementGO.energyToReduce = e_EnergyToReduce;
        }
        if(elementGO.elementType != ELEMENT.WATT)
        {
            elementGO.elementColor = e_ElementColor;
            elementGO.SetColorString();
            elementGO.SetColor();
        }
        correspondingElement = elementGO;
        //Create a docker for level creator menu.

        gameObject.SetActive(false);
    }

    public void RemoveCorrespondingElement()
    {
        if(correspondingElement != null)
        {
            Destroy(correspondingElement.gameObject);
        }
    }

    private void OnMouseDown()
    {
        levelCreator.EnableEditMoveMenu(this);

        levelCreator.SetElementEditor();
    }
}

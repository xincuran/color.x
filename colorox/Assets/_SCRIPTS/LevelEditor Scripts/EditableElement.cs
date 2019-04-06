using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditableElement : MonoBehaviour {

    public COLORCODE e_ElementColor;
    public StoredEnergy e_ElementType;

    public float e_Capacity;
    public float e_EnergyToReduce;

    LevelCreator levelCreator;

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
        //Connect reduction variable.
        //Setup Color edit by dropdown.
        //Disable the editing buttons during test.
        //Make an edit level button during test to switch to edit mode without exiting play mode.(try respawning editable elements and destroying
        //actual ones.
        //Make for Collector and Watt as well.

        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        levelCreator.EnableEditMoveMenu(this);
    }
}

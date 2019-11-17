﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementEditor : MonoBehaviour {

    public EditableElement elementEntity;

    [Header("Property UI Elements")]
    public Slider capacitySlider;
    public Slider shootAmountSlider;
    public Slider rotationSlider;
    public Slider lengthSlider;
    public Slider w_rotationSlider;
    public Dropdown colorDropdown;

    #region editor tool control
    private void Update()
    {
        if(elementEntity != null)
        {
            elementEntity.e_Capacity = capacitySlider.value;
            elementEntity.e_EnergyToReduce = shootAmountSlider.value;
            elementEntity.transform.rotation = Quaternion.Euler(Vector3.forward * rotationSlider.value);
            if (elementEntity.e_type == ELEMENT.WATTSLIDER)
            {
                RectTransform entityRect = elementEntity.GetComponent<RectTransform>();
                entityRect.sizeDelta = new Vector2(lengthSlider.value, entityRect.rect.height);
                elementEntity.GetComponentInChildren<Generator>().transform.rotation = Quaternion.Euler(Vector3.forward * w_rotationSlider.value);
            }
        }
    }

    public void SetElementEntity(EditableElement elementToSet)
    {
        elementEntity = elementToSet;

        shootAmountSlider.gameObject.SetActive(true);
        colorDropdown.gameObject.SetActive(true);
        lengthSlider.gameObject.SetActive(false);
        w_rotationSlider.gameObject.SetActive(false);

        capacitySlider.value = elementToSet.e_Capacity;
        shootAmountSlider.value = elementToSet.e_EnergyToReduce;
        rotationSlider.value = elementToSet.transform.localEulerAngles.z;
        lengthSlider.value = elementToSet.GetComponent<RectTransform>().rect.width;
        colorDropdown.value = (int)elementToSet.e_ElementColor;

        if(elementEntity.e_type == ELEMENT.WATT)
        {
            colorDropdown.gameObject.SetActive(false);
        }
        if(elementEntity.e_type == ELEMENT.COLLECTOR)
        {
            shootAmountSlider.gameObject.SetActive(false);
        }
        if (elementEntity.e_type == ELEMENT.WATTSLIDER)
        {
            colorDropdown.gameObject.SetActive(false);
            lengthSlider.gameObject.SetActive(true);
            w_rotationSlider.gameObject.SetActive(true);
            w_rotationSlider.value = elementToSet.GetComponentInChildren<Generator>().transform.localEulerAngles.z;
        }
    }
    #endregion

    public void CloseElementEditor()
    {
        FindObjectOfType<LevelCreator>().levelCreatorMenu.SetActive(true);
        FindObjectOfType<LevelCreator>().levelCreatorMenu.transform.Find("Dock Button").gameObject.SetActive(true);
        FindObjectOfType<LevelCreator>().CloseEditorWindowCommand();
        gameObject.SetActive(false);
    }

    public void DeleteElementButton()
    {
        Destroy(elementEntity.gameObject);
        FindObjectOfType<LevelCreator>().levelCreatorMenu.SetActive(true);
        FindObjectOfType<LevelCreator>().levelCreatorMenu.transform.Find("Dock Button").gameObject.SetActive(true);
        FindObjectOfType<LevelCreator>().CloseEditorWindowCommand();
        gameObject.SetActive(false);
    }

    public void SetEditableElementColor()
    {
        elementEntity.e_ElementColor = (COLORCODE)colorDropdown.value;
        elementEntity.GetComponent<Image>().color = RequiredColorRGBValues.GetColorFromCode((COLORCODE)colorDropdown.value);
    }
}

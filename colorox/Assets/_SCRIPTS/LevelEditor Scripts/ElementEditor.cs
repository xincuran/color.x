using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementEditor : MonoBehaviour {

    public EditableElement elementEntity;

    [Header("Property UI Elements")]
    public Slider capacitySlider;
    public Slider rotationSlider;
    public Dropdown colorDropdown;

    private void Update()
    {
        elementEntity.e_Capacity = capacitySlider.value;
        elementEntity.transform.rotation = Quaternion.Euler(Vector3.forward * rotationSlider.value);
    }

    public void SetElementEntity(EditableElement elementToSet)
    {
        elementEntity = elementToSet;
    }

    public void CloseElementEditor()
    {
        gameObject.SetActive(false);
    }
}

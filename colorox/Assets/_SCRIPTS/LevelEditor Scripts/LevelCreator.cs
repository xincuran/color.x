using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCreator : MonoBehaviour {

    public ElementEditor elementEditor;
    public GameObject elementHolder;
    public GameObject editMoveMenu;

    public List<EditableElement> currentElements = new List<EditableElement>();

    [Header("Elements")]
    public EditableElement generatorPrefab;
    public EditableElement collectorPrefab;
    public EditableElement wattPrefab;

    private EditableElement elementToEdit;
    Plane plane;
    bool isMoving;

    private void Start()
    {
        plane = new Plane(Vector3.forward, transform.position);
    }

    private void Update()
    {
        if (isMoving && Input.touchCount >= 1)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            float enter = 0;
            if(plane.Raycast(ray, out enter))
            {
                elementToEdit.transform.position = ray.GetPoint(enter);
                isMoving = false;
            }
        }

        if (isMoving && Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float enter = 0;
            if (plane.Raycast(ray, out enter))
            {
                elementToEdit.transform.position = ray.GetPoint(enter);
                isMoving = false;
            }
        }
    }

    public void CreateGenerator()
    {
        EditableElement elementGO = Instantiate(generatorPrefab, Vector3.zero, Quaternion.identity);
        elementGO.transform.SetParent(elementHolder.transform);

        currentElements.Add(elementGO);

        EnableEditMoveMenu(elementGO);
        SetElementEditor();
    }

    public void SetElementEditor()
    {
        elementEditor.transform.position = elementToEdit.transform.position + (Vector3.right * 7f);
        elementEditor.SetElementEntity(elementToEdit);
    }

    public void EnableEditMoveMenu(EditableElement elementGO)
    {
        elementToEdit = elementGO;
        editMoveMenu.SetActive(true);
        editMoveMenu.transform.position = elementToEdit.transform.position;
    }

    public void EditButton()
    {
        elementEditor.gameObject.SetActive(true);
        editMoveMenu.SetActive(false);
    }

    public void MoveButton()
    {
        isMoving = true;
        editMoveMenu.SetActive(false);
        elementEditor.gameObject.SetActive(false);
    }

    public void TestButton()
    {
        for (int i = 0; i < currentElements.Count; i++)
        {
            currentElements[i].SpawnPlayableElements();
        }
    }
}

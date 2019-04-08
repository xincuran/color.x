﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCreator : MonoBehaviour {

    [Header("Menus And Windows")]
    public ElementEditor elementEditor;
    public GameObject elementHolder;
    public GameObject editMoveMenu;
    public GameObject levelCreatorMenu;
    public GameObject levelPublishMenu;
    public GameObject instructionsMenu;

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
                levelCreatorMenu.SetActive(true);
                instructionsMenu.transform.Find("MoveInstructions Text").gameObject.SetActive(false);
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
                levelCreatorMenu.SetActive(true);
                instructionsMenu.transform.Find("MoveInstructions Text").gameObject.SetActive(false);
                isMoving = false;
            }
        }
    }

    public void CreateGenerator()
    {
        EditableElement elementGO = Instantiate(generatorPrefab, Vector3.zero, Quaternion.identity);
        ElementCreator(elementGO);
    }

    public void CreateCollector()
    {
        EditableElement elementGO = Instantiate(collectorPrefab, Vector3.zero, Quaternion.identity);
        ElementCreator(elementGO);
    }

    public void CreateWatt()
    {
        EditableElement elementGO = Instantiate(wattPrefab, Vector3.zero, Quaternion.identity);        
        ElementCreator(elementGO);
    }

    private void ElementCreator (EditableElement elementGO)
    {
        elementGO.transform.SetParent(elementHolder.transform);

        currentElements.Add(elementGO);

        EnableEditMoveMenu(elementGO);
        SetElementEditor();
        elementEditor.SetEditableElementColor();
    }

    public void SetElementEditor()
    {
        elementEditor.transform.position = SetEditorWindowPosition(7f, 2.35f);
        elementEditor.SetElementEntity(elementToEdit);
    }

    public void EnableEditMoveMenu(EditableElement elementGO)
    {
        elementToEdit = elementGO;
        editMoveMenu.SetActive(true);
        editMoveMenu.transform.position = SetEditorWindowPosition(1f, 1.74f);
        elementEditor.gameObject.SetActive(false);
    }

    public void EditButton()
    {
        elementEditor.gameObject.SetActive(true);
        editMoveMenu.SetActive(false);
        levelCreatorMenu.SetActive(false);
    }

    public void MoveButton()
    {
        isMoving = true;
        editMoveMenu.SetActive(false);
        elementEditor.gameObject.SetActive(false);
        levelCreatorMenu.SetActive(false);
        instructionsMenu.transform.Find("MoveInstructions Text").gameObject.SetActive(true);
    }

    public void TestButton()
    {
        for (int i = 0; i < currentElements.Count; i++)
        {
            currentElements[i].SpawnPlayableElements();
        }
        levelCreatorMenu.SetActive(false);
        levelPublishMenu.SetActive(true);
    }

    public void EditLevelButton()
    {
        for (int i = 0; i < currentElements.Count; i++)
        {
            currentElements[i].gameObject.SetActive(true);
            currentElements[i].RemoveCorrespondingElement();
        }
        levelCreatorMenu.SetActive(true);
        levelPublishMenu.SetActive(false);
    }

    public void PublishButton()
    {
        //Convert To JSON.
        //UploadToServer.
        //Just add functionality.
        //Check Completion before publishing.
        print("Published.");
    }

    public void BackgroundButton()
    {
        editMoveMenu.SetActive(false);
    }

    private Vector3 SetEditorWindowPosition(float a, float b)
    {
        Vector3 pos = new Vector3();

        if(elementToEdit.transform.position.x < 0)
        {
            pos += elementToEdit.transform.position + (Vector3.right * a);
        }
        if (elementToEdit.transform.position.x >= 0)
        {
            pos += elementToEdit.transform.position - (Vector3.right * a);
        }

        if (elementToEdit.transform.position.y < 0)
        {
            pos += (Vector3.up * b);
        }
        if (elementToEdit.transform.position.y >= 0)
        {
            pos -= (Vector3.up * b);
        }

        return pos;
    }
}

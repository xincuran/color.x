using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PublishManager : MonoBehaviour {

    public InputField levelNameField;
    public InputField playerNameField;

    public PublishElement[] publishElements;

    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void SetPublishElements()
    {
        publishElements = FindObjectsOfType<PublishElement>();
    }

    public void ClosePublishWindow()
    {
        anim.SetTrigger("Down");
    }

    public void SetLevelName()
    {
        //Take help of PublishController and Google API Push Method to Get and Set name here.
        print(levelNameField.text);
    }

    public void SetPlayerName()
    {
        //Take help of PublishController and Google API Push Method to Get and Set name here.
        print(playerNameField.text);
    }

    public void PublishLevelButton()
    {
        for (int i = 0; i < publishElements.Length; i++)
        {
            if(publishElements[i] != null)
            {
                publishElements[i].UploadData();
            }
        }
    }
}

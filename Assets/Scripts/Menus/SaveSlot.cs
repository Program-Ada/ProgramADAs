using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SaveSlot : MonoBehaviour
{
    [Header("Profile")]

    [SerializeField] private string profileId = "";

    [Header("Content")]

    [SerializeField] private GameObject noDataContent;
    [SerializeField] private GameObject hasDataContent;
    [SerializeField] private TextMeshProUGUI percentageCompleteText;
    [SerializeField] private TextMeshProUGUI saveSlotName;

    public string lastScene;
    public bool hasData;

    private Button saveSlotButton;

    public void Awake(){
        saveSlotButton = this.GetComponent<Button>();
    }

    public void SetData(GameData data){
        if(data == null){
            noDataContent.SetActive(true);
            hasDataContent.SetActive(false);
            hasData = false;
        }else{
            noDataContent.SetActive(false);
            hasDataContent.SetActive(true);
            hasData = true;

            saveSlotName.text = data.saveSlotName;
            percentageCompleteText.text = data.totalCompleted + "% Completo";
            lastScene = data.scene;
        }
    }

    public string GetProfileId(){
        return this.profileId;
    }

    public void SetInteractable(bool interactable){
        saveSlotButton.interactable = interactable;
    }
}

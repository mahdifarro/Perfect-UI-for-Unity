using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneUIManager : MonoBehaviour
{
    [Serializable]
    public class ButtonCombo
    {
        public string ButtonName = "Defualt";
        public Button[] assignedButtonsList;
        public UnityEvent eventForButton;
    }

    [SerializeField]
    private ButtonCombo[] _buttonComboArray;
    [SerializeField]
    private UnityEvent screenRotationEvent;

    private DeviceOrientation pastOrientation = DeviceOrientation.Portrait;


    private void Awake()
    {
        AssignButtons();
    }

    private void Update()
    {
        if (pastOrientation == Input.deviceOrientation)
        {
            return;
        }

        if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft)
        {
            Screen.orientation = ScreenOrientation.LandscapeLeft;
        }
        else if (Input.deviceOrientation == DeviceOrientation.Portrait)
        {
            Screen.orientation = ScreenOrientation.Portrait;
        }
        else
        {
            return;
        }

        screenRotationEvent.Invoke();
        pastOrientation = Input.deviceOrientation;
    }


    public void ChangeGameObjectActiveState(GameObject targetGameObject)
    {
        targetGameObject.SetActive(!targetGameObject.activeSelf);
    }

    public void ChangeButtonEnableState(Button targetButton)
    {
        targetButton.interactable = !targetButton.interactable;
    }

    public void ChangeScreenOrientation()
    {
        if (Screen.orientation == ScreenOrientation.Portrait)
        {
            Screen.orientation = ScreenOrientation.LandscapeLeft;
        }
        else if (Screen.orientation == ScreenOrientation.LandscapeLeft)
        {
            Screen.orientation = ScreenOrientation.Portrait;
        }
        else
        {
            return;
        }
        screenRotationEvent.Invoke();
    }

    private void AssignButtons()
    {
        foreach (var buttonCombo in _buttonComboArray)
        {
            foreach (var b in buttonCombo.assignedButtonsList)
            {
                b.onClick.AddListener(() => buttonCombo.eventForButton.Invoke());
            }
        }
    }
}

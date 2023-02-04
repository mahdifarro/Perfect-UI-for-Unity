using System;
using System.Collections;
using System.Collections.Generic;
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

    private void Awake()
    {
        AssignButtons();
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
        else
        {
            Screen.orientation = ScreenOrientation.Portrait;
        }
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

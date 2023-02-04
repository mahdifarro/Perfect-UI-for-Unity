using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
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

    public void ChangeEnableState(GameObject targetGameObject)
    {
        targetGameObject.SetActive(!targetGameObject.activeSelf);

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

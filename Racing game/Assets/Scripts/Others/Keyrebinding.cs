using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Keyrebinding : MonoBehaviour
{
    [SerializeField]
    InputActionReference inputActionReference;

    [SerializeField]
    bool excludeMouse = true;
    [Range(0,10)]
    [SerializeField]
    int selectedBinding;
    [SerializeField]
    InputBinding.DisplayStringOptions displayStringOptions;
    [SerializeField]
    InputBinding inputBinding;
    int bindingIndex;

    string actionName;

    [SerializeField]
    Text actionText;
    [SerializeField]
    Button rebindButton;
    [SerializeField]
    Text rebindText;
    [SerializeField]
    Button resetButton;

    private void OnEnable()
    {
        rebindButton.onClick.AddListener(() => DoRebind());
        resetButton.onClick.AddListener(() => ResetBinding());

        if(inputActionReference != null)
        {
            GetBindingInfo();
            UpdateGUI();
        }
    }
    private void OnValidate()
    {
        if(inputActionReference == null)
        {
            return;
        }
       GetBindingInfo();
       UpdateGUI();
    }

    void GetBindingInfo()
    {
        if (inputActionReference.action != null)
            actionName = inputActionReference.action.name;

        if(inputActionReference.action.bindings.Count > selectedBinding)
        {
            inputBinding = inputActionReference.action.bindings[selectedBinding];
            bindingIndex = selectedBinding;
        }
    }

    void UpdateGUI()
    {
        if (actionText != null)
        {
            actionText.text = actionName;
        }

        if (rebindText != null)
        {
            if(Application.isPlaying)
            {

            }
            else
            {
                rebindText.text = inputActionReference.action.GetBindingDisplayString(bindingIndex);
            }
        }
    }

    void DoRebind()
    {

    }

    void ResetBinding()
    {

    }
}

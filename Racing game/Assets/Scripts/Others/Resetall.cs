using UnityEngine;
using UnityEngine.InputSystem;

public class Resetall : MonoBehaviour
{
    [SerializeField]
    private InputActionAsset inputActions;

    public void ResetBinding()
    {
        foreach (InputActionMap map in inputActions.actionMaps)
        {
            map.RemoveAllBindingOverrides();
        }
    }
}

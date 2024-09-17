using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class RayActivation : MonoBehaviour
{
    public XRRayInteractor rayInteractor; // Reference to the XR Ray Interactor
    public InputActionProperty gripInputAction; // Reference to the grip input action

    private void Update()
    {
        // Enable the ray when the grip button is pressed
        if (gripInputAction.action.ReadValue<float>() > 0.1f)
        {
            rayInteractor.enabled = true;
        }
        else
        {
            rayInteractor.enabled = false;
        }
    }
}
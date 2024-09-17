using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit.AffordanceSystem.State;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class HoverWithJoystick : MonoBehaviour
{
    public TextMeshPro hoverText; // Reference to the TextMeshPro component
    public XRRayInteractor rayInteractor; // Reference to the XR Ray Interactor
    public InputActionProperty joystickInputAction; // Reference to the joystick input action
    public Vector3 textOffset = new Vector3(0, 0.2f, 0); // Offset from the object

    private XRBaseInteractable currentInteractable;

    private void Start()
    {
        if (hoverText != null)
        {
            hoverText.gameObject.SetActive(false); // Hide text initially
        }
    }

    private void Update()
    {
        Vector2 joystickValue = joystickInputAction.action.ReadValue<Vector2>();

        if (joystickValue.y > 0.5f) // If joystick is pushed up
        {
            if (rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
            {
                currentInteractable = hit.transform.GetComponent<XRBaseInteractable>();

                if (currentInteractable != null)
                {
                    // Position the text close to the interactable object
                    hoverText.transform.position = currentInteractable.transform.position + textOffset;
                    hoverText.gameObject.SetActive(true);
                }
            }
        }
        else
        {
            if (hoverText != null)
            {
                hoverText.gameObject.SetActive(false); // Hide text when joystick is not pushed up
            }
        }
    }
}
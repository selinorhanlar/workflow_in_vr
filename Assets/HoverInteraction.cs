using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.InputSystem;

public class HoverInteraction : MonoBehaviour
{
    public TextMeshPro hoverText; // Reference to the TextMeshPro component
    public XRRayInteractor rayInteractor; // Reference to the XR Ray Interactor
    public InputActionProperty gripInputAction; // Reference to the grip input action
    public Vector3 textOffset = new Vector3(0, 0.1f, 0); // Offset from the ray hit point

    private void Start()
    {
        if (hoverText != null)
        {
            hoverText.gameObject.SetActive(false); // Hide text initially
        }
        rayInteractor.enabled = false; // Disable the ray initially
    }

    private void Update()
    {
        bool isGripPressed = gripInputAction.action.ReadValue<float>() > 0.1f;

        if (isGripPressed)
        {
            if (rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
            {
                // Check if the hit object is the one you want to interact with
                if (hit.transform == this.transform)
                {
                    rayInteractor.enabled = true; // Enable the ray
                    hoverText.transform.position = hit.point + textOffset; // Position the text near the hit point
                    hoverText.gameObject.SetActive(true); // Show the text
                }
                else
                {
                    rayInteractor.enabled = false; // Disable the ray if not pointing at the object
                    hoverText.gameObject.SetActive(false); // Hide the text
                }
            }
            else
            {
                rayInteractor.enabled = false; // Disable the ray if not hitting anything
                hoverText.gameObject.SetActive(false); // Hide the text
            }
        }
        else
        {
            rayInteractor.enabled = false; // Disable the ray if the grip isn't pressed
            hoverText.gameObject.SetActive(false); // Hide the text
        }
    }
}

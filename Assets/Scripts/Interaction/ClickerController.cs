using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ClickerController : MonoBehaviour
{
    public SlideShowController slideShowController;
    public InputActionReference nextSlideAction;

    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;
    private bool isHeld = false;

    private void Awake()
    {
        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
    }

    private void OnEnable()
    {
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.AddListener(OnGrab);
            grabInteractable.selectExited.AddListener(OnRelease);
        }

        if (nextSlideAction != null)
            nextSlideAction.action.Enable();
    }

    private void OnDisable()
    {
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(OnGrab);
            grabInteractable.selectExited.RemoveListener(OnRelease);
        }

        if (nextSlideAction != null)
            nextSlideAction.action.Disable();
    }

    private void Update()
    {
        if (isHeld && nextSlideAction != null && nextSlideAction.action.WasPressedThisFrame())
        {
            slideShowController?.NextSlide();
        }
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        isHeld = true;
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        isHeld = false;
    }
}
using UnityEngine;
using System.Collections;

public class DoorOpenTrigger : MonoBehaviour
{
    public Transform leftDoorHinge;
    public Transform rightDoorHinge;

    public float openAngle = 90f;
    public float openSpeed = 2f;

    public Transform teleportTarget;
    public float teleportDelay = 2f;

    public AudioSource crowdAudioSource;
    public float crowdPlayDuration = 2f;

    private bool hasTriggered = false;
    private bool shouldOpen = false;

    private Quaternion leftTargetRotation;
    private Quaternion rightTargetRotation;

    private void Start()
    {
        if (leftDoorHinge != null)
            leftTargetRotation = leftDoorHinge.rotation * Quaternion.Euler(0f, -openAngle, 0f);

        if (rightDoorHinge != null)
            rightTargetRotation = rightDoorHinge.rotation * Quaternion.Euler(0f, openAngle, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (hasTriggered) return;

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered door trigger");
            hasTriggered = true;
            shouldOpen = true;

            // Get the XR Origin root via CharacterController
            CharacterController cc = other.GetComponentInParent<CharacterController>();
            Transform playerRoot = cc != null ? cc.transform : other.transform;

            StartCoroutine(HandleDoorSequence(playerRoot, cc));
        }
    }

    private void Update()
    {
        if (!shouldOpen) return;

        if (leftDoorHinge != null)
        {
            leftDoorHinge.rotation = Quaternion.Slerp(
                leftDoorHinge.rotation,
                leftTargetRotation,
                Time.deltaTime * openSpeed
            );
        }

        if (rightDoorHinge != null)
        {
            rightDoorHinge.rotation = Quaternion.Slerp(
                rightDoorHinge.rotation,
                rightTargetRotation,
                Time.deltaTime * openSpeed
            );
        }
    }

    private IEnumerator HandleDoorSequence(Transform playerRoot, CharacterController cc)
    {
        if (crowdAudioSource != null)
            crowdAudioSource.Play();

        yield return new WaitForSeconds(crowdPlayDuration);

        if (crowdAudioSource != null && crowdAudioSource.isPlaying)
            crowdAudioSource.Stop();

        float remainingDelay = teleportDelay - crowdPlayDuration;
        if (remainingDelay > 0f)
            yield return new WaitForSeconds(remainingDelay);

        if (teleportTarget != null)
        {
            if (cc != null) cc.enabled = false;
            playerRoot.position = teleportTarget.position;
            if (cc != null) cc.enabled = true;
        }
    }
}
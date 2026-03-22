using UnityEngine;

public class SecondTriggerZone : MonoBehaviour
{
    public GameObject targetObject;
    public AudioSource audioSource;

    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasTriggered) return;

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered second trigger zone");

            hasTriggered = true;

            if (targetObject != null)
            {
                targetObject.SetActive(true);
            }

            if (audioSource != null)
            {
                audioSource.Play();
            }
        }
    }
}
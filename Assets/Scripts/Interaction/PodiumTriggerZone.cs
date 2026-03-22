using UnityEngine;

public class PodiumTriggerZone : MonoBehaviour
{
    public GameObject targetObject;
    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasTriggered) return;

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered podium zone");

            hasTriggered = true;

            if (targetObject != null)
            {
                targetObject.SetActive(true);
            }
        }
    }
}
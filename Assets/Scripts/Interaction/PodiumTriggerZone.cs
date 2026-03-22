using UnityEngine;

public class PodiumTriggerZone : MonoBehaviour
{
    public GameObject targetObject;
    public AudioSource stageAmbientAudio;
    public LimitedMicAdjuster micAdjuster;

    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasTriggered) return;

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered podium zone");

            hasTriggered = true;

            if (stageAmbientAudio != null && stageAmbientAudio.isPlaying)
            {
                stageAmbientAudio.Stop();
            }

            if (targetObject != null)
            {
                targetObject.SetActive(true);
            }

            if (micAdjuster != null)
            {
                micAdjuster.EnableAdjustment();
            }
        }
    }
}
using UnityEngine;

public class StageArrivalTrigger : MonoBehaviour
{
    public AudioSource crowdAudioSource;        // short cheering cue from door sequence
    public AudioSource stageAmbientAudioSource; // subtle loop after arrival
    public GameObject podiumUI;

    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasTriggered) return;

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player reached stage");

            hasTriggered = true;

            if (crowdAudioSource != null && crowdAudioSource.isPlaying)
            {
                crowdAudioSource.Stop();
            }

            if (stageAmbientAudioSource != null && !stageAmbientAudioSource.isPlaying)
            {
                stageAmbientAudioSource.Play();
            }

            if (podiumUI != null)
            {
                podiumUI.SetActive(true);
            }
        }
    }
}
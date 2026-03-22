using UnityEngine;

public class PresentationController : MonoBehaviour
{
    public Light mainLight;
    public Light[] stageLights;

    public float dimIntensity = 0.2f;
    public float stageIntensity = 2.0f;

    private float originalMainIntensity;

    void Start()
    {
        if (mainLight != null)
            originalMainIntensity = mainLight.intensity;
    }

    public void StartPresentation()
    {
        // Dim global light
        if (mainLight != null)
            mainLight.intensity = dimIntensity;

        // Boost stage lights
        foreach (Light l in stageLights)
        {
            if (l != null)
                l.intensity = stageIntensity;
        }

        Debug.Log("Presentation lighting activated");
    }
}
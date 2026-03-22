using UnityEngine;

public class SlideShowController : MonoBehaviour
{
    public GameObject[] slides;
    private int currentSlide = 0;

    void Start()
    {
        ShowSlide(0);
    }

    public void NextSlide()
    {
        if (slides == null || slides.Length == 0) return;

        currentSlide++;
        if (currentSlide >= slides.Length)
            currentSlide = slides.Length - 1;

        ShowSlide(currentSlide);
        Debug.Log("Showing slide: " + currentSlide);
    }

    public void PreviousSlide()
    {
        if (slides == null || slides.Length == 0) return;

        currentSlide--;
        if (currentSlide < 0)
            currentSlide = 0;

        ShowSlide(currentSlide);
        Debug.Log("Showing slide: " + currentSlide);
    }

    private void ShowSlide(int index)
    {
        for (int i = 0; i < slides.Length; i++)
        {
            if (slides[i] != null)
                slides[i].SetActive(i == index);
        }
    }
}
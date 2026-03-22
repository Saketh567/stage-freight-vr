using UnityEngine;
using UnityEngine.InputSystem;

public class LimitedMicAdjuster : MonoBehaviour
{
    public float moveSpeed = 0.25f;
    public float minY = 0.9f;
    public float maxY = 1.15f;

    private bool canAdjust = false;

    private void Update()
    {
        if (!canAdjust) return;
        if (Keyboard.current == null) return;

        float moveInput = 0f;

        if (Keyboard.current.eKey.isPressed)
        {
            moveInput = 1f;
        }
        else if (Keyboard.current.qKey.isPressed)
        {
            moveInput = -1f;
        }

        if (moveInput != 0f)
        {
            Vector3 pos = transform.localPosition;
            pos.y += moveInput * moveSpeed * Time.deltaTime;
            pos.y = Mathf.Clamp(pos.y, minY, maxY);
            transform.localPosition = pos;
        }
    }

    public void EnableAdjustment()
    {
        canAdjust = true;
        Debug.Log("Mic adjustment enabled");
    }

    public void DisableAdjustment()
    {
        canAdjust = false;
        Debug.Log("Mic adjustment disabled");
    }
}
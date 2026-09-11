using UnityEngine;

public class TouchRotate : MonoBehaviour
{
    public float autoRotateSpeed = 20f;
    public float touchRotateSpeed = 0.2f;

    private Vector2 lastTouchPosition;
    private bool isDragging = false;

    void Update()
    {
        // Auto Rotate
        transform.Rotate(Vector3.up * autoRotateSpeed * Time.deltaTime);

        // Touch Rotate Android
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                lastTouchPosition = touch.position;
                isDragging = true;
            }

            else if (touch.phase == TouchPhase.Moved && isDragging)
            {
                Vector2 delta = touch.position - lastTouchPosition;

                transform.Rotate(Vector3.up, -delta.x * touchRotateSpeed);

                lastTouchPosition = touch.position;
            }

            else if (touch.phase == TouchPhase.Ended)
            {
                isDragging = false;
            }
        }
    }
}
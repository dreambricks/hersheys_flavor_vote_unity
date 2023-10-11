using UnityEngine;

public class MoveUIWithArrows : MonoBehaviour
{
    public float moveSpeed = 10f; // Adjust the speed as needed
    private RectTransform rectTransform;

    private void Start()
    {
        // Get the RectTransform component of the UI element
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        // Get arrow key inputs
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the new position
        Vector2 newPosition = rectTransform.anchoredPosition + new Vector2(horizontalInput, verticalInput) * moveSpeed * Time.deltaTime;

        // Update the RectTransform's position
        rectTransform.anchoredPosition = newPosition;
    }
}

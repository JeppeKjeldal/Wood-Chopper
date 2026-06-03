using UnityEngine;

public class SellResources : MonoBehaviour
{
    public GameObject sellMenuPanel; // Drag your UI Shop Panel here

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sellMenuPanel.SetActive(true);
            // Optional: Unlock the mouse cursor so you can click "Sell"
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sellMenuPanel.SetActive(false);
            // Re-lock the cursor for gameplay
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}

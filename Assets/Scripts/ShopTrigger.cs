using UnityEngine;

public class ShopTrigger : MonoBehaviour
{
    public GameObject shopMenuPanel; // Drag your UI Shop Panel here

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            shopMenuPanel.SetActive(true);
            // Optional: Unlock the mouse cursor so you can click "Sell"
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            shopMenuPanel.SetActive(false);
            // Re-lock the cursor for gameplay
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
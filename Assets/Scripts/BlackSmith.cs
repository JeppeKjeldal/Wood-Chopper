using UnityEngine;

public class BlackSmith : MonoBehaviour
{
    public GameObject upgradeMenuPanel; // Drag your UI Shop Panel here

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            upgradeMenuPanel.SetActive(true);
            // Optional: Unlock the mouse cursor so you can click "Sell"
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            upgradeMenuPanel.SetActive(false);
            // Re-lock the cursor for gameplay
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}

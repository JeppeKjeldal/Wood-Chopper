using StarterAssets;
using UnityEngine;

public class ShopTrigger : MonoBehaviour
{
    [SerializeField] private GameObject shopMenuPanel;

    private StarterAssetsInputs input;

    private void Awake()
    {
        // Added this so the script knows what 'input' is
        input = FindAnyObjectByType<StarterAssetsInputs>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            shopMenuPanel.SetActive(true);
            // Changed to FALSE to unlock the mouse for the shop
            if (input != null) input.SetCursorState(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            shopMenuPanel.SetActive(false);
            // Changed to TRUE to lock the mouse for gameplay
            if (input != null) input.SetCursorState(true);
        }
    }
}
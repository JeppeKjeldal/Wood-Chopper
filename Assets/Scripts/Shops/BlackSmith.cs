using StarterAssets;
using UnityEngine;

public class BlackSmith : MonoBehaviour
{
    public GameObject upgradeMenuPanel;
    private StarterAssetsInputs input;

    private void Awake()
    {
        input = FindAnyObjectByType<StarterAssetsInputs>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            upgradeMenuPanel.SetActive(true);
            // False = Show mouse, freeze camera
            if (input != null) input.SetCursorState(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            upgradeMenuPanel.SetActive(false);
            // True = Hide mouse, enable camera
            if (input != null) input.SetCursorState(true);
        }
    }
}
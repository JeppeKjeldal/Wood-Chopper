using UnityEngine;
using TMPro;

public class ResourceManager : MonoBehaviour
{
    // The "Static Instance" that makes this a Singleton
    public static ResourceManager Instance { get; private set; }

    [Header("UI References")]
    [SerializeField] private TMP_Text woodText;
    [SerializeField] private TMP_Text stoneText;

    private int amountOfWood;
    private int amountOfStone;

    private void Awake()
    {
        // Singleton Pattern: Ensure only one instance exists
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        // Initialize UI
        UpdateUI();
    }

    public void AddResource(string type, int amount)
    {
        if (type == "Wood") amountOfWood += amount;
        else if (type == "Stone") amountOfStone += amount;

        UpdateUI();
    }

    private void UpdateUI()
    {
        if (woodText != null) woodText.text = "Wood: " + amountOfWood;
        if (stoneText != null) stoneText.text = "Stone: " + amountOfStone;
    }
}
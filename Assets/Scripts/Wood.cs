using UnityEngine;
using TMPro;

public class Wood : MonoBehaviour
{
    [SerializeField] private TMP_Text woodText;

    private int amountOfWood;

    private void Awake()
    {
        // Ensure the UI shows 0 immediately when the game starts
        amountOfWood = 0;
        UpdateWoodUI();
    }

    public void AddWood(int amount)
    {
        // Increase the total wood count
        amountOfWood += amount;

        // Update the UI text to show the new amount
        UpdateWoodUI();
    }

    // A helper method to keep the code clean and reusable
    private void UpdateWoodUI()
    {
        if (woodText != null)
        {
            woodText.text = "Wood: " + amountOfWood;
        }
    }
}
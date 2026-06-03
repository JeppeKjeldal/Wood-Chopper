using UnityEngine;
using TMPro;

public class ResourceManager : MonoBehaviour, IDataPersistence
{
    // The "Static Instance" that makes this a Singleton
    public static ResourceManager Instance { get; private set; }

    [Header("UI References")]
    [SerializeField] private TMP_Text woodText;
    [SerializeField] private TMP_Text stoneText;
    [SerializeField] private TMP_Text goldText;

    private int amountOfGold;
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

    // Call this from the Shop
    public void SellResources(int woodValue, int stoneValue)
    {
        // Calculate gold based on current wood and stone
        int earnedGold = (amountOfWood * woodValue) + (amountOfStone * stoneValue);

        amountOfGold += earnedGold;

        // Reset resources after selling
        amountOfWood = 0;
        amountOfStone = 0;

        UpdateUI();
    }

    public void OnClickSellAll()
    {
        // Wood sells for 2 gold, Stone for 5
        ResourceManager.Instance.SellResources(2, 5);
    }

    private void UpdateUI()
    {
        if (woodText != null) woodText.text = "Wood: " + amountOfWood;
        if (stoneText != null) stoneText.text = "Stone: " + amountOfStone;
        if (goldText != null) goldText.text = "Gold: " + amountOfGold;
    }

    public bool TrySpendGold(int amount)
    {
        if (amountOfGold >= amount)
        {
            amountOfGold -= amount;
            UpdateUI();
            return true; // Purchase successful
        }
        return false; // Too poor!
    }

    public void LoadData(GameData data)
    {
        this.amountOfGold = data.gold;
        this.amountOfWood = data.wood;
        this.amountOfStone = data.stone;
        UpdateUI();
    }

    public void SaveData(ref GameData data)
    {
        data.gold = this.amountOfGold;
        data.wood = this.amountOfWood;
        data.stone = this.amountOfStone;
        UpdateUI();
    }
}
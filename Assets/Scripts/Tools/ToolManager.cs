using StarterAssets;
using UnityEngine;

public class ToolManager : MonoBehaviour
{
    [Header("Upgrades")]
    public int upgradeCost = 50;
    public float costMultiplier = 1.5f;

    public GameObject axeModel;
    public GameObject pickaxeModel;

    private Swing swingScript;
    private StarterAssetsInputs inputs;
    private int currentSlot = -1; // Track current slot to prevent redundant switching

    private void Awake()
    {
        swingScript = GetComponent<Swing>();
        inputs = GetComponentInParent<StarterAssetsInputs>();
    }

    private void Start() => SelectTool(1);

    private void Update()
    {
        // Check for Slot 1 press
        if (inputs.slot1)
        {
            if (currentSlot != 1) SelectTool(1);
            inputs.slot1 = false; // Reset the bool so it doesn't trigger every frame
        }

        // Check for Slot 2 press
        if (inputs.slot2)
        {
            if (currentSlot != 2) SelectTool(2);
            inputs.slot2 = false;
        }
    }

    void SelectTool(int slot)
    {
        currentSlot = slot;

        // Toggle models
        axeModel.SetActive(slot == 1);
        pickaxeModel.SetActive(slot == 2);

        // Update the tool data on the Swing script
        if (slot == 1)
            swingScript.equippedTool = axeModel.GetComponent<Tool>();
        else
            swingScript.equippedTool = pickaxeModel.GetComponent<Tool>();

        Debug.Log("Switched to tool in slot: " + slot);
    }

    public void UpgradeTools()
    {
        if (ResourceManager.Instance.TrySpendGold(upgradeCost))
        {
            // 1. Increase Damage on all tools (or the current one)
            // You can loop through your tools and add damage
            axeModel.GetComponentInChildren<Tool>().damage += 1;
            pickaxeModel.GetComponentInChildren<Tool>().damage += 1;

            // 2. Increase the cost for the next upgrade
            upgradeCost = Mathf.RoundToInt(upgradeCost * costMultiplier);

            Debug.Log("Tools Upgraded! New Cost: " + upgradeCost);
        }
        else
        {
            Debug.Log("Not enough gold!");
        }
    }
}
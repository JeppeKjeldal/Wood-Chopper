using StarterAssets;
using UnityEngine;

public class Swing : MonoBehaviour
{
    [Header("Setup")]
    public Tool equippedTool; // Set by ToolManager when you swap tools

    private StarterAssetsInputs starterAssetsInputs;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        // Look in parent for the inputs (assuming StarterAssets is on the Player root)
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
    }

    private void Update()
    {
        // Basic check to ensure we have input and a tool to swing
        if (starterAssetsInputs != null && starterAssetsInputs.swing)
        {
            animator.SetTrigger("swing");
            starterAssetsInputs.SwingInput(false);
        }
    }

    public void CheckHit() // Called by the Animation Event on the WeaponHolder
    {
        // If we aren't holding anything, don't do anything
        if (equippedTool == null) return;

        RaycastHit hit;
        float interactDistance = 2.5f;

        // Perform the Raycast from the Camera's position/forward
        // NOTE: Use Camera.main if the WeaponHolder is offset and doesn't face forward perfectly
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactDistance))
        {
            ResourceNode node = hit.transform.GetComponent<ResourceNode>();

            if (node != null)
            {
                // Check if the tool matches the resource node type
                if (node.nodeType == equippedTool.toolType)
                {
                    node.TakeDamage(equippedTool.damage);
                }
                else
                {
                    Debug.Log("Wrong tool! This is " + node.nodeType + " but you have a " + equippedTool.toolType + " tool.");
                }
            }
        }
    }
}
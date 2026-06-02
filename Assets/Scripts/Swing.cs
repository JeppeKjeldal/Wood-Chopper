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
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
    }

    private void Update()
    {
        if (starterAssetsInputs != null && starterAssetsInputs.swing)
        {
            animator.SetTrigger("swing");
            starterAssetsInputs.SwingInput(false);
        }
    }

    public void CheckHit() // Called by the Animation Event on the WeaponHolder
    {
        if (equippedTool == null) return;

        RaycastHit hit;
        float interactDistance = 2.5f;

        if (Physics.Raycast(transform.position, transform.forward, out hit, interactDistance))
        {
            ResourceNode node = hit.transform.GetComponent<ResourceNode>();

            if (node != null)
            {
                // Note: Ensure your equippedTool.toolType matches the ResourceNode.ResourceType enum structure
                if ((int)node.nodeType == (int)equippedTool.toolType)
                {
                    node.TakeDamage(equippedTool.damage);

                    // FIXED: Call the sound function with the node
                    PlayHitSound(node);
                }
                else
                {
                    Debug.Log("Wrong tool! This is " + node.nodeType + " but you have a " + equippedTool.toolType + " tool.");
                }
            }
        }
    }

    // FIXED: Uses the exact ResourceNode class and its internal ResourceType enum
    private void PlayHitSound(ResourceNode node)
    {
        if (SoundManager.Instance == null) return;

        // Directly checks the enum from your ResourceNode script
        if (node.nodeType == ResourceNode.ResourceType.Wood)
        {
            SoundManager.Instance.PlayWoodSound();
        }
        else if (node.nodeType == ResourceNode.ResourceType.Stone)
        {
            SoundManager.Instance.PlayStoneSound();
        }
    }
}
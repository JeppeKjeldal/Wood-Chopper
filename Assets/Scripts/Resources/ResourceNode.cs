using UnityEngine;

public class ResourceNode : MonoBehaviour
{
    // This creates a dropdown menu in the Inspector
    public enum ResourceType { Wood, Stone }

    [Header("Settings")]
    public ResourceType nodeType;
    public int health = 3;
    public GameObject lootPrefab; // The Log or Stone item that drops

    public void TakeDamage(int amount)
    {
        health -= amount;
        Debug.Log(nodeType + " hit! Health remaining: " + health);

        if (health <= 0)
        {
            BreakNode();
        }
    }

    private void BreakNode()
    {
        if (lootPrefab != null)
        {
            // Instantiate with the new rotation
            Instantiate(lootPrefab, transform.position + Vector3.up, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}
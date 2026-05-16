using UnityEngine;

public class Collectible : MonoBehaviour
{
    public enum ResourceType { Wood, Stone }
    public ResourceType type;

    public int amount = 5;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ResourceManager.Instance.AddResource(type.ToString(), amount);

            Destroy(gameObject);
        }
    }
}
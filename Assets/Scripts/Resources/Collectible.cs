using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private int amount = 5;

    public enum ResourceType { Wood, Stone }
    public ResourceType type;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ResourceManager.Instance.AddResource(type.ToString(), amount);

            Destroy(gameObject);
        }
    }
}
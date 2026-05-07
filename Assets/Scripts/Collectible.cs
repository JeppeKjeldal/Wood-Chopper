using UnityEngine;

public class Collectible : MonoBehaviour
{
    public enum ResourceType { Wood, Stone }
    public ResourceType type;

    public int amount = 1;
    public float rotationSpeed = 1f;

    void Update()
    {
        transform.Rotate(rotationSpeed, 0 * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        // We check if the player hit the trigger
        if (other.CompareTag("Player"))
        {
            // Talk directly to the Singleton!
            ResourceManager.Instance.AddResource(type.ToString(), amount);

            Destroy(gameObject);
        }
    }
}
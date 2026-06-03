using UnityEngine;

public class TreeHealth : MonoBehaviour
{
    private int startingHealth = 3;

    private int currentHealth;

    private void Awake()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log(currentHealth);

        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}

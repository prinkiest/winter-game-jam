using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public GameObject healthBar;

    public int maxHealth;
    public int health;

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    public void Die()
    {
        Debug.Log($"{gameObject} died. Max health: {maxHealth}.");
    }
}

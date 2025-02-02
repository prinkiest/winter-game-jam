using UnityEngine;

public class Enemy : MonoBehaviour
{
    public HealthComponent health;

    private void Start()
    {
        health = GetComponent<HealthComponent>();
        health.onDeath += Die;
    }

    private void Update()
    {
        // TODO : Chasing player, attacking and etc.
    }
    void Die()
    {
        // TODO : ANIMATION
    }
}

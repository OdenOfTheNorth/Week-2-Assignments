using UnityEngine;


public class UnitHealth : MonoBehaviour
{
    [SerializeField] public float maxHealth = 100.0f;

    public float currentHealth = 0.0f;
    public delegate void UnitDied();
    public delegate void HealthChanged(float maxHealth, float currentHeatlh);
    public HealthChanged OnHealthChanged;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        OnHealthChanged?.Invoke(maxHealth, currentHealth);

        if (currentHealth <= 0.0f)
        {
            Destroy(gameObject);
            //OnUnitDied?.Invoke();
        }
        else if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}

using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class UnitHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100.0f;

    private float currentHealth = 0.0f;

    public delegate void UnitDied();
    public UnitDied OnUnitDied;

    public delegate void HealthChanged(float maxHealth, float currentHeatlh);
    public HealthChanged OnHealthChanged;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        /*
        if (healthRegeneration > Mathf.Epsilon)
        {
            TakeDamage(-healthRegeneration * Time.deltaTime);
        }
        */
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        OnHealthChanged?.Invoke(maxHealth, currentHealth);


        if (currentHealth <= 0.0f)
        {
            OnUnitDied?.Invoke();
        }
        else if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}

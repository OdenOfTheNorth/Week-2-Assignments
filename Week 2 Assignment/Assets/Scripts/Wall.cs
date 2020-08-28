using UnityEngine;


public class Wall : MonoBehaviour
{
    public Wall_Info wallInfo;
    public float currentHealth = 0.0f;
    public delegate void HealthChanged(float maxHealth, float currentHeatlh);
    public HealthChanged OnHealthChanged;
    
    private Material material;
    private float maxHealth;
    private GameObject objectToReplaceMaterial;

    
    private void Awake()
    {
        material = wallInfo.material;
        maxHealth = wallInfo.maxHealth;
        currentHealth = maxHealth;
        objectToReplaceMaterial = gameObject;
        objectToReplaceMaterial.GetComponent<MeshRenderer> ().material = material;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        OnHealthChanged?.Invoke(maxHealth, currentHealth);

        if (currentHealth <= 0.0f)
        {
            Destroy(gameObject);
        }
        else if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}

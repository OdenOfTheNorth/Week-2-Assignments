using System;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class Wall : MonoBehaviour
{
    public Wall_Info wallInfo;
    public float currentHealth = 0.0f;
    public delegate void HealthChanged(float maxHealth, float currentHeatlh);
    public HealthChanged OnHealthChanged;
    
    private Material material;
    private float maxHealth;
    private GameObject objectToReplaceMaterial;
    private AudioClip damageSound;

    private void Start()
    {
      
    }

    private void Awake()
    {
        damageSound = wallInfo.damageSound;
        material = wallInfo.material;
        maxHealth = wallInfo.maxHealth;
        currentHealth = maxHealth;
        objectToReplaceMaterial = gameObject;
        objectToReplaceMaterial.GetComponent<MeshRenderer> ().material = material;
       

    }

    private void Update()
    {

    }

    public void TakeDamage(float damage)
    {

        currentHealth -= damage;
        OnHealthChanged?.Invoke(maxHealth, currentHealth);
        
        if (currentHealth <= 0.0f)
        {
            AudioSource.PlayClipAtPoint(damageSound, transform.position);
            Destroy(gameObject);
            
        }
        else if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}

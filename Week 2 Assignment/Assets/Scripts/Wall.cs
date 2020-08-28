using UnityEngine;

public class Wall : MonoBehaviour
{
    public Wall_Info wallInfo;
    public float currentHealth = 0.0f;
    
    private Material material;
    private float maxHealth;
    private GameObject objectToReplaceMaterial;
    private AudioClip damageSound;
    private AudioClip deathSound;

    private void Start()
    {
      
    }

    private void Awake()
    {
        damageSound = wallInfo.damageSound;
        deathSound = wallInfo.deathSound;
        material = wallInfo.material;
        maxHealth = wallInfo.maxHealth;
        currentHealth = maxHealth;
        objectToReplaceMaterial = gameObject;
        objectToReplaceMaterial.GetComponent<MeshRenderer> ().material = material;
    }

    public void TakeDamage(float damage)
    {
        var temp = currentHealth;
        currentHealth -= damage;
        
        if (currentHealth == temp)
        {
         return;   
        }
        if (currentHealth > 0)
        {
            AudioSource.PlayClipAtPoint(damageSound, transform.position);
        }
        
        if (currentHealth <= 0.0f)
        {
            AudioSource.PlayClipAtPoint(deathSound, transform.position);
            Destroy(gameObject);
            
        }
        else if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}

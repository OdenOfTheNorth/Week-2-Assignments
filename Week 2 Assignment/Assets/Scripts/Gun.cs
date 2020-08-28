using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 15f;
    public float range = 100f;
    public Camera fpsCam;
    public Transform barrelEnd;

    private float maxDamage;
    
    
    private void Awake()
    {
        maxDamage = damage;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        RaycastHit[] hits;
        hits = (Physics.RaycastAll(barrelEnd.transform.position, barrelEnd.transform.forward, range));
        GameObject[] wallHits = new GameObject[hits.Length];
        
        if (hits.Length <= 0)
        {
            return;
        }

        for (int i = 0; i < hits.Length; i++)
        {
            wallHits[i] = hits[i].collider.gameObject;
        }

        wallHits = SortByDistance(wallHits);

        for (int i = 0; i < wallHits.Length; i++)
        {
            float temp;
            Wall hitUnit = wallHits[i].transform.GetComponent<Wall>();
            temp = hitUnit.currentHealth;
            if (damage <= 0)
            {
                damage = 0;
            }
            hitUnit.TakeDamage(damage);
            damage -= temp;
        }
        damage = maxDamage;
    }
    
    private GameObject[] SortByDistance(GameObject[] sortObjects)
    {
        GameObject temp;
        float Lowest;
        float[] DistanceFromPlayer = new float[sortObjects.Length];
        
        for (int i = 0; i < sortObjects.Length; i++)
        {
            DistanceFromPlayer[i] = Vector3.Distance(sortObjects[i].transform.position,transform.position );
        }

        for (int j = 0; j <= sortObjects.Length - 2; j++)
        {
            for (int i = 0; i <= sortObjects.Length - 2; i++)
            {
                if (DistanceFromPlayer[i] > DistanceFromPlayer[i + 1])
                {
                    Lowest = DistanceFromPlayer[i + 1];
                    DistanceFromPlayer[i + 1] = DistanceFromPlayer[i];
                    DistanceFromPlayer[i] = Lowest;
                    temp = sortObjects[i + 1];
                    sortObjects[i + 1] = sortObjects[i];
                    sortObjects[i] = temp;
                }
            }
        }

        return sortObjects;
    }
}

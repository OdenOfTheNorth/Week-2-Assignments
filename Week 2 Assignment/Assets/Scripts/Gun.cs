using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float BulletSpeed = 1000f;
    public LayerMask hitLayers;
    public Camera fpsCam;

    public Transform BarrelEnd;
  
    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit[] hits;
        hits = (Physics.RaycastAll(BarrelEnd.transform.position, BarrelEnd.transform.forward, Mathf.Infinity));

        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            Debug.Log(hit.transform.name);
            
            UnitHealth hitUnit = hit.transform.GetComponent<UnitHealth>();
            if (hitUnit)
            {
                hitUnit.TakeDamage(damage);
            }
        }
    }
}

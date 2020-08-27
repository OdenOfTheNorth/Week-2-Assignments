using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

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
        GameObject[] objects = new GameObject[hits.Length];
        
        if (hits.Length <= 0)
        {
            return;
        }

        for (int i = 0; i < hits.Length; i++)
        {
            objects[i] = hits[i].collider.gameObject;
        }

        objects = SortByDistance(objects);

        for (int i = 0; i < objects.Length; i++)
        {
            float temp;
            UnitHealth hitUnit = objects[i].transform.GetComponent<UnitHealth>();
            temp = hitUnit.currentHealth;
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

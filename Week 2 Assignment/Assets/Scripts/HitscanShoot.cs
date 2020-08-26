using System.Collections;
using UnityEngine;

public class HitscanShoot : MonoBehaviour
{
    
    public Transform origin;
    public LayerMask HitLayers;
    public float damage = 50f;

    private float cooldown = 1.0f; 
    private float currentCoolDown = 0.0f;
    private LineRenderer laser = null;

    private void Awake()
    {
        laser = origin.GetComponent<LineRenderer>();
        laser.enabled = false;
    }

    private void Update()
    {
        currentCoolDown -= Time.deltaTime;
    }

    public void fire()
    {
           
            RaycastHit[] hits;
            hits = Physics.RaycastAll(origin.position, origin.forward, Mathf.Infinity);
            
            if (hits)
            {
                UnitHealth hitUnit = hits.transform.GetComponent<UnitHealth>();
                if (hitUnit)
                {
                    hitUnit.TakeDamage(damage);
                }

                laser.SetPosition(1, hits.point);
            }
            else
            {
                laser.SetPosition(1, origin.position + (origin.right * 20.0f));
            }
    }
}

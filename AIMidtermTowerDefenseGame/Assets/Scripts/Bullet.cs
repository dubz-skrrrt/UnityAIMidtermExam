//using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform target;
    public float AOEradius = 0f;
    public GameObject impactEffect;
    public float speed = 10f;
    public int TurretDamage = 50;

    public void seekTarget(Transform _Target)
    {
        target = _Target;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    void HitTarget()
    {
        GameObject effectInstance = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectInstance, 5f);

        if (AOEradius > 0f)
        {
            ExplosionDamage();
        }
        else
        {
            Damage(target);
        }
        Destroy(gameObject);
        
    }
    void ExplosionDamage()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, AOEradius);
        foreach(Collider collider in cols)
        {
            if (collider.tag == "Enemy")
            {

                Damage(collider.transform);
            }
        }
    }

    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(TurretDamage);
        } 
    }

    

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AOEradius);
    }
}

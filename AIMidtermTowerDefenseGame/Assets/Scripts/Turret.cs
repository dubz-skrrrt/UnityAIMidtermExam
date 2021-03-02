using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;
    private Enemy enemyCompTarget;

    [Header("General")]
    public float rangeOfTurret = 15f;

    [Header("Bullets (Default")]
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    private float fireCountDown = 0f;

    [Header("Laser")]
    public bool useLaser = false;
    public LineRenderer lineRend;

    public ParticleSystem impactEffect;
    public Light impactLight;

    public int DOT = 10;
    public float slowPCT = 0.5f;

    [Header("Unity Setup Fields")]
    public Transform PartToRotate;
    public float turnSpeed = 10f;
    
    public Transform FirePoint;

    
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistanceToEnemy = Mathf.Infinity;
        GameObject nearestEnemyFound = null;

        //iterate each enemy and checks the shortest distance from enemy to the turret
        foreach(GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistanceToEnemy)
            {
                shortestDistanceToEnemy = distanceToEnemy;
                nearestEnemyFound = enemy;
            }
        }
        //Found and enemy within turret range
        if (nearestEnemyFound != null && shortestDistanceToEnemy <= rangeOfTurret)
        {
            target = nearestEnemyFound.transform;
            enemyCompTarget = nearestEnemyFound.GetComponent<Enemy>();
        }else
        {
            target = null;
        }
    }

    void Update()
    {
        if (target == null)
        {
            if (useLaser)
            {
                if (lineRend.enabled)
                {
                    lineRend.enabled = false;
                    impactEffect.Stop();
                    impactLight.enabled = false;
                    
                }
            }
            return;
        }
        
        LockOnTarget();

        if (useLaser)
        {
            Laser();
        }
        else
        {
            if (fireCountDown <=0f)
            {
                Shoot();
                fireCountDown = 1f/fireRate;

            }

            fireCountDown -= Time.deltaTime;
        }

        
    }

    void LockOnTarget()
    {
        
        Vector3 dir = target.position - transform.position;
        Quaternion lookAtEnemy = Quaternion.LookRotation(dir);
        Vector3 rotationOfTurret = Quaternion.Lerp(PartToRotate.rotation, lookAtEnemy, Time.deltaTime * turnSpeed).eulerAngles;
        PartToRotate.rotation = Quaternion.Euler(0f, rotationOfTurret.y, 0f);
    }
    
    void Laser()
    {
        enemyCompTarget.TakeDamage(DOT * Time.deltaTime);
        enemyCompTarget.Slow(slowPCT);
        
        if (!lineRend.enabled)
        {
            lineRend.enabled = true;

            impactEffect.Play();

            impactLight.enabled = true;
        }
        lineRend.SetPosition(0, FirePoint.position);
        lineRend.SetPosition(1, target.position);

        Vector3 dir = FirePoint.position - target.position;

        impactEffect.transform.position = target.position + dir.normalized;

        impactEffect.transform.rotation = Quaternion.LookRotation(dir);
        
    }

    void Shoot()
    {
        GameObject bulletOfTurret = (GameObject)Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
        Bullet bullet = bulletOfTurret.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.seekTarget(target);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangeOfTurret);
    }
}

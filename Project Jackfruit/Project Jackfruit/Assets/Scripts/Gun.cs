using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private Transform target;

    [Header("Turret Attributes")]
    public float range = 15f;
    public float fireRate = 2f;
    private float fireCountdown = 0f;

    [Header("Setup Fields")]
    public string playerTag = "Player";
    public Transform rotate;
    public float speed = 3f;


    [Header("Bullet References")]
    public GameObject bulletPrefab;
    public GameObject shootEffect;
    public Transform firePoint;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag(playerTag);

        float shortDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject player in players)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, player.transform.position);
            if (distanceToEnemy < shortDistance)
            {
                shortDistance = distanceToEnemy;
                nearestEnemy = player;
            }
        }
        if (nearestEnemy != null && shortDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }

    }
    void Update()
    {
        if (target == null)
        {
            return;
        }


        //Allows Turret to rotate smoothly
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(rotate.rotation, lookRotation, Time.deltaTime * speed).eulerAngles;
        rotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        //FireRate stuff
        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;

    }

    void Shoot()
    {
        Instantiate(shootEffect, firePoint.position, firePoint.rotation);
        GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
       
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}

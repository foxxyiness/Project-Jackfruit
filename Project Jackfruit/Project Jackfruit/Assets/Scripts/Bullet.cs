using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 50f;
    public GameObject impactEffect;
    public Vector3 spot;


    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        spot = new Vector3(target.position.x, target.position.y, target.position.z);
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, spot, speed * Time.deltaTime);
        if(transform.position.x == spot.x && transform.position.y == spot.y && transform.position.z == spot.z)
        {
            Destroy(gameObject);
        }


        /*

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }
    void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);
        Destroy(gameObject);
        SceneManager.LoadScene(2);                                                                                                                                      
        //FindObjectOfType<AudioManager>().Play("Hit");
    }

   */
    }

    void OnTriggerEnter(Collider other)
    {
        if( other.CompareTag("Player"))
        {
            Destroy(gameObject);
            Debug.Log("Player hit");
            SceneManager.LoadScene(2);
        }
    }
}

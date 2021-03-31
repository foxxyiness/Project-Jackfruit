using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    public GameMaster gm;
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            gm.lastCheckpoint = transform.position;
        }
    }
}

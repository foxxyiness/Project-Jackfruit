using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicChange : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("yuh");
            FindObjectOfType<AudioManager>().Stop("Dark Shadow");
            FindObjectOfType<AudioManager>().Play("Trouble");
        }
    }
}

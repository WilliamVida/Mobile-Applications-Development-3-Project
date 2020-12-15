using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSound : MonoBehaviour
{

    [SerializeField] public AudioClip shipSound;
    AudioSource audioSource;
    [Range(0f, 1.0f)] private float shipVolume = 0.8f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = shipSound;
        audioSource.volume = shipVolume;
        audioSource.loop = true;
        audioSource.Play();
    }

}

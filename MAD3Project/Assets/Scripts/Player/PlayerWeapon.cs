using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://gamebridgeu.wordpress.com/2017/02/12/instantiate/
public class PlayerWeapon : MonoBehaviour
{

    [SerializeField] public AudioClip laserSound;
    AudioSource audioSource;
    [SerializeField] [Range(0f, 1.0f)] private float shootVolume = 0.5f;
    public GameObject projectile;
    [SerializeField]float shootForce = 10000.0f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject shot = GameObject.Instantiate(projectile, transform.position, transform.rotation);
            shot.GetComponent<Rigidbody>().AddForce(transform.forward * shootForce);
            audioSource.PlayOneShot(laserSound, shootVolume);
            GameObject.Destroy(shot, 2f);
        }
    }

}

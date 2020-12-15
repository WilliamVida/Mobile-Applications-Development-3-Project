using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour
{

    [SerializeField] public AudioClip laserBeamSound;
    AudioSource audioSource;
    [SerializeField] [Range(0f, 1.0f)] private float shootVolume = 0.5f;
    const int overheatMax = 250, overheatMin = 0;
    int overheatValue = 0;
    bool reset = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        transform.GetChild(0).gameObject.SetActive(false);
    }

    void Update()
    {
        // Debug.Log("overheat value " + overheatValue);

        if (Input.GetKey(KeyCode.Mouse0) && reset == true)
        {
            audioSource.PlayOneShot(laserBeamSound, shootVolume);
            transform.GetChild(0).gameObject.SetActive(true);
            overheatValue++;
            if (overheatValue >= overheatMax)
            {
                overheatValue = overheatMax;
                reset = false;
            }
        }
        else
        {
            audioSource.Stop();
            transform.GetChild(0).gameObject.SetActive(false);
            overheatValue--;
            if (overheatValue <= overheatMin)
            {
                overheatValue = overheatMin;
                reset = true;
            }
        }
    }

}

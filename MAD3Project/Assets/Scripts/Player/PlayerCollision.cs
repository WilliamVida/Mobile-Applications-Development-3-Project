using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Destroy(GameObject.FindWithTag("Player"));
        Invoke("ReloadScene", 2.0f);
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] GameObject explosionFX;
    [SerializeField] GameObject enemyHit;
    [SerializeField] Transform parentItem;
    [SerializeField] float health = 100.0f;
    [SerializeField] int scorePoints;

    void Start()
    {
        BoxCollider bc = gameObject.AddComponent<BoxCollider>();
        bc.isTrigger = false;
    }

    void Update()
    {
        if (health <= 0)
        {
            GameObject fx = Instantiate(explosionFX, transform.position, Quaternion.identity);
            fx.transform.parent = parentItem;
            ScoreScript.scoreValue += 100;
            Destroy(gameObject);
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        GameObject fx = Instantiate(enemyHit, transform.position, Quaternion.identity);
        fx.transform.parent = parentItem;
        health -= 100;
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Laser Bullet"))
        {
            GameObject fx = Instantiate(enemyHit, transform.position, Quaternion.identity);
            fx.transform.parent = parentItem;
            Destroy(col.gameObject);
            health -= 50;
        }
    }

}

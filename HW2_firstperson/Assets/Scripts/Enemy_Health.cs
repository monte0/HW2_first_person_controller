using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    public int startingHealth;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public int scoreValue;

    ParticleSystem hitParticles;
    CapsuleCollider capsulecollider;
    bool isDead;
    bool isSinking;



    // Start is called before the first frame update
    void Start()
    {
        hitParticles = GetComponent<ParticleSystem>();
        capsulecollider = GetComponent<CapsuleCollider>();
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(isSinking)
        {
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }
    void TakeDamage(int amount, Vector3 hitPoint)
    {
        if(isDead)
        {
            return;
        }
        currentHealth -= amount;
        hitParticles.transform.position = hitPoint;
        if(currentHealth <= 0)
        {
      //      Death();
        }
    }
}

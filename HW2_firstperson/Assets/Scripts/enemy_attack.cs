using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_attack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage;

    GameObject player;
    Player_Health playerHealth;
    //Enemy_Health enemyHealth;
    bool playerInRange;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<Player_Health>();
        //enemyHealth GetComponent<Enemy_Health>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            playerInRange = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeBetweenAttacks && playerInRange/*&& enemyHealth.currentHealth > 0 */)
        {
            Attack();
        }
        if(playerHealth.currentHealth <= 0)
        {
            //isDead anim
        }
    }
    void Attack()
    {
        timer = 0f;
        if(playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage(attackDamage);
        }
    }
}

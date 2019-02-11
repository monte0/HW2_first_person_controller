using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player_Health : MonoBehaviour
{
    public int startingHealth;
    public int currentHealth;
    public Slider HealthSlider;
    public Image damageImage;
    public float flashSpeed = 5f;
    public Color flashcolor = new Color(1f, 0f, 0f, 0.1f);

    contr playerMovement;
    bool isDead;
    bool damaged;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement.GetComponent<contr>();
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(damaged)
        {
            damageImage.color = flashcolor;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
    }
    public void TakeDamage(int amount)
    {
        damaged = true;
        currentHealth -= amount;
        HealthSlider.value = currentHealth;
        if(currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }
    void Death()
    {
        isDead = true;
        playerMovement.enabled = false;
    }
}

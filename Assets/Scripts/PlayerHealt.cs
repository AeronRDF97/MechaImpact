using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealt : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    private float currentHealth;
    public HealthBar healthBar;
    public GameObject Mecha;

    private void Start()
    {
        currentHealth = maxHealth;

        healthBar.SetSliderMax(maxHealth);
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        healthBar.SetSlider(currentHealth);
    }

    public void HealDamage(float amount)
    {
        currentHealth += amount;
        healthBar.SetSlider(currentHealth);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(2f);
        }

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        if (currentHealth <= 0)
        {
            Mecha.SetActive(false); 
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            TakeDamage(2f);
        }

        if (collision.gameObject.name == "EnemyBullet(Clone)")
        {
            TakeDamage(2f);
        }
    }
}

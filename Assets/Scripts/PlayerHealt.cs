using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealt : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    private float currentHealth;
    public HealthBar healthBar;
    public GameObject Mecha;

    public GameObject re_startButton;
    public GameObject EndgameMenu;

    private void Start()
    {
        currentHealth = maxHealth;

        healthBar.SetSliderMax(maxHealth);

        re_startButton.SetActive(false);
        EndgameMenu.SetActive(false);
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
            re_startButton.SetActive(true);
            EndgameMenu.SetActive(true);
            Time.timeScale = 0;
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

    public void OnceAgain()
    {
        SceneManager.LoadScene("Escenario");
        Time.timeScale = 1f;
    }
}

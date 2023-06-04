using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController Instance;

    public int maxHealth; 
    public int currentHealth;

    public float invincibleLength = 1f;
    private float invincCounter;


    private void Awake() 
    {
        Instance = this;   
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth; 
        UIController.Instance.healthSlider.maxValue = maxHealth;
        UIController.Instance.healthSlider.value = currentHealth;  
        UIController.Instance.healthText.text = "Здоров'я: " + currentHealth + "/" + maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (invincCounter > 0)
        {
            invincCounter -= Time.deltaTime;
        }
    }


    public void DamagePlayer(int damageAmount)
    {
        if (invincCounter <= 0 && !GameManager.Instance.levelEnding)
        {
            AudioManager.Instance.PlaySFX(7);

            currentHealth -= damageAmount;

            UIController.Instance.ShowDamage();

            if (currentHealth <= 0)
            {
                gameObject.SetActive(false);

                currentHealth = 0;

                GameManager.Instance.PlayerDied();

                AudioManager.Instance.StopBGM();
                AudioManager.Instance.PlaySFX(6);
                AudioManager.Instance.StopSFX(7);
            }

            invincCounter = invincibleLength;


            UIController.Instance.healthSlider.value = currentHealth;  
            UIController.Instance.healthText.text = "Здоров'я: " + currentHealth + "/" + maxHealth;
        }
    }

    public void HealPlayer(int healAmount)
    {
        currentHealth += healAmount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        UIController.Instance.healthSlider.value = currentHealth;  
        UIController.Instance.healthText.text = "Здоров'я: " + currentHealth + "/" + maxHealth;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealthScript : MonoBehaviour
{
    //Code based off of https://stackoverflow.com/questions/59491053/enemy-health-bar-and-taking-damage
    //and https://medium.com/nerd-for-tech/generic-universal-scripts-health-and-damage-a57db50fc920

    public float currentHealth;
    public float maxHealth; 

    //Health gauge UI
    public GameObject hBar;
    public Slider hSlider;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        hSlider.value = HealthCalculations() * 100f;
    }

    // Update is called once per frame
    void Update()
    {
        hSlider.value = HealthCalculations() * 100f;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        if (currentHealth < maxHealth)
        {
            hBar.SetActive(true);
        }

        if (currentHealth < 0)
        {
            Debug.Log("Dead");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
    }

    private void FixedUpdate()
    {
        currentHealth= currentHealth + 0.2f;
    }

    float HealthCalculations()
    {
        return currentHealth / maxHealth;
    }

    public void ReceiveDamage(float DamageDealt)
    {
        currentHealth -= DamageDealt;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBulletDestroyScript : MonoBehaviour
{
    PlayerHealthScript healthVariables;
    public GameObject hittingWhat;
    public float TurretBulletDamage = 15f;

    // Start is called before the first frame update
    void Start()
    {
        healthVariables = GameObject.Find("Player").GetComponent<PlayerHealthScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void damagePlayer()
    {
        healthVariables.currentHealth = healthVariables.currentHealth - 15;
    }

    //When the bullet comes into contact with any object,
    //Or after hitting player, destroy bullet
    void OnCollisionEnter(Collision hittingWhat)
    {
        if (hittingWhat.gameObject.tag == "Player")
        {
            damagePlayer();
        }
        Destroy(gameObject);
    }

}

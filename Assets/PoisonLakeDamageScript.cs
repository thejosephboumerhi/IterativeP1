using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonLakeDamageScript : MonoBehaviour
{
    PlayerHealthScript healthVariables;

    //Help with code from Owen giving it in our Discord hat
    public float poisonHeightCheck = 109;
    public float poisonTicking = 1f;
    bool InPoison = false;

    // Start is called before the first frame update
    void Start()
    {
        healthVariables = GameObject.Find("PlayerCapsule/Capsule").GetComponent<PlayerHealthScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (this.transform.position.y <= poisonHeightCheck)
        {
            damagePlayer();
        }
    }

    void damagePlayer()
    {
        healthVariables.currentHealth = healthVariables.currentHealth - poisonTicking;
    }

    
}

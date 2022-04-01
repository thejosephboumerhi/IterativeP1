using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonLakeDamageScript : MonoBehaviour
{
    PlayerHealthScript healthVariables;

    //Help with code from Owen giving it in our Discord hat

    public float poisonTicking = 1;
    bool InPoison = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void damagePlayer()
    {
        healthVariables.currentHealth--;

        if (InPoison)
        {
            Invoke("damagePlayer", poisonTicking);
        }
    }

    void OnCollisionEnter(Collision PoisonBox)
    {
        if (PoisonBox.gameObject.tag == "Poison")
        {
            InPoison = true;
            damagePlayer();
        }
    }

    void OnCollisionExit(Collision PoisonBox)
    {
        if (PoisonBox.gameObject.tag == "Poison")
        {
            InPoison = false;
        }
    }
}

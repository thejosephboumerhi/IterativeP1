using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectorScript : MonoBehaviour
{
    //This is for how the "turret" enemy shoots you
    bool playerDetected;
    GameObject playerTargeted;
    public Transform playerLookedAt;

    //This is for the "turret" shooting you
    public float enemyTurretBulletVelocity = 10f;
    public float enemyTurretFiringSpeed = 1.5f;
    float TimeFromAfterShooting;
    
    //Objects for turrets
    public GameObject TurretProjectile;
    public Transform ShootingPointFrom;


    // Start is called before the first frame update
    void Start()
    {
        TimeFromAfterShooting = enemyTurretFiringSpeed;
    }

    // Update is called once per frame
    //Looks for the player in its box collider
    void Update()
    {
        if (playerDetected)
        {
            playerLookedAt.LookAt(playerTargeted.transform);
        }
    }

    private void FixedUpdate()
    {
        if (playerDetected)
        {
            enemyTurretFiringSpeed -= Time.deltaTime;

            if (enemyTurretFiringSpeed < 0)
            {
                FireAtPlayer();
                enemyTurretFiringSpeed = TimeFromAfterShooting;
            }
        }
    }

    //Since it's looking for the "Player" tag, the targeting will become true and will target
    //the gameObject, which in this case is the player 
    private void OnTriggerEnter(Collider attackWho)
    {
        if (attackWho.tag == "Player")
        {
            playerDetected = true;
            playerTargeted = attackWho.gameObject;
        }
    }

    private void FireAtPlayer()
    {
        GameObject bulletFired = Instantiate(TurretProjectile,ShootingPointFrom.position,ShootingPointFrom.rotation);
        Rigidbody bullet = bulletFired.GetComponent<Rigidbody>();

        bullet.AddForce(transform.forward*enemyTurretFiringSpeed,ForceMode.VelocityChange);
    }

}

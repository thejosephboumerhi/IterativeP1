using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterScript : MonoBehaviour
{
    public Transform teleportSpot;
    public GameObject player;

    void OnTriggerEnter(Collider other)
    {
        player.transform.position = teleportSpot.transform.position;
        player.GetComponent<PoisonLakeDamageScript>().poisonHeightCheck = 17;
        Destroy(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

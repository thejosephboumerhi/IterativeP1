using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePadScript : MonoBehaviour
{
    //Code in IterativeWiki
    //
    public float jumpPadLaunchSpeed;
    GameObject playerLaunching;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision playerStepOn)
    {
        if (playerStepOn.gameObject.tag == "Player")
        {
            playerLaunching = playerStepOn.gameObject;
            JumpUP();
        }
    }

    private void JumpUP()
    {
        Rigidbody playerRig = playerLaunching.GetComponent<Rigidbody>();
        playerRig.AddForce(playerLaunching.transform.up*jumpPadLaunchSpeed,ForceMode.Impulse);
    }
}

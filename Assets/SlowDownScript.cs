using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlowDownScript : MonoBehaviour
{
    //Values for gauge as an ability
    //New
    public int currentSlowPower;
    public int maxSlowPower;

    //From Prototype 3
    //How slow the slow motion is
    public float slowMotionTimeScale;

    //Floats for the normal and slowed time, and now cooldowns
    private float startTimeScale;
    private float startFixedDeltaTime;
    //New
    public float slowCooldown = 4f;
    public float readyForUse = 0f;

    //Slow down gauge UI
    public GameObject slBar;
    public Slider slSlider;

    // Start is called before the first frame update
    void Start()
    {
        currentSlowPower = maxSlowPower;
        slSlider.value = SlowPowerCalculations();

        startTimeScale = Time.timeScale;
        startFixedDeltaTime = Time.fixedDeltaTime;
    }

    // Update is called once per frame
    //Command for slow down
    void Update()
    {
        slSlider.value = SlowPowerCalculations();
        
        if (Time.time > readyForUse)
        {
            //Starts the slow down
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartSlowMotion();
                readyForUse = Time.time + slowCooldown;
            }
        }

        //Stops the slow down
        if (currentSlowPower <= 0)
        {
            StopSlowMotion();
        }

        if (currentSlowPower > maxSlowPower)
        {
            currentSlowPower = maxSlowPower;
        }

        if (currentSlowPower < maxSlowPower)
        {
            slBar.SetActive(true);
        }
    }

    int SlowPowerCalculations()
    {
        return currentSlowPower / maxSlowPower;
    }

    //Time gets effected by the public float
    private void StartSlowMotion()
    {
        Time.timeScale = slowMotionTimeScale;
        Time.fixedDeltaTime = startFixedDeltaTime * slowMotionTimeScale;
    }

    //Returns time back to normal
    private void StopSlowMotion()
    {
        Time.timeScale = startTimeScale;
        Time.fixedDeltaTime = startFixedDeltaTime;
    }
}

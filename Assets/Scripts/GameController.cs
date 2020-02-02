using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //flags
    public bool interactionEnabled; //wrench
    public bool timeMoving; //clock
    public bool sfxEnabled; //jukebox
    public bool leverActivated;
    public bool portalEntered; //portal
    public bool chocolateFound; //chocolate
    public bool mapFragment1Collected;
    public bool mapFragment2Collected;
    public bool mapFragment3Collected;
    public bool mapFragment4Collected;
    public bool allDiscovered;


    public Timer timer;
    public Vector3 playerRezPos;
    public Animator platformAnim;
    public AudioSource sceneBGM;
    public GameObject player;
    public GameObject endCanvas;
    public GameObject achievementPanel;
    public Text achievementText;
    public mapManager manager;

    void Start()
    {
        interactionEnabled = false;
        timeMoving = false;
        sfxEnabled = false;
        portalEntered = false;
        leverActivated = false;
        platformAnim.enabled = !platformAnim.enabled;
        playerRezPos = new Vector3(-5.5f, -3f, 0f);
        sceneBGM = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");

    }

    private void Update()
    {

        if (leverActivated)
        {
            platformAnim.enabled = true;
        }

        if (portalEntered)
        {
            if(manager.Stage3.activeInHierarchy)
            {
                playerRezPos = new Vector3(-150, -5, 0);
            }
            else
            {
                playerRezPos = new Vector3(-97f, 0.3f, 0f);
            }
        }

        if(mapFragment4Collected)
        {
            player.GetComponent<PlayerMovement>().isPaused = true;
            endCanvas.SetActive(true);
        }

        if (interactionEnabled && timeMoving && chocolateFound && leverActivated && mapFragment4Collected && portalEntered)
        {
            allDiscovered = true;
        }
    }
}

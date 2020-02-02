using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //flags
    public bool interactionEnabled;
    public bool timeMoving;
    public bool sfxEnabled;
    public bool leverActivated;

    public Animator platformAnim;

    void Start()
    {
        interactionEnabled = false;
        timeMoving = false;
        sfxEnabled = false;
        leverActivated = false;
        platformAnim.enabled = !platformAnim.enabled;
    }

    private void Update()
    {
        if (leverActivated)
        {
            platformAnim.enabled = true;
        }
    }
}

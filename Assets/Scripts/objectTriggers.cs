using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectTriggers : MonoBehaviour
{

    private GameObject player;
    public GameController gc;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (this.gameObject.name == "clock" && col.gameObject == player)
        {
            if (gc.timeMoving == false)
            {
                Debug.Log("Time is not moving, find wrench to continue");
            }
        }
        if (this.gameObject.name == "Wrench" && col.gameObject == player)
        {
            gc.interactionEnabled = true;
        }
    }
}

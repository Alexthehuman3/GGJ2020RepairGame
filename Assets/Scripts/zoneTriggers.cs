using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoneTriggers : MonoBehaviour
{
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject == player.gameObject)
        {
            //Debug.Log("collided");
            if (this.gameObject.name == "0-1x")
            {
                //Debug.Log("teleported");
                player.position = new Vector3(51, -3, 0);
            }
            if(this.gameObject.name == "1-0x")
            {
                //Debug.Log("teleported");
                player.position = new Vector3(14, -3, 0);
            }
        }
    }
}

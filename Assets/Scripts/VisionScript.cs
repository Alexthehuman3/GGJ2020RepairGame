﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionScript : MonoBehaviour
{
    //------------------------------------------------------------------------
    //Andrei Variables
    public GameObject player;


    //----------------------------------------------------------------
    void Start(){ }
      //Andrei Script
        void LateUpdate()
        {
            Vector3 offset = transform.position - player.transform.position;
            bool changeInX = false;
            bool changeInY = false;

            Vector3 newCameraPosition = transform.position;
            if (offset.x > 3)
            {
                changeInX = true;
                newCameraPosition.x = (player.transform.position.x + offset.x) - (offset.x - 3);
            }
            else if (offset.x < -3)
            {
                changeInX = true;
                newCameraPosition.x = (player.transform.position.x + offset.x) - (offset.x + 3);
            }
            if (offset.y > 2)
            {
                changeInY = true;
                newCameraPosition.y = (player.transform.position.y + offset.y) - (offset.y - 2);
            }
            else if (offset.y < -2)
            {
                changeInY = true;
                newCameraPosition.y = (player.transform.position.y + offset.y) - (offset.y + 2);
            }
            if (!changeInX)
            {
                newCameraPosition.x = transform.position.x;
            }
            if (!changeInY)
            {
                newCameraPosition.y = transform.position.y;
            }
            transform.position = newCameraPosition;
        }
    
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //flags
    public bool interactionEnabled;
    public bool timeMoving;
    // Start is called before the first frame update
    void Start()
    {
        interactionEnabled = false;
        timeMoving = false;
    }
}

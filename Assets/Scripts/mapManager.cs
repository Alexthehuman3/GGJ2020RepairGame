using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapManager : MonoBehaviour
{
    public GameObject Stage2;
    public GameObject Stage3;
    public GameObject Stage4;

    private GameController gc;
    // Start is called before the first frame update
    void Start()
    {
        Stage2 = transform.Find("Level2Stage2").gameObject;
        Stage3 = transform.Find("Level2Stage3").gameObject;
        Stage4 = transform.Find("Level2Stage4").gameObject;

        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        Stage2.SetActive(false);
        Stage3.SetActive(false);
        Stage4.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(gc.mapFragment1Collected)
        {
            Stage2.SetActive(true);
        }
        if(gc.mapFragment2Collected)
        {
            Stage3.SetActive(true);
        }
        if (gc.mapFragment3Collected)
        {
            Stage4.SetActive(true);
        }
    }
}

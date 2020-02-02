using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class objectTriggers : MonoBehaviour
{
    private GameObject player;
    public GameController gc;
    public GameObject textPanel;
    public GameObject greyPanel;
    public Text text;
    public Text textContinue;
    public GameObject canvas;
    public bool inDialogue;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        textPanel = canvas.transform.Find("textPanel").gameObject;
        greyPanel = canvas.transform.Find("Greyscale").gameObject;
        text = textPanel.transform.Find("globalText").GetComponent<Text>();
        textContinue = textPanel.transform.Find("continue").GetComponent<Text>();

        textPanel.SetActive(false);
        textContinue.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(inDialogue && (this.name == "Wrench" || this.name =="clock" || this.name == "lever" || this.name == "wrenchSIGN"))
        {
            eContinue();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject == player)
        {
            if (this.gameObject.name == "clock")
            {
                if (!gc.timeMoving && !gc.interactionEnabled)
                {
                    text.text = "The clock seems to be broken, but you can't interact with it yet...";
                    textPanel.SetActive(true);
                    StartCoroutine(countDown(5));
                }
                if (!gc.timeMoving && gc.interactionEnabled)
                {
                    text.text = "You fixed the clock and suddenly the world is blessed with color and life as it ticks away.";
                    textPanel.SetActive(true);
                    pausePlayer(true);
                    greyPanel.GetComponent<Animator>().SetBool("timeUnlocked", true);
                    inDialogue = true;
                    gc.timeMoving = true;
                }
            }
            if (this.gameObject.name == "Wrench")
            {
                inDialogue = true;
                pausePlayer(true);
                textPanel.SetActive(true);
                text.text = "You can now repair and interact with objects! Press E to interact to the sign next to you!";
                textContinue.gameObject.SetActive(true);
                gc.interactionEnabled = true;
            }

            if (this.gameObject.name == "GGJJukeBox")
            {
                text.text = "You've obtained the Jukebox! You now have Sound Effect!";
                textPanel.SetActive(true);
                inDialogue = true;
                pausePlayer(true);
                gc.sfxEnabled = true;
            }

            if (this.gameObject.name == "lever")
            {
                if(!gc.timeMoving && !gc.interactionEnabled)
                {
                    text.text = "The lever won't budge... Maybe something could fix it?";
                    textPanel.SetActive(true);
                    StartCoroutine(countDown(5));
                }
                if(!gc.timeMoving && gc.interactionEnabled)
                {
                    text.text = "The lever doesn't seems to do anything when pulled...";
                    textPanel.SetActive(true);
                    inDialogue = true;
                    pausePlayer(true);
                }
                if(gc.timeMoving && gc.interactionEnabled && !gc.leverActivated)
                {
                    text.text = "Something has descended from the heavens as the lever's switched.";
                    textPanel.SetActive(true);
                    inDialogue = true;
                    pausePlayer(true);
                    this.GetComponent<Animator>().SetBool("timeMoving", true);
                    gc.leverActivated = true;
                }
            }

            if (this.gameObject.name == "Chocolate")
            {
                if(!gc.timeMoving || (!gc.timeMoving && !gc.interactionEnabled))
                {
                    text.text = "Developer's favourite snack is frozen in time!";
                    textPanel.SetActive(true);
                    StartCoroutine(countDown(5));
                }
                if(gc.timeMoving)
                {
                    text.text = "You've found the Programmer's favourite snack!";
                    textContinue.text = "The other developer disagrees!";
                    textPanel.SetActive(true);

                }
            }

            if (this.gameObject.name == "wrenchSIGN")
            {
                if(gc.interactionEnabled)
                {
                    pausePlayer(true);
                    text.text = "A Gift from the Gods ->";
                    textPanel.SetActive(true);
                    inDialogue = true;
                    
                }
            }
        }
        
    }

    private void pausePlayer(bool truefalse)
    {
        player.GetComponent<PlayerMovement>().isPaused = truefalse;
    }

    private void eContinue()
    {
        if (Input.GetKey(KeyCode.E) && inDialogue == true)
        {
            textPanel.SetActive(false);
            pausePlayer(false);
            textContinue.text = "Press E to Continue...";
            if(this.gameObject.name == "Wrench" || this.gameObject.name == "clock")
            {
                Debug.Log("Object Destroyed");
                Destroy(this.gameObject);

            }
        }
    }

    IEnumerator countDown(int sec)
    {
        yield return new WaitForSeconds(sec);
        textPanel.SetActive(false);
        player.GetComponent<PlayerMovement>().isPaused = false;
    }
}

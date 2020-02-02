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
        if(inDialogue && (this.name == "Wrench" || this.name =="clock" || this.name == "lever" || this.name == "wrenchSIGN" || this.name == "TrollSign" || this.name == "mapFragment1"||
            this.name == "mapFragment2" || this.name == "mapFragment3" || this.name == "mapFragment4" || this.name == "GGJJukeBox"))
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
                    text.text = "The clock seems to be broken, maybe there is a way to fix it...?";
                    textPanel.SetActive(true);
                    Debug.Log("Coroutine started");
                    StartCoroutine(countDown(5));
                }
                if (!gc.timeMoving && gc.interactionEnabled)
                {
                    text.text = "You fixed the clock and suddenly the world is blessed with color and life as it ticks away.";
                    gc.achievementText.text = "Clock?... of the Flowing Time";
                    gc.achievementPanel.GetComponent<Animator>().Play("AchievementAnim");
                    textPanel.SetActive(true);
                    pausePlayer(true);
                    greyPanel.GetComponent<Animator>().SetBool("timeUnlocked", true);
                    gc.timeMoving = true;
                    inDialogue = true;
                }
            }
            if (this.gameObject.name == "Wrench")
            {
                gc.achievementText.text = "Re:build?";
                gc.achievementPanel.GetComponent<Animator>().Play("AchievementAnim");
                pausePlayer(true);
                textPanel.SetActive(true);
                text.text = "You can now repair and interact with objects! Press E to interact to the sign next to you!";
                textContinue.gameObject.SetActive(true);
                gc.interactionEnabled = true;
                inDialogue = true;
            }

            if (this.gameObject.name == "GGJJukeBox")
            {
                text.text = "You've obtained the Jukebox! You now have Sound Effects!";
                gc.achievementText.text = "C418 - Mutation";
                gc.achievementPanel.GetComponent<Animator>().Play("AchievementAnim");
                textPanel.SetActive(true);
                inDialogue = true;
                pausePlayer(true);
                gc.sfxEnabled = true;
                gc.sceneBGM.Play();
                inDialogue = true;
            }

            if (this.gameObject.name == "lever")
            {
                if(!gc.timeMoving && !gc.interactionEnabled)
                {
                    text.text = "The lever won't budge... Maybe something could fix it?";
                    textPanel.SetActive(true);
                    Debug.Log("Coroutine started");
                    StartCoroutine(countDown(5));
                }
                if(!gc.timeMoving && gc.interactionEnabled)
                {
                    text.text = "The lever doesn't seem to do anything when pulled...";
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
                    inDialogue = true;
                    gc.chocolateFound = true;
                    gc.achievementText.text = "Oooh a secret!";
                    gc.achievementPanel.GetComponent<Animator>().Play("AchievementAnim");
                    pausePlayer(true);
                    textPanel.SetActive(true);
                    text.text = "You've found the Programmer's favourite snack!";
                    textContinue.text = "No you can't eat it!";
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

            if (this.gameObject.name == "TrollSign")
            {
                if(gc.interactionEnabled)
                {
                    pausePlayer(true);
                    text.text = "Well done, you've discovered nothing!";
                    textPanel.SetActive(true);
                    inDialogue = true;
                }
            }

            if(this.gameObject.name == "PortalToL2")
            {
                if(gc.timeMoving)
                {
                    gc.achievementText.text = "I think I see hell";
                    gc.achievementPanel.GetComponent<Animator>().Play("AchievementAnim");
                    gc.portalEntered = true;
                }
            }


            if(this.gameObject.name == "mapFragment1")
            {
                if(gc.timeMoving && gc.interactionEnabled)
                {
                    pausePlayer(true);
                    text.text = "It seems, that what you found looks like a map fragment, you can't makeout what it says yet.";
                    textPanel.SetActive(true);
                    inDialogue = true;
                    gc.mapFragment1Collected = true;
                    gc.achievementText.text = "There's more?!";
                    gc.achievementPanel.GetComponent<Animator>().Play("AchievementAnim");
                    
                }
            }
            if(this.gameObject.name == "mapFragment2" && gc.interactionEnabled)
            {
                if(gc.timeMoving)
                {
                    pausePlayer(true);
                    text.text = "Another fragment, slowly you place the pieces together, and are able to see some sort of direction.";
                    textPanel.SetActive(true);
                    inDialogue = true;
                    gc.mapFragment2Collected = true;
                }
            }
            if(this.gameObject.name == "mapFragment3")
            {
                if(gc.timeMoving&& gc.interactionEnabled)
                {
                    
                    pausePlayer(true);
                    text.text = "The third fragment, with the 3 pieces together, you are able to identify where the last piece is.";
                    textPanel.SetActive(true);
                    inDialogue = true;
                    gc.mapFragment3Collected = true;
                }
            }
            if(this.gameObject.name == "mapFragment4")
            {
                if(gc.timeMoving && gc.interactionEnabled)
                {
                    gc.mapFragment4Collected = true;
                    gc.achievementText.text = "The End...?";
                    gc.achievementPanel.GetComponent<Animator>().Play("AchievementAnim");
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
        if (Input.GetKeyDown(KeyCode.E) && inDialogue == true)
        {
            textPanel.SetActive(false);
            pausePlayer(false);
            textContinue.text = "Press E to Continue...";
            if(this.gameObject.name == "Wrench" || this.gameObject.name == "clock" || this.gameObject.name == "Chocolate" || this.name == "GGJJukeBox" || 
                this.name == "mapFragment1" || this.name == "mapFragment2" || this.name == "mapFragment3" || this.name == "mapFragment4")
            {
                Debug.Log("Object Destroyed");
                Destroy(this.gameObject);
                inDialogue = false;
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

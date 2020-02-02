using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float moveSpeed = 5;
    public float jumpHeight = 5f;
    public bool isGrounded = false;
    public bool isDead = false;
    private AudioSource audio;
    public AudioClip jumpSound;
    public AudioClip walkSound;
    private GameObject Player;
    private Animator anim;
    public GameController gc;
    public bool isPaused;

    // Start is called before the first frame update
   private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        controller = this.GetComponent<CharacterController>();
        audio = gameObject.GetComponent<AudioSource>();
        anim = gameObject.GetComponent<Animator>();
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }
    void Update()
    {
        if(!isPaused)
        {
            Jump();
            if ((!isGrounded && (Input.GetAxis("Horizontal") >= 0.1 || Input.GetAxis("Horizontal") <= -0.1)) || Input.GetAxis("Horizontal") == 0)
            {
                anim.SetBool("isMoving", false);
            }

            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
            if (Input.GetAxis("Horizontal") >= 0.1)
            {
                Player.transform.localScale = new Vector3(1, 1, 1);
                anim.SetBool("isMoving", true);
            }
            if (Input.GetAxis("Horizontal") <= -0.1)
            {
                Player.transform.localScale = new Vector3(-1, 1, 1);
                anim.SetBool("isMoving", true);
            }
            transform.position += movement * Time.deltaTime * moveSpeed;
            if (isGrounded == true && (Input.GetAxis("Horizontal") >= 0.1 || Input.GetAxis("Horizontal") <= -0.1) && audio.isPlaying == false && gc.sfxEnabled)
            {
                audio.PlayOneShot(walkSound, 0.5f);
            }
        }
    }
    // Update is called once per frame
    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpHeight), ForceMode2D.Impulse);
            if (gc.sfxEnabled)
            {
                audio.PlayOneShot(jumpSound, 0.5f);
            }
            anim.SetBool("isJumping", true);
        }
        else
        {
            anim.SetBool("isJumping", false);
        }



        Vector3 movement = new Vector3(Input.GetAxis("Vertical"), 0f, 0f);
        if(Input.GetAxis("Vertical") >= 0.1)
        {
            Player.transform.localScale = new Vector3(1, 1, 1);
        }
        if(Input.GetAxis("Vertical") <= -0.1)
        {
            Player.transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    
} 

    

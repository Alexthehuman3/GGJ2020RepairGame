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

    // Start is called before the first frame update
   private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        controller = this.GetComponent<CharacterController>();
        audio = gameObject.GetComponent<AudioSource>();
    }
    void Update()
    {
        Jump();
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;
        if(isGrounded == true && (Input.GetAxis("Horizontal") >= 0.1 || Input.GetAxis("Horizontal") <= -0.1) && audio.isPlaying == false)
        {
            audio.PlayOneShot(walkSound, 0.5f);
        }
    }
    // Update is called once per frame
    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpHeight), ForceMode2D.Impulse);
            audio.PlayOneShot(jumpSound, 0.5f);
        }

    }
    
} 

    

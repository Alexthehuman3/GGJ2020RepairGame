using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour
{
    public AudioClip deathSound;
    private GameObject Player;
    private Vector3 playerStartingPosition;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerStartingPosition = Player.transform.position;
        Debug.Log(playerStartingPosition);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Player.gameObject)
        {
            Debug.Log(playerStartingPosition);
            Player.GetComponent<PlayerMovement>().isDead = true;
            Debug.Log(Player.GetComponent<PlayerMovement>().isDead);
            Player.GetComponent<AudioSource>().PlayOneShot(deathSound, 0.5f);
            Player.transform.position = playerStartingPosition;
        }
    }
}

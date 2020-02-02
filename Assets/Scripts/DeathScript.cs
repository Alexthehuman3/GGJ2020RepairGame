using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour
{
    public AudioClip deathSound;
    private GameObject Player;
    private Vector3 playerStartingPosition;
    private GameController gc;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerStartingPosition = Player.transform.position;
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Player.gameObject)
        {
            Player.GetComponent<PlayerMovement>().isDead = true;
            if (gc.sfxEnabled)
            {
                Player.GetComponent<AudioSource>().PlayOneShot(deathSound, 0.5f);
            }
            Player.transform.position = playerStartingPosition;
        }
    }
}

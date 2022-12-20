using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public float jumpSpeed = 2f;
    public GameManager gameManager;
    public bool isDead = false;
    private Rigidbody2D myRigidbody;
    public AudioClip BackgroundAudio;
    private AudioSource myAudio;
    

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAudio =  GetComponent <AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Jump on space button
        if(Input.GetKeyDown(KeyCode.Space)) {
            Vector2 newSpeed = myRigidbody.velocity;
            newSpeed.y = jumpSpeed;
            myRigidbody.velocity = newSpeed; 
        }

       
    }

  

private void OnCollisionEnter2D(Collision2D collision)
{
    isDead = true;
    gameManager.GameOver();
    myAudio.Stop();
}

private void OnTriggerEnter2D(Collider2D collision)
{
    if(collision.gameObject.tag == "Scoring"){
        gameManager.IncreaseScore();
    }
}
         
        
}

   


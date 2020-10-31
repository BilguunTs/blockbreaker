using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle1;
    [SerializeField] AudioClip[] ballAudios;
    bool hasStarted = false;
    Vector2 paddleToBallVector;
    AudioSource ballAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        ballAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
        this.LockTheBallTothePaddle();
            this.LaunchTheBall();
        }
        
          
        
    }
    private void LockTheBallTothePaddle()
    {

        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;

        GetComponent<Rigidbody2D>().simulated = false;
        
    }
    private void LaunchTheBall()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            Rigidbody2D ballRB = GetComponent<Rigidbody2D>();
            ballRB.velocity = new Vector2(2f, 12f);
            ballRB.simulated = true;
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted)
        {
            AudioClip ballAudio = ballAudios[UnityEngine.Random.Range(0, ballAudios.Length)];
            ballAudioSource.PlayOneShot(ballAudio);

        }
    }
}

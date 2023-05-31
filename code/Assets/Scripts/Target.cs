using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameManager gameManager;
    public ParticleSystem explosionParticle;
    private float minSpeed = 12;
    private float maxSpeed = 15;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -2;

    public int pointValue;
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position = RandomSpawnPos();
    }

    
    void Update()
    {
        
    }



    private void OnTriggerEnter(Collider other) 
    {
        
        Destroy(gameObject);

        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.UpdateLives(-1);
            if(gameManager.lives < 0)
            {
                gameManager.lives = 0;
                gameManager.UpdateLives(0);
            }
        }
    }

    public void DestroyTarget()
    {
        if(gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.UpdateScore(pointValue);
        }
        
        if(CompareTag("Bad"))
        {
            gameManager.UpdateLives(-1);
            if(gameManager.lives < 0)
            {
                gameManager.lives = 0;
                gameManager.UpdateLives(0);
            }

        }
        
    }
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }
    
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
}

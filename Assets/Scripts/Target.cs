using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody rb;
    protected GameManager gameManager;
    public ParticleSystem explosionParticle;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -2;

    //ENCAPSULATION, POLYMPORHISM
    protected int m_pointValue;

    
    virtual public int pointValue
    {
        get
        {
            return m_pointValue;
        }
        set
        {
            if(value >= 0)
            {
                m_pointValue = value;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }
    //ABSTRACTION
    protected void Initialize()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody>();
        rb.AddForce(RandomForce(), ForceMode.Impulse);
        rb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomPosition();
    }
    private void OnMouseDown()
    {
        if(gameManager.isGameActive)
        {
            Clicked();
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
    //ABSTRACTION, POLYMPORHISM
    private void Clicked()
    {
        Destroy(gameObject);
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        gameManager.UpdateScore(pointValue);
    }
    
    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    private float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }
    private Vector3 RandomPosition()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
}

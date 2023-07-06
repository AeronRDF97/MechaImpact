using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{


    public Transform PatrolRoute;
    public List<Transform> Locations;
    public Transform Player;
    public GameObject lockedDoor;

    //shoot
    [SerializeField] private float timer = 5;
    private float BulletTime;
    public GameObject enemyBullet;
    public Transform spawnPoint;
    public float EbulletSpeed;
    public bool IsHere;


    //patrol
    private int _locationIndex = 0;
    private NavMeshAgent _agent;

    public int _lives = 5; 
    public int EnemyLives
    {
        // 2
        get { return _lives; } // 3
        private set
        {
            _lives = value; // 4
            if (_lives <= 0)
            {
                Destroy(this.gameObject);
                Debug.Log("Enemy down.");
                lockedDoor.SetActive(false);
            }
        }
    }

    void Start()
    {
        IsHere = false;
        
        _agent = GetComponent<NavMeshAgent>();

        Player = GameObject.Find("Player").transform;

        InitializePatrolRoute();

        MoveToNextPatrolLocation();
    }

    void InitializePatrolRoute()
    {
        foreach (Transform child in PatrolRoute)
        {
            Locations.Add(child);
        }
    }

    //Shoot
    void ShotAtPLayer()
    {
        BulletTime -= Time.deltaTime;

        if (BulletTime > 0) return;

        BulletTime = timer;

        GameObject bulletobj = Instantiate(enemyBullet, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
        Rigidbody bulletrig = bulletobj.GetComponent<Rigidbody>();
        bulletrig.velocity = this.transform.forward * EbulletSpeed;
    }

    void Update()
    {
     if(_agent.remainingDistance<0.2f && !_agent.pathPending)
        {
            MoveToNextPatrolLocation();
        }

        if (IsHere == true)
        {
            ShotAtPLayer();
        }
    }


    void MoveToNextPatrolLocation()
    {
        if (Locations.Count == 0)
            return;
        _agent.destination = Locations[_locationIndex].position;

        _locationIndex = (_locationIndex + 1) % Locations.Count;
    }
    // 1
    void OnTriggerEnter(Collider other)
    {
        //2
        if (other.name == "Player")
        {
            _agent.destination = Player.position;

            IsHere = true;
            
            Debug.Log("Player detected - attack!");

            
        }
    }
    // 3
    void OnTriggerExit(Collider other)
    {
        // 4
        if (other.name == "Player")
        {
            IsHere = false;
            
            Debug.Log("Player out of range, resume patrol");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // 5
        if (collision.gameObject.name == "Rocket_Punch(Clone)")
        {
            // 6
            EnemyLives -= 1;
            Debug.Log("Hit!");
        }

        if (collision.gameObject.name == "Iron_Cutter(Clone)")
        {
            // 6
            EnemyLives -= 3;
            Debug.Log("Critical hit!");
        }

        if (collision.gameObject.name == "AP_Shot(Clone)")
        {
            // 6
            EnemyLives -= 10;
            Debug.Log("Critical hit!");
        }
    }
}


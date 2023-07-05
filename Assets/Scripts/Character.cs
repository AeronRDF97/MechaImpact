using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float speed = 6.0f;
    public float dspeed = 52.0f;
    public float rotateSpeed = 20.0f;
    public float jumpSpeed = 1.0f;
    public float gravity = 20.0f;

    public GameObject Rocket_Punch;
    public GameObject Iron_Cutter;
    public float BulletSpeed = 100f;
    public GameObject Misile;
    public GameObject misileholder;
    private bool _isShooting;
    private bool _isShooting2;
    private bool _isShooting3;
    public bool BMisile;
    public int _misileShots;
    public Transform SpawnShoot_1;
    public Transform SpawnShoot_2;
    public Transform SpawnShoot_3;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    //private int jumps;

    void Start()
    {
        BMisile = false;
        _misileShots = 0;
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        //Movement
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            
            if (Input.GetKeyDown(KeyCode.Q))
            {
                moveDirection *= dspeed;
            }
            if (this.transform.position.y<-0.3)
            {
              moveDirection.y = jumpSpeed;
            }
        }


        transform.Rotate(0, Input.GetAxis("Horizontal")* rotateSpeed, 0);
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        //Shooting
        if (Input.GetMouseButton(1))
        {
            _isShooting |= Input.GetMouseButtonDown(0);
            _isShooting2 |= Input.GetKeyDown(KeyCode.G);
            _isShooting3 |= Input.GetKeyDown(KeyCode.E);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "misil")
        {
            BMisile = true;
            _misileShots = 5;
            misileholder.SetActive(false);
        }
    }
    private void FixedUpdate()
    {
        if (_isShooting)
        {
            GameObject newBullet = Instantiate(Rocket_Punch, SpawnShoot_1.transform.position, SpawnShoot_1.transform.rotation); 
            Rigidbody BulletRB = newBullet.GetComponent<Rigidbody>(); 
            BulletRB.velocity = this.transform.forward * BulletSpeed;
        }
        
        _isShooting = false;

        if (_isShooting2)
        {
            GameObject newBullet_L = Instantiate(Iron_Cutter, SpawnShoot_2.transform.position, SpawnShoot_2.transform.rotation); 
            Rigidbody Bullet_LRB = newBullet_L.GetComponent<Rigidbody>();
            Bullet_LRB.velocity = this.transform.forward * BulletSpeed;
        }
        _isShooting2 = false;

       if (BMisile == true)
        {
            if (_isShooting3)
            {
                _misileShots --;               
                GameObject newBullet_M = Instantiate(Misile, SpawnShoot_3.transform.position, SpawnShoot_3.transform.rotation); 
                Rigidbody Misile_RB = newBullet_M.GetComponent<Rigidbody>();
                Misile_RB.velocity = this.transform.forward * BulletSpeed;
            }
            _isShooting3 = false;

            if(_misileShots <= 0)
            {
                BMisile = false;
                misileholder.SetActive(true);
            }
        }
    }
}

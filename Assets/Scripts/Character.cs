using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float speed = 6.0f;
    public float dspeed = 52.0f;
    public float rotateSpeed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    public GameObject Rocket_Punch;
    public GameObject Iron_Cutter;
    public float BulletSpeed = 100f;
    public GameObject Misile;
    public GameObject MisileDummy;
    private bool _isShooting;
    private bool _isShooting2;
    private bool _isShooting3;
    public bool BMisile;
    public int _misileShots;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    //private int jumps;


    // Start is called before the first frame update
    void Start()
    {
        BMisile = false;
        _misileShots = 0;
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //Movement
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveDirection.y = jumpSpeed;
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                moveDirection *= dspeed;
            }
        }


        transform.Rotate(0, Input.GetAxis("Horizontal"), 0);
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        //Shooting
        _isShooting |= Input.GetMouseButtonDown(0);
        _isShooting2 |= Input.GetMouseButtonDown(1);
        _isShooting3 |= Input.GetKeyDown(KeyCode.E);

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "misil")
        {
            BMisile = true;
            _misileShots = 5;
            MisileDummy.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        if (_isShooting)
        {
            // 5
            GameObject newBullet = Instantiate(Rocket_Punch,
                this.transform.position + new Vector3(1.5f, 1, 0),
                this.transform.rotation); // 6
            Rigidbody BulletRB =
                 newBullet.GetComponent<Rigidbody>();
            // 7
            BulletRB.velocity = this.transform.forward *
                                            BulletSpeed;
        }
        // 8
        _isShooting = false;

        if (_isShooting2)
        {
            // 5
            GameObject newBullet_L = Instantiate(Iron_Cutter,
                this.transform.position + new Vector3(-1.5f, 1, 0),
                this.transform.rotation); // 6
            Rigidbody Bullet_LRB =
                 newBullet_L.GetComponent<Rigidbody>();
            // 7
            Bullet_LRB.velocity = this.transform.forward *
                                            BulletSpeed;
        }
        // 8
        _isShooting2 = false;

       if (BMisile == true)
        {
            if (_isShooting3)
            {
                _misileShots --;
                // 5
                GameObject newBullet_M = Instantiate(Misile,
                    this.transform.position + new Vector3(0, 3, 0),
                    this.transform.rotation); // 6
                Rigidbody Misile_RB =
                     newBullet_M.GetComponent<Rigidbody>();
                // 7
                Misile_RB.velocity = this.transform.forward *
                                                BulletSpeed;
            }
            // 8
            _isShooting3 = false;

            if(_misileShots <= 0)
            {
                BMisile = false;
            }
        }
    }
}

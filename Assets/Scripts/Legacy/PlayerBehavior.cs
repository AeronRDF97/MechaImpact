using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float MoveSpeed = 10f;
    public float RotateSpeed = 75f;
    private float _vInput;
    private float _hInput;
    private Rigidbody _rb;
    public float DistanceToGround = 0.1f; // 2
    public LayerMask GroundLayer;
    public GameObject Rocket_Punch;
    public GameObject Iron_Cutter;
    public float BulletSpeed = 100f;
    private bool _isShooting;
    private bool _isShooting2;
    //private GameBehavior _gameManager;
    private CapsuleCollider _col;
    public float JumpVelocity = 15f;
    private bool _isJumping;
    public GameObject mCode;
    public GameObject _Wings;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _col = GetComponent<CapsuleCollider>();

        //_gameManager = GameObject.Find("Game_Manager").GetComponent<GameBehavior>();
    }
    // Update is called once per frame

    void OnCollisionEnter(Collision collision)
    {
        // 4
        if (collision.gameObject.name == "Enemy")
        {
            // 5
           // _gameManager.HP -= 1;
        }
    }

    void Update()
    {
        _isShooting |= Input.GetMouseButtonDown(0);
        _isShooting2 |= Input.GetMouseButtonDown(1);
        _isJumping |= Input.GetKeyDown(KeyCode.Space);

        _vInput = Input.GetAxis("Vertical") * MoveSpeed;
        _hInput = Input.GetAxis("Horizontal") * RotateSpeed;
        /*this.transform.Translate(Vector3.forward * _vInput * Time.deltaTime);
        this.transform.Rotate(Vector3.up * _hInput * Time.deltaTime);*/
    }

    private void FixedUpdate()
    {
        if (IsGrounded() && _isJumping)
        {
            _rb.AddForce(Vector3.up * JumpVelocity,
                 ForceMode.Impulse);
        }


        _isJumping = false;

        Vector3 rotation = Vector3.up * _hInput;
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);

        _rb.MovePosition(this.transform.position + this.transform.forward * _vInput * Time.fixedDeltaTime);
        _rb.MoveRotation(_rb.rotation * angleRot);

        if (_isShooting)
        {
            // 5
            GameObject newBullet = Instantiate(Rocket_Punch,
                this.transform.position + new Vector3(1, 0, 0),
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
                this.transform.position + new Vector3(-1, 0, 0),
                this.transform.rotation); // 6
            Rigidbody Bullet_LRB =
                 newBullet_L.GetComponent<Rigidbody>();
            // 7
            Bullet_LRB.velocity = this.transform.forward *
                                            BulletSpeed;
        }
        // 8
        _isShooting2 = false;

    }

    private bool IsGrounded()
    {
        // 7
        Vector3 BoxBottom = new Vector3(_col.bounds.center.x,
             _col.bounds.min.y, _col.bounds.center.z);
        // 8
        bool grounded = Physics.CheckCapsule(_col.bounds.center,
            BoxBottom, DistanceToGround, GroundLayer,
               QueryTriggerInteraction.Ignore);
        // 9
        return grounded;
    }
}

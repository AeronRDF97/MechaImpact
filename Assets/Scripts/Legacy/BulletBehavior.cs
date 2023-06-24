using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float OnscreenDelay = 3f;
    void Start()
    {
        // 2
        Destroy(this.gameObject, OnscreenDelay);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }
}

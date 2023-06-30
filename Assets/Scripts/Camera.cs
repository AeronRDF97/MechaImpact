using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Vector3 CamOffset = new Vector3(0f, 3.66f, -4.91f);
    public Vector3 Camfirst = new Vector3(0f, 0f, 0f);
    private Transform _target;

    void Start()
    {
        _target = GameObject.Find("CamPos").transform;
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            this.transform.position = _target.TransformPoint(Camfirst);
            this.transform.LookAt(_target);
        }
        else
        {
            this.transform.position = _target.TransformPoint(CamOffset);
            this.transform.LookAt(_target);
        }
    }
}

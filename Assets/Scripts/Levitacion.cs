using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levitacion : MonoBehaviour
{
    
    public float amplitude = 0.1f;
    public float frequency = 1f;

    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

  

    void Update()
    {

        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = tempPos;
    }
}

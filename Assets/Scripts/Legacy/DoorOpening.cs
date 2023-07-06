using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : MonoBehaviour
{
    public GameObject door;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            door.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class Pausa : MonoBehaviour
{
    public GameObject Menu_Pausa;
    public Button Continuar;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            Menu_Pausa.SetActive(true);
            Time.timeScale = 0f;
            Debug.Log("Pausa");
        }
    }
    public void Boton_Continuar()
    {
        Time.timeScale = 1f;
        Menu_Pausa.SetActive(false);
    }
}

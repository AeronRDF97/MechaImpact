using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    public GameObject Menu_Pausa;
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
        Debug.Log("Continuar");
    }

    public void Quitar()
    {
        Application.Quit();
        Debug.Log("Exit");
    }

    public void Reiniciar()
    {
        SceneManager.LoadScene("Escenario");
        Time.timeScale = 1f;
        Debug.Log("Try Again");
    }
}

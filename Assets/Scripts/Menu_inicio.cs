using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_inicio : MonoBehaviour
{
    public void Quitar()
    {
        Application.Quit();
    }

    public void Iniciar()
    {
        SceneManager.LoadScene("Tutorial");
    }
}

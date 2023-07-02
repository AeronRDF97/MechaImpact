using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Endgame : MonoBehaviour
{

    
   
    public GameObject re_startButton;
    public GameObject EndgameMenu;

    // Start is called before the first frame update
    void Start()
    {
       
        re_startButton.SetActive(false);
        EndgameMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Key")
        {
            re_startButton.SetActive(true);
            EndgameMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void OnceAgain()
    {
        SceneManager.LoadScene("Escenario");
        Time.timeScale = 1f;
    }
}

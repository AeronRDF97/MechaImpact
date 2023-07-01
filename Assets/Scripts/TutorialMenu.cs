using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialMenu : MonoBehaviour
{

    public GameObject firstImage;
    public GameObject secondImage;
    public GameObject thirdImage;
    public GameObject secondButton;
    public GameObject thirdButton;
    public GameObject startButton;



    // Start is called before the first frame update
    void Start()
    {
        firstImage.SetActive(true);
        secondImage.SetActive(false);
        thirdImage.SetActive(false);
        secondButton.SetActive(true);
        thirdButton.SetActive(false);
        startButton.SetActive(false);
    }


    public void SecondButton()
    {
        firstImage.SetActive(false);
        secondImage.SetActive(true);
        thirdImage.SetActive(false);
        secondButton.SetActive(false);
        thirdButton.SetActive(true);
        startButton.SetActive(false);
    }
   
    public void ThirdBUtton()
    {
        firstImage.SetActive(false);
        secondImage.SetActive(false);
        thirdImage.SetActive(true);
        secondButton.SetActive(false);
        thirdButton.SetActive(false);
        startButton.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Escenario");
    }

}

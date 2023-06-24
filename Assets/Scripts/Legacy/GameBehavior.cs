using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameBehavior : MonoBehaviour
{

    public int MaxItems = 4; // 3
    public TextMeshProUGUI HealthText; 
    public TextMeshProUGUI ItemText; 
    public TextMeshProUGUI ProgressText; // 4
    public Button WinButton;

    void Start()
    {
        ItemText.text += _itemsCollected;
        HealthText.text += _playerHP;
    }
    private int _itemsCollected = 0;
    private int _playerHP = 10;

    // 1
    public int Items
    {
        // 2
        get { return _itemsCollected; } // 3
        set
        {
            _itemsCollected = value;
            // 5
            ItemText.text = "Items Collected: " + Items; // 6
            if (_itemsCollected >= MaxItems)
            {
                ProgressText.text = "You've found all the items!";
                WinButton.gameObject.SetActive(true);
                Time.timeScale = 0f;
            }
            else
            {
                ProgressText.text = "Item found, only " + (MaxItems - _itemsCollected) + " more to go!";
            }
        }
    }
    // 4
    
    public int HP
    {
        get { return _playerHP; }
        set
        {
            _playerHP = value;
            HealthText.text = "Player Health: " + HP;
            Debug.LogFormat("Lives: {0}", _playerHP);
        }
    }

    public void RestartScene()
    {
        // 3
        SceneManager.LoadScene(0); // 4
        Time.timeScale = 1f;
    }
}

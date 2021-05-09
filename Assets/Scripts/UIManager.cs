using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private GameManager _gameManager; 
    private Button _startButton;
    private Button _quitButton;
    
    // Start is called before the first frame update
    void Start()
    {
        GetRefs();
        Setup();
    }

    private void Setup()
    {
        _startButton.onClick.AddListener(()=> StartGame());
        _quitButton.onClick.AddListener(()=> Application.Quit(0));
    }

    private void StartGame()
    {
        gameObject.SetActive(false);
        _gameManager.GameIsOn = true;
    }

    private void GetRefs()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _startButton = transform.Find("Buttons/Start").GetComponent<Button>();
        _quitButton = transform.Find("Buttons/Quit").GetComponent<Button>();
    }
    
}

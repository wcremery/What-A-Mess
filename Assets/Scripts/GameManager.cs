using System;
using System.Collections;
using System.Collections.Generic;
using Settings;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    private DataManager _dataManager;
    private SettingData _settingData;
    private Interaction[] _interactions;
    private List<Interaction> _playerInteractions;
    private PlayerController _playerController;
    private TextMeshProUGUI _textMeshProUGUI;
    private bool _lookForCollision;
    private bool _gameIsOn;
    private bool _start;

    public bool GameIsOn
    {
        get => _gameIsOn;
        set => _gameIsOn = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        GetRefs();
        Setup();
        GetInteractions();
        DisplayMaze(false);
    }

    private void GetInteractions()
    {
        GetPlayerInteractions();
    }

    private void GetPlayerInteractions()
    {
        for (int i = 0; i < _interactions.Length; i++)
        {
            if (_interactions[i].FirstActor.Equals("Player"))
            {
                _playerInteractions.Add(_interactions[i]);
            }
        }
    }

    private void Setup()
    {
        _settingData = _dataManager.Setting;
        _interactions = _settingData.Interactions;
        _lookForCollision = true;
        _gameIsOn = false;
        _start = true;
    }

    private void GetRefs()
    {
        _dataManager = FindObjectOfType<DataManager>();
        _playerInteractions = new List<Interaction>();
        _playerController = FindObjectOfType<PlayerController>();
        _textMeshProUGUI = GameObject.Find("Message").GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (_gameIsOn)
        {
            if (_start)
            {
                StartCoroutine(DisplayMessage("Reach the pentagram to escape !"));
                _start = false;
            }
            
            if (_lookForCollision)
            {
                CheckCollision();
            }

            DisplayMaze(Input.GetKey(KeyCode.C));
        }
    }

    private void DisplayMaze(bool cheatOn)
    {
        GameObject background = GameObject.Find("Background");
        SpriteRenderer backgroundSpriteRenderer = background.GetComponent<SpriteRenderer>();
        
        if (cheatOn)
        {
            backgroundSpriteRenderer.sortingOrder = 0;
            return;
        }
        
        backgroundSpriteRenderer.sortingOrder = 1;
    }

    private void CheckCollision()
    {
        for (int i = 0; i < _playerInteractions.Count; i++)
        {
            Interaction currentInteraction = _interactions[i];

            if (_playerController.PlayerCollideWith != null)
            {
                string colliderTag = _playerController.PlayerCollideWith.tag;

                if (currentInteraction.SecondActor.Equals("Wall"))
                {
                    if (colliderTag.Equals("Wall"))
                    {
                        int messageIndex = Random.Range(0, currentInteraction.Message.Length);
                        StartCoroutine(DisplayMessage(currentInteraction.Message[messageIndex]));
                    }
                }
                else if (currentInteraction.SecondActor.Equals("Crow"))
                {
                    if (colliderTag.Equals("Crow"))
                    {
                        int messageIndex = Random.Range(0, currentInteraction.Message.Length);
                        StartCoroutine(DisplayMessage(currentInteraction.Message[messageIndex]));
                    }
                }
                else if (currentInteraction.SecondActor.Equals("Pentagram"))
                {
                    if (colliderTag.Equals("Pentagram"))
                    {
                        int messageIndex = Random.Range(0, currentInteraction.Message.Length);
                        StartCoroutine(DisplayMessage(currentInteraction.Message[messageIndex]));
                        _playerController.PlayerCollideWith.GetComponent<SpriteRenderer>().sprite =
                            Resources.Load<Sprite>(currentInteraction.Sprites[0]);
                        _gameIsOn = false;
                    }
                }
            }
        }
    }

    private IEnumerator DisplayMessage(string message)
    {
        _textMeshProUGUI.text = message;
        _lookForCollision = false;
        yield return new WaitForSeconds(1.5f);
        _textMeshProUGUI.text = "";
        _lookForCollision = !_lookForCollision;
    }
}
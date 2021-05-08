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

    // Start is called before the first frame update
    void Start()
    {
        GetRefs();
        Setup();
        GetInteractions();
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
    }

    private void GetRefs()
    {
        _dataManager = FindObjectOfType<DataManager>();
        _playerInteractions = new List<Interaction>();
        _playerController = FindObjectOfType<PlayerController>();
        _textMeshProUGUI = FindObjectOfType<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (_lookForCollision)
        {
            for (int i = 0; i < _playerInteractions.Count; i++)
            {
                Interaction currentInteraction = _interactions[i];

                if (_playerController.PlayerCollideWith.Equals("Wall"))
                {
                    int messageIndex = Random.Range(0, currentInteraction.Message.Length);
                    StartCoroutine(DisplayMessage(currentInteraction.Message[messageIndex]));
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
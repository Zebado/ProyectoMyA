using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudPlayer : MonoBehaviour
{
    [SerializeField] GameObject[] _hearts;
    int _maxIndex;
    int _currentIndex;
    [SerializeField] LifePlayerHandler _lifePlayer;
    [SerializeField] GameObject _win;
    [SerializeField] GameObject _lose;
    private void OnEnable()
    {
        EventManager.SusbcribeToEvent(EventsType.Event_SubstractLife, DisableHeart);
        EventManager.SusbcribeToEvent(EventsType.Event_RecoverLife, ActiveHeart);
        EventManager.SusbcribeToEvent(EventsType.Event_Win, WinGame);
    }

    private void WinGame(object[] parameters)
    {
        _win.SetActive(true);
    }
    void LoseGame(object[] parameters)
    {
        _lose.SetActive(true);
    }

    private void Awake()
    {
        _maxIndex = _hearts.Length;
        _currentIndex = _maxIndex;
    }
    private void DisableHeart(params object[] parameters)
    {
        if (_currentIndex > 0)
        {
            if (_lifePlayer.currentLife == _currentIndex) return;
            _currentIndex--;
            _hearts[_currentIndex].SetActive(false);
        }
    }
    public void ActiveHeart(params object[] parameters)
    {
        if (parameters != null && parameters.Length > 0)
        {
            int amount = Convert.ToInt32(parameters[0]);

            for (int i = 0; i < amount; i++)
            {
                if (_currentIndex < _maxIndex)
                {
                    _hearts[_currentIndex].SetActive(true);
                    _currentIndex++;
                }
            }
        }
    }
    private void OnDisable()
    {
        EventManager.UnsusbcribeToEvent(EventsType.Event_SubstractLife, DisableHeart);
        EventManager.UnsusbcribeToEvent(EventsType.Event_RecoverLife, ActiveHeart);
        EventManager.UnsusbcribeToEvent(EventsType.Event_Win, WinGame);
    }
}

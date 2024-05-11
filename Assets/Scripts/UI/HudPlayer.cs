using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudPlayer : MonoBehaviour
{
    [SerializeField] GameObject[] _hearts;
    int _maxIndex;
    int _currentIndex;
    private void OnEnable()
    {
        EventManager.SusbcribeToEvent(EventsType.Event_SubstractLife, DisableHeart);
        EventManager.SusbcribeToEvent(EventsType.Event_RecoverLife, ActiveHeart);
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
            _currentIndex--;
            _hearts[_currentIndex].SetActive(false);
        }
    }
    public void ActiveHeart(params object[] parameters)
    {
        if (_currentIndex < _maxIndex)
        {
            _hearts[_currentIndex].SetActive(true);
            _currentIndex++;
        }
    }
    private void OnDisable()
    {
        EventManager.UnsusbcribeToEvent(EventsType.Event_SubstractLife, DisableHeart);
        EventManager.UnsusbcribeToEvent(EventsType.Event_RecoverLife, ActiveHeart);
    }
}

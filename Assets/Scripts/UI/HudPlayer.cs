using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudPlayer : MonoBehaviour
{
    [SerializeField] GameObject[] _hearts;
    int maxIndex;
    int _currentIndex;
    private void OnEnable()
    {
        DamageHandler.damage += DisableHeart;
        Posion.addlife += ActiveHeart;
    }
    private void Awake()
    {
        maxIndex = _hearts.Length;
        _currentIndex = maxIndex;
    }
    private void DisableHeart(int i)
    {
        if (_currentIndex > 0)
        {
            _currentIndex--;
            _hearts[_currentIndex].SetActive(false);
        }
    }
    public void ActiveHeart()
    {
        if (_currentIndex < maxIndex)
        {
            _hearts[_currentIndex].SetActive(true);
            _currentIndex++;
        }
    }
    private void OnDisable()
    {
        DamageHandler.damage -= DisableHeart;
        Posion.addlife -= ActiveHeart;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonChangeScene : MonoBehaviour
{
    [SerializeField] Button _button;

    private void OnEnable()
    {
        _button.onClick.AddListener(GameManager.Instance.ChangeScene);

    }
    private void OnDisable()
    {
        _button.onClick?.RemoveListener(GameManager.Instance.ChangeScene);
    }
}

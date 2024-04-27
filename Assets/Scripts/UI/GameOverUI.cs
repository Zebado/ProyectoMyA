using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    private void Awake()
    {
        EventManager.SusbcribeToEvent(EventsType.Event_PlayerDead, TurnOnGameObject);
    }
    void TurnOnGameObject(object[] p)
    {
        gameObject.SetActive(true);

        EventManager.UnsusbcribeToEvent(EventsType.Event_PlayerDead, TurnOnGameObject);
    }
}

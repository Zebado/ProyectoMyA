using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public enum EventsType
{
    Event_PlayerDead,
    Event_Win,
    Event_NextLevel,
    Event_SubstractLife,
    Event_RecoverLife
}
public class EventManager
{

    public delegate void MethodToSuscribe(params object[] parameters);

    static Dictionary<EventsType, MethodToSuscribe> _events;

    public static void SusbcribeToEvent(EventsType eventsType, MethodToSuscribe methodToSuscribe)
    {
        //si el diccionario no esta inicializado, lo hago
        if (_events == null) _events = new Dictionary<EventsType, MethodToSuscribe>();

        if (!_events.ContainsKey(eventsType)) _events.Add(eventsType, null);

        //Suscribo el nuevo metodo al evento
        _events[eventsType] += methodToSuscribe;
    }

    public static void UnsusbcribeToEvent(EventsType eventsType, MethodToSuscribe methodToUnSuscribe)
    {
        if (_events == null || !_events.ContainsKey(eventsType)) return;

        _events[eventsType] -= methodToUnSuscribe;

        // Si no hay m�s suscriptores, eliminamos la entrada del diccionario
        if (_events[eventsType] == null)
        {
            _events.Remove(eventsType);
        }
    }


    public static void TriggerEvent(EventsType eventsType, params object[] parameters)
    {
        if (_events == null || !_events.ContainsKey(eventsType)) return;

        _events[eventsType]?.Invoke(parameters);
    }
}

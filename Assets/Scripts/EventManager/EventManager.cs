using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EventsType
{
     Event_PlayerDead,
     Event_Win

}
public class EventManager
{

    public delegate void MethodToSuscribe(params object[] parameters);

    static Dictionary<EventsType, MethodToSuscribe> _events;

    public static void SusbcribeToEvent(EventsType eventsType, MethodToSuscribe methodToSuscribe)
    {
        //si el diccionario no esta inicializado, lo hago
        if(_events == null) _events = new Dictionary<EventsType, MethodToSuscribe>();

        //si no existe el evento en el diccionario
        _events.TryAdd(eventsType, null);
        //Suscribo el nuevo metodo al evento
        _events[eventsType] += methodToSuscribe; 
    }

    public static void UnsusbcribeToEvent(EventsType eventsType, MethodToSuscribe methodToUnSuscribe)
    {
        if (_events == null) return;

        if (!_events.ContainsKey(eventsType)) return;

        _events[eventsType] -= methodToUnSuscribe;
    }

    public static void TriggerEvent(EventsType eventsType, params object[] parameters)
    {
        if (_events == null) return;

        if (!_events.ContainsKey(eventsType)) return;

        if (_events[eventsType] == null) return;

        _events[eventsType](parameters);
    }
}

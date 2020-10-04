using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class CustomEventManager //not most efficient but this way wont have to do monobehaviour instance and I can have some fun with .NET hehe
{

    private static Dictionary<string, List<UnityEvent>> OnNodeActivatedEvents = new Dictionary<string, List<UnityEvent>>();

    public static void ActivateOnNodeActivatedEvent(string eventName)
    {
        ConstructDictionaryMemberIfNotExists(eventName, OnNodeActivatedEvents);

        foreach(var s in OnNodeActivatedEvents[eventName])
        {
            s.Invoke();
        }

    }

    public static void SubscribeEvent(string eventName, UnityEvent action)
    {
        ConstructDictionaryMemberIfNotExists(eventName, OnNodeActivatedEvents);

        OnNodeActivatedEvents[eventName].Add(action);
    }

    public static void UnSubscribeEvent(string eventName, UnityEvent action)
    {
        ConstructDictionaryMemberIfNotExists(eventName, OnNodeActivatedEvents);

        OnNodeActivatedEvents[eventName].Remove(action);
    }

    private static void ConstructDictionaryMemberIfNotExists(string key, Dictionary<string, List<UnityEvent>> eventDict)
    {
        if (!eventDict.ContainsKey(key))
        {
            eventDict.Add(key, new List<UnityEvent>());
        }
    }

}

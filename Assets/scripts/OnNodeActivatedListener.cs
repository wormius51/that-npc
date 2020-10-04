using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class OnNodeActivatedListener: MonoBehaviour
{

    [SerializeField]
    CustomEventListener[] OnNodeActivatedListenedEvents;

   

    private void OnEnable()
    {
        foreach(var s in OnNodeActivatedListenedEvents)
        {
            CustomEventManager.SubscribeEvent(s.listenedEvent, s.listenerFunction);
        }

    }

    private void OnDisable()
    {
        foreach (var s in OnNodeActivatedListenedEvents)
        {
            CustomEventManager.UnSubscribeEvent(s.listenedEvent, s.listenerFunction);
        }
    }

}

[Serializable]
public class CustomEventListener
{
    public string listenedEvent;
    public UnityEvent listenerFunction; //have to do it this way if we want to do an editor workflow without custom editors.
}

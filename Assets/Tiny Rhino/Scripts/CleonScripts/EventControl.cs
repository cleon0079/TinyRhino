using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Create a handler for my onclick event function
public delegate void ClickedHandler(params object[] _objs);

public class EventControl
{
    // Create a dictionary to save my food 
    Dictionary<string, Dictionary<int, ClickedHandler>> listeners = new Dictionary<string, Dictionary<int, ClickedHandler>>();
    readonly string seedErrorMessage = "DispatchEvent Error, Event:{0}, Error:{1},{2}";
    private static EventControl selfEventControl;
    public static EventControl eventControl
    {
        get
        {
            if (selfEventControl == null)
                selfEventControl = new EventControl();
            return selfEventControl;
        }
    }

    public void SignIn(string _eventName, ClickedHandler _handler)
    {
        // If no food is clicked then dont run
        if (_handler == null)
            return;

        // null check
        if(!listeners.ContainsKey(_eventName))
        {
            listeners.Add(_eventName, new Dictionary<int, ClickedHandler>());
        }
        // Give a number for the food we click and locat it
        Dictionary<int, ClickedHandler> handlerDic = listeners[_eventName];
        // Get the number we give
        int handlerHash = _handler.GetHashCode();
        // If there is then remove it
        if(handlerDic.ContainsKey(handlerHash))
        {
            handlerDic.Remove(handlerHash);
        }
        // Add the food in to the final event dictionary
        listeners[_eventName].Add(_handler.GetHashCode(), _handler);
    }

    public void SignOut(string _eventName, ClickedHandler _handler)
    {
        // If no food is clicked then dont run
        if (_handler == null)
            return;

        // Remove everything we add in the dictionary after we used it
        if(listeners.ContainsKey(_eventName))
        {
            listeners[_eventName].Remove(_handler.GetHashCode());
            if(listeners[_eventName] == null || listeners[_eventName].Count == 0)
            {
                listeners.Remove(_eventName);
            }
        }
    }

    public void DispatchEvent(string _eventName, params object[] _objs)
    {
        // when we clicked the food and do this
        if(listeners.ContainsKey(_eventName))
        {
            // Give a number the food we click
            Dictionary<int, ClickedHandler> handlerDic = listeners[_eventName];
            if(handlerDic != null && handlerDic.Count > 0)
            {
                // Give the food we click a hander to trigger the event we made
                Dictionary<int, ClickedHandler> dic = new Dictionary<int, ClickedHandler>(handlerDic);
                foreach (ClickedHandler f in dic.Values)
                {
                    try
                    {
                        f(_objs);
                    }
                    catch (System.Exception ex)
                    {
                        Debug.LogErrorFormat(seedErrorMessage, _eventName, ex.Message, ex.StackTrace);
                    }
                }
            }
        }
    }

    public void ClearEvents(string _eventName)
    {
        if(listeners.ContainsKey(_eventName))
        {
            listeners.Remove(_eventName);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class door : MonoBehaviour
{
    [SerializeField]
    UnityEvent openEvent;
    [SerializeField]
    UnityEvent closedEvent;
    public void open()
    {
        Collider2D col = gameObject.GetComponent<Collider2D>();
        col.enabled = false;
        //this is where you add animations
        if(openEvent != null)
        {
            openEvent.Invoke();
        }

    }
    public void close()
    {
        Collider2D col = gameObject.GetComponent<Collider2D>();
        col.enabled = true;
        if(closedEvent != null)
        {
            closedEvent.Invoke();
        }
        //animations
    }
}

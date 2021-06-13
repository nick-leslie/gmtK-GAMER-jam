using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class triggerEvents : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onEnter;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (onEnter != null)
            {
                onEnter.Invoke();
            }
        }
    }
}

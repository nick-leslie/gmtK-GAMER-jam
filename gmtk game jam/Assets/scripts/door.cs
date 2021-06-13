using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public void open()
    {
        Collider2D col = gameObject.GetComponent<Collider2D>();
        col.enabled = false;
        //this is where you add animations
    }
    public void close()
    {
        Collider2D col = gameObject.GetComponent<Collider2D>();
        col.enabled = true;
        //animations
    }
}

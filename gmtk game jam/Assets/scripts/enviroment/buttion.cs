using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class buttion : MonoBehaviour
{
    [Header("events")]
    [SerializeField]
    private string[] vallidTags;
    [SerializeField]
    private UnityEvent open;
    [SerializeField]
    private UnityEvent closed;
    [Header("flags")]
    [SerializeField]
    private bool presureSensitive;
    [SerializeField]
    private bool NeedsToBeHeld;
    [Header("values")]
    private float requiredMass;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (checkIfValid(collision.gameObject) == true)
        {
            //brodcast open
            if (open != null)
            {
                if (presureSensitive == true)
                {
                    presureOpen(collision.gameObject);
                } else
                {
                    open.Invoke();
                }
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(NeedsToBeHeld == true)
        {
            if(checkIfValid(collision.gameObject)==true)
            {
                //brodcast closed
                if (closed != null)
                {
                    closed.Invoke();
                }
            }
        }   
    }
    private bool checkIfValid(GameObject obj)
    {
        for (int i = 0; i < vallidTags.Length; i++)
        {
            if (obj.CompareTag(vallidTags[i]))
            {
                Debug.Log("returns true");
                return true;
            }

        }
        Debug.Log("returns false");
        return false;
    }
    private void presureOpen(GameObject other)
    {
        if (presureSensitive == true)
        {
            Rigidbody2D colRb = other.GetComponent<Rigidbody2D>();
            if (colRb != null)
            {
                if (colRb.mass >= requiredMass)
                {
                    open.Invoke();
                }
            }
        }
    }

}

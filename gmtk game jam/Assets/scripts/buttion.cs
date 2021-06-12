using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class buttion : MonoBehaviour
{
    [SerializeField]
    private bool NeedsToBeHeld;
    [SerializeField]
    private string[] vallidTags;
    [SerializeField]
    private UnityEvent open;
    [SerializeField]
    private UnityEvent closed;
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
                open.Invoke();
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
            if (vallidTags[i] == obj.tag)
            {
                Debug.Log("returns true");
                return true;
            }

        }
        Debug.Log("returns false");
        return false;
    }

}

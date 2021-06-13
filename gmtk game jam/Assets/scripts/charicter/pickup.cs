using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    [SerializeField]
    private Throw ThrowManiger;
    private List<GameObject> objInZone;
    private void Start()
    {
        objInZone = new List<GameObject>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(shouldAddToZone(collision.gameObject)==true)
        {
            objInZone.Add(collision.gameObject);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        objInZone.Remove(collision.gameObject);
    }
    bool shouldAddToZone(GameObject other)
    {
        for (int i = 0; i < objInZone.Count; i++)
        {
            if(other == objInZone[i])
            {
                return false;
            }
        }
        return true;
    }
    private void Update()
    {
        checkPickup();
    }
    void checkPickup()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (objInZone.Count > 0)
            {
                for (int i = 0; i < objInZone.Count; i++)
                {
                    if (ThrowManiger != null)
                    {
                        if (objInZone[i].CompareTag("brain") == true || objInZone[i].CompareTag("throwable") == true)
                        {
                            if (ThrowManiger.HeldObj == null)
                            {
                                ThrowManiger.HeldObj = objInZone[i];
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}

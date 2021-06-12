using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    [SerializeField]
    private Throw ThrowManiger;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (ThrowManiger != null)
            {
                if(collision.CompareTag("brain")==true || collision.CompareTag("throwable"))
                {
                    ThrowManiger.HeldObj = collision.gameObject;
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cammera : MonoBehaviour
{
    private cammeraControler cControler;
    private bool LookingAtBrawn=true;
    private Transform brain;
    // Start is called before the first frame update
    void Start()
    {
        brain = GameObject.FindGameObjectWithTag("brain").transform;
        cControler = Camera.main.GetComponent<cammeraControler>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if(LookingAtBrawn==true)
            {
                cControler.moveToPoint(brain);
                LookingAtBrawn = false;
            }  else
            {
                cControler.moveToPoint(gameObject.transform);
                LookingAtBrawn = true;
            }
        }
    }
}

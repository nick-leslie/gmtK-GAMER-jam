using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    sceneManiger smaniger;
    // Start is called before the first frame update
    void Start()
    {
        smaniger = gameObject.GetComponent<sceneManiger>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            smaniger.ReloadLvl();
        }
    }
}

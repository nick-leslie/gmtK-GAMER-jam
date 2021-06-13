using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour
{

    public Transform respawnPoint;

    // Start is called before the first frame update
    void Start()
    {
          
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.CompareTag("Player"))
        {
            respawnPoint = GameObject.FindGameObjectWithTag("Respawn").transform;
        } else if(gameObject.CompareTag("brain"))
        {
            respawnPoint = GameObject.FindGameObjectWithTag("RespawnBrain").transform;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazards : MonoBehaviour
{
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player") == true|| collision.gameObject.CompareTag("brain") ){
            collision.transform.position = collision.gameObject.GetComponent<RespawnPoint>().respawnPoint.position;
        }
    }

}

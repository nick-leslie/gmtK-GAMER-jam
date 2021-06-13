using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{

    
    [SerializeField]
    private Transform[] positions;

    private int currentTarget;

    [SerializeField]
    private float proximity;

    [SerializeField]
    private int speed;

    private bool forwards = true;

    private bool moving;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        transform.position = Vector3.MoveTowards(transform.position, positions[currentTarget].position, speed*Time.deltaTime);

        if(Vector2.Distance(transform.position, positions[currentTarget].position) <= proximity) {

            if(currentTarget >= positions.Length-1) {

                forwards = false;
            } else if(currentTarget <= 0) {
                forwards = true;
            }
            if(forwards == true) {
                currentTarget++;
            } else {
                currentTarget--;
            }
            

        }


    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {

            moving = true;
            collision.collider.transform.SetParent(transform);

        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {

            
            collision.collider.transform.SetParent(null);

        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brainBlast : MonoBehaviour
{
    public GameObject shotPrefab;
    private Vector2 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.right = mouseDirectionVector();
        if (Input.GetKeyDown(KeyCode.E))
        {
            shoot(); 
        }
    }
    void shoot()
    {
        transform.up = mouseDirectionVector();
        GameObject fired = Instantiate(shotPrefab, transform.position, transform.rotation);
    }
    Vector2 mouseDirectionVector()
    {
        Vector2 direction = mousePos - (Vector2)transform.position;
        return direction.normalized;
    }
}

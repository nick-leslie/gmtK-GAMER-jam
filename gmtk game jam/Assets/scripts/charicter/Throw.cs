using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    private Transform throwPoint;
    [SerializeField]
    private float throwForce;
    [SerializeField]
    private GameObject heldObject;
    Vector3 mousePos;
    public GameObject point;
    [SerializeField]
    private GameObject[] points;
    [SerializeField]
    private int numberOfPoints;
    [SerializeField]
    private float pointSpred;
    public GameObject HeldObj {
        get
        {
            return heldObject;
        }
        set
        {
            if(value.tag == "throwable" || value.tag == "brain")
            {
                heldObject = value;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        throwPoint = transform;
        points = new GameObject[numberOfPoints];
        for (int i = 0; i < numberOfPoints; i++)
        {
            points[i] = Instantiate(point, throwPoint.position, Quaternion.identity);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(heldObject != null)
        {
            heldObject.transform.position = throwPoint.position;
            changeHeldColliderState(false);
            showTragectory();
        } else
        {
            hideTraggectory();
        }
        throwForce = Vector2.Distance(throwPoint.position, mousePos);
        transform.right = mouseDirectionVector();
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // this is temportary
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            toss();
        }
    }
    void toss() 
    {
        if (heldObject != null)
        {
            Rigidbody2D heldRiggidBody = heldObject.GetComponent<Rigidbody2D>();
            if (heldRiggidBody != null)
            {
                //heldObject.transform.right = mouseDirectionVector();
                heldRiggidBody.velocity = transform.right * throwForce;
                changeHeldColliderState(true);
                heldObject = null;
            }
        }
    }
    void showTragectory()
    {
        for (int i = 0; i < points.Length; i++)
        {
            points[i].SetActive(true);
            points[i].transform.position = ArcPosition(i * pointSpred);
        }
    }
    void hideTraggectory()
    {
        for (int i = 0; i < points.Length; i++)
        {
            points[i].SetActive(false);
        }
    }
    Vector2 mouseDirectionVector()
    {
        Vector2 direction = mousePos - throwPoint.position;
        return direction.normalized;
    }
    Vector2 ArcPosition(float timeStep)
    {
        return (Vector2)throwPoint.position + (mouseDirectionVector()*throwForce*timeStep) + 0.5f * Physics2D.gravity * (timeStep * timeStep);
    }

    public void changeHeldColliderState(bool state)
    {
        Collider2D heldCollider = HeldObj.GetComponent<Collider2D>();
        if (heldCollider != null)
        {
            heldCollider.enabled = state;
        }
    }

    //this is old code that dose not work ignore it 
    //it serves as a reminder never to do projectilel motion again
    float mouseAngle()
    {
        //THIS IS FOR GETING THE ANGE BETWEEN MOUSE AND PLAYER I THINK?
        //I want to die
        return Mathf.Abs(Mathf.Rad2Deg*Mathf.Atan(mouseDirectionVector().y/mouseDirectionVector().x));
    }
    float ProjecitleVelocity()
    {
        //projectile motion is hard this should give us  the intital volocity we need we need
        float top = Mathf.Sqrt(2) * Mathf.Sqrt(Mathf.Abs(Physics2D.gravity.y)) * Mathf.Sqrt(Mathf.Abs(mousePos.y - throwPoint.position.y));
        Debug.Log(top);
        float bottom = Mathf.Sin(Vector2.Angle(throwPoint.position,mousePos));
        Debug.Log(bottom);
        return top / bottom;
    }
}

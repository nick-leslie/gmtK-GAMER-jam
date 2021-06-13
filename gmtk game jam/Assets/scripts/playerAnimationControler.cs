using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
public class playerAnimationControler : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;
    [SerializeField]
    Throw thrower;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb != null)
        {
            animator.SetFloat("velcocity", rb.velocity.magnitude);
        }
        animator.SetBool("holding", holding()); 
    }
    bool holding()
    {
        if(thrower != null)
        {
            if(thrower.HeldObj != null)
            {
                return true;
            } else
            {
                return false;
            }
        }
        return false;
    }
}

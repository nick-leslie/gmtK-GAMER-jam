using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cammeraControler : MonoBehaviour
{
    [Header("tracking varubles")]
    [SerializeField]
    private Transform defaltTracked; // this is the defalt thing that is tracked
    [SerializeField]
    private Transform currentTracked; // this is the current thing that is tracked
    [Header("peramiters")]
    public float cammraSpeed;
    public float closeDistence;
    private float cammraZ;
    [Header("flags")]
    [SerializeField]
    private bool smooth;
    [Header("defalt values")]
    [SerializeField]
    private float defaltDuration;


    //this is for lerping to a static position if the smooth flag is set
    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        currentTracked = defaltTracked;
        cammraZ = defaltTracked.position.z - 1; 
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTracked != null)
        {
            Vector3 target = new Vector3(currentTracked.position.x, currentTracked.position.y, cammraZ);
            if (smooth == false)
            {
                //this is the path for if it is just tracking 
                //this is most commonly used during gameplay 
                transform.position = target;
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, target, cammraSpeed * Time.deltaTime);
            }
        }
    }
    private void changeTracked(Transform newTracked)
    {
        currentTracked = newTracked;
    }
    //this is so start cinimatic can be called using a unity event
    public void StartCinimaticEvent(Transform target)
    {
        StartCoroutine(StartCinimatic(target));
    }
    public void moveToPoint(Transform target)
    {
        StartCoroutine(moveToTarget(target));
    }
    //this is the start cinima where it gose to one tracked and then returns to defalt object
    public IEnumerator StartCinimatic(float duration, Transform target)
    {
        //this sets the smoothflag
        smooth = true;
        changeTracked(target);
        startPos = new Vector3(transform.position.x, transform.position.y, cammraZ);
        yield return StartCoroutine(MoveToLoc(duration));
        StartCoroutine(endShot());
    }
    public IEnumerator StartCinimatic(Transform target)
    {
        //this sets the smoothflag
        smooth = true;
        changeTracked(target);
        startPos = new Vector3(transform.position.x, transform.position.y, cammraZ);
        yield return StartCoroutine(MoveToLoc(defaltDuration));
        StartCoroutine(endShot());
    }
    public IEnumerator moveToTarget(Transform target)
    {
        //this sets the smoothflag
        smooth = true;
        changeTracked(target);
        startPos = new Vector3(transform.position.x, transform.position.y, cammraZ);
        yield return StartCoroutine(MoveToLoc(defaltDuration));
        smooth = false;
    }
    //has to be called as a coroutine
    public IEnumerator StartCinimatic(float duration, Transform[] targetList)
    {
        smooth = true;
        //loop through each transform in postion and move to them and wait untill done to triger next
        for (int i = 0; i < targetList.Length; i++)
        {
            changeTracked(targetList[i]);
            yield return StartCoroutine(MoveToLoc(duration));
        }
        //this resets to player
        yield return StartCoroutine(endShot());
    }
    private IEnumerator MoveToLoc(float duration)
    {
        //wait untill the cammra is within range
        while (Vector2.Distance(transform.position, currentTracked.position) > closeDistence)
        {
            yield return null;
        }
        //hold the shot for duration
        yield return new WaitForSecondsRealtime(duration);
    }
    private IEnumerator endShot()
    {
        changeTracked(defaltTracked);
        while (Vector2.Distance(transform.position, currentTracked.position) > closeDistence)
        {
            yield return null;
        }
        smooth = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour
{
    public float speed = 20.0f;
    public float minDist = 0f;
    public Transform target;
    Rigidbody2D rb;
    // Use this for initialization
    void Start () 
    {
        // if no target specified, assume the player
        if (target == null) {
            if (GameObject.FindWithTag ("Player")!=null)
            {
                target = GameObject.FindWithTag ("Player").GetComponent<Transform>();
            }
        }
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update () 
    {
        if (target == null){
            Debug.Log("No player found");
            return;
        }
        // face the target
        //transform.LookAt(target);
        //get the distance between the chaser and the target
        float distance = Vector3.Distance(transform.position,target.position);
        //so long as the chaser is farther away than the minimum distance, move towards it at rate speed.
        if(distance > minDist){
            Vector3 pos = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            rb.MovePosition(pos);
        }
            // transform.position += Vector3. * speed * Time.deltaTime;    
    }
    // Set the target of the chaser
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}

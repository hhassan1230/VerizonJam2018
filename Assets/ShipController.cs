using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {
    public float speed;
    public Transform hitObject;
    public float maxAngle = 50;
    public float rotSpeed = 2f;

    public float returnSpeed = 0.2f;
	// Use this for initialization
	void Start () {
		
	}
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, proj);
    }

    Vector3 proj;
    // Update is called once per frame
    void Update () {
        

        int layerMask = 1 << 9;

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.yellow);
            hitObject = hit.transform;
        }

        if (hitObject != null)
        {
            Vector3 left = transform.right;
            float angle = Vector3.Angle(hitObject.transform.right, left);
            print(angle);
            if(angle > maxAngle)
            {

            }

            
        }

        Vector3 forward = transform.forward;
        transform.Translate(forward*speed);
        
        
        float horizontal = Input.GetAxis("Horizontal");

         proj = Vector3.Project(Vector3.forward, transform.forward);


        if (horizontal != 0)
        {
            

            transform.Rotate(Vector3.up, horizontal* rotSpeed);
        }

        float vertical = Input.GetAxis("Vertical");

        //if (vertical != 0)
        //{
            
        //    if(transform.rotation)
        //    transform.Rotate(Vector3.up, vertical);
        //}
    }
}

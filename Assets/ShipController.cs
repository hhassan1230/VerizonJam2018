using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {
    public float speed;
    public float axisSpeed;

     float xAxis = 0;
     float yAxis = 0;
     float zAxis = 0;

    public float xRange = 3f;
    public float yRangeUp = 2f;
    public float yRangeDown = -2f;


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
    void Update()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (horizontal != 0)
        {
 
            xAxis += horizontal * axisSpeed;
        }

        if (vertical != 0)
        {

            yAxis += vertical * axisSpeed;
        }
        //if (xAxis < 0)
        //{
        //    xAxis += returnSpeed;

        //}
        //if(xAxis > 0)
        //{
        //    xAxis -= returnSpeed;
        //}
        //if(Mathf.Abs(xAxis) < 0.002f)
        //{
        //    xAxis = 0;
        //}

        if (xAxis > xRange/2)
        {
            xAxis = xRange/2;
        }

        if (xAxis < -xRange / 2)
        {
            xAxis = -xRange / 2;
        }

        if (yAxis > yRangeUp )
        {
            yAxis = yRangeUp;
        }

        if (yAxis < yRangeDown)
        {
            yAxis = yRangeDown;
        }

        zAxis += speed * Time.deltaTime;

        float x = xAxis;
        float y = yAxis;
        float z = zAxis;

        transform.position = new Vector3(x, y, z);
    }

}

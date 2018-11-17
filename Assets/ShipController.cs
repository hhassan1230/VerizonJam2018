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

    public float turningRotationSpeed = 1f;

    private float currentTurningTimeV;
    private float currentTurningTimeH;

    private Vector3 StartRotation;
    private float EndRotationEuler;
    private Quaternion EndRotation;

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
        var rot = transform.rotation.eulerAngles;

        if (horizontal != 0)
        {
            currentTurningTimeH = 0;
            xAxis += horizontal * axisSpeed;
            if (horizontal < 0)
            {
                rot.z = Mathf.Clamp(rot.z + 2, 0, 45);
            }
            else {
                if(rot.z == 0)
                {
                    rot.z = 360;
                }
                rot.z = Mathf.Clamp(rot.z - 2, 315, 360);
            }  
        }
        else
        {
            if(currentTurningTimeH == 0)
            {
                print("SETTING START ROTATION");
                StartRotation.z = rot.z;
                EndRotationEuler = rot.z > 300 ? 360 : 0;
            }

            currentTurningTimeH += Time.deltaTime * turningRotationSpeed;


            if (horizontal == 0 && vertical == 0)
            {
                if (rot.z < 50 && rot.x > 300)
                {
                    EndRotationEuler = 360;
                }
                else if(rot.z > 300 && rot.x < 50)
                {
                    EndRotationEuler = 0;
                }
            }

            print("1- Z: " + StartRotation.z + " -- curZ: " + rot.z + " -- T: " + currentTurningTimeH);
            rot.z = Mathf.Lerp(StartRotation.z, EndRotationEuler, currentTurningTimeH);
            print("2- Z: " + StartRotation.z + " -- curZ: " + rot.z + " -- T: " + currentTurningTimeH);

        }

        if (vertical != 0)
        {
            currentTurningTimeV = 0;
            yAxis += vertical * axisSpeed;

            if (vertical < 0)
            {
                rot.x = Mathf.Clamp(rot.x + 2, 0, 30);
            }
            else {
                if(rot.x == 0)
                {
                    rot.x = 360;
                }
                rot.x = Mathf.Clamp(rot.x - 2, 315, 360);
            }  
        }
        else
        {
            if (currentTurningTimeV == 0)
            {
                StartRotation.x = rot.x;
                EndRotationEuler = rot.x > 300 ? 360 : 0;
            }

            currentTurningTimeV += Time.deltaTime * turningRotationSpeed;

            rot.x = Mathf.Lerp(StartRotation.x, EndRotationEuler, currentTurningTimeV);
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

        else if (xAxis < -xRange / 2)
        {
            rot.z -= 2;

            xAxis = -xRange / 2;
        }

        if (yAxis > yRangeUp )
        {
            yAxis = yRangeUp;
        }

        else if (yAxis < yRangeDown)
        {
            yAxis = yRangeDown;
        }
       
        EndRotation = Quaternion.Euler(rot);


        zAxis += speed * Time.deltaTime;

        float x = xAxis;
        float y = yAxis;
        float z = zAxis;

        transform.position = new Vector3(x, y, z);
        transform.rotation = EndRotation;
        // transform.rotation = Quaternion.Lerp(StartRotation, EndRotation, currentTurningTime / turningRotation);

    }

}

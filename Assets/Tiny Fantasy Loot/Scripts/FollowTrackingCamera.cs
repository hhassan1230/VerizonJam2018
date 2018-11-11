using UnityEngine;

public class FollowTrackingCamera : MonoBehaviour
{
	// Camera target to look at.
	public Transform target;


	public Vector3 CameraRotation; 

	// Exposed vars for the camera position from the target.
	public float height = 20f;
	public float distance = 20f;
	
	// Camera limits.
	public float min = 10f;
	public float max = 60;
	
	// Options.
	//public bool doRotate;
	public bool doZoom;
	public bool doRotate;
	
	// The movement amount when zooming.
	public float zoomStep = 30f;
	public float zoomSpeed = 5f;
	private float heightWanted;
	private float distanceWanted;


	public float xSpeed = 120.0f;
	public float ySpeed = 120.0f;
	
	public float yMinLimit = -20f;
	public float yMaxLimit = 80f;

	public float xMinLimit = 30f;
	public float xMaxLimit = 220f;
	
	public float distanceMin = .5f;
	public float distanceMax = 15f;
	
	public float smoothTime = 2f;
	
	float rotationYAxis = 230.0f;
	float rotationXAxis = -8.0f;
	
	float velocityX = 0.0f;
	float velocityY = 0.0f;


	// Result vectors.
	private Vector3 zoomResult;
	private Quaternion rotationResult;
	private Vector3 targetAdjustedPosition;
	private Quaternion rotation;
	
	void Start(){

		Vector3 angles = transform.eulerAngles;
		rotationYAxis = angles.y;
		rotationXAxis = angles.x;
		// Initialise default zoom vals.
		heightWanted = height;
		distanceWanted = distance;
		
		// Setup our default camera.  We set the zoom result to be our default position.
		zoomResult = new Vector3(0f, height, -distance);
	}
	
	void LateUpdate(){
		// Check target.
		if( !target ){
			Debug.LogError("This camera has no target, you need to assign a target in the inspector.");
			return;
		}
		
		if( doZoom ){
			// Record our mouse input.  If we zoom add this to our height and distance.
			float mouseInput = Input.GetAxis("Mouse ScrollWheel");
			heightWanted -= zoomStep * mouseInput;
			distanceWanted -= zoomStep * mouseInput;
			
			// Make sure they meet our min/max values.
			heightWanted = Mathf.Clamp(heightWanted, min, max);
			distanceWanted = Mathf.Clamp(distanceWanted, min, max);
			
			height = Mathf.Lerp(height, heightWanted, Time.deltaTime * zoomSpeed);
			distance = Mathf.Lerp(distance, distanceWanted, Time.deltaTime * zoomSpeed);
			
			// Post our result.
			zoomResult = new Vector3(0f, height, -distance);
		}
		
		if( doRotate ){

			//if (Input.GetMouseButton(2))
			//{
				velocityX += xSpeed * Input.GetAxis("Mouse X") * distance * 0.02f;
				velocityY += ySpeed * Input.GetAxis("Mouse Y") * 0.02f;
			//}
			
			rotationYAxis += velocityX;
			rotationXAxis -= velocityY;
			
			rotationXAxis = ClampAngle(rotationXAxis, yMinLimit, yMaxLimit);
			//rotationYAxis = ClampAngle(rotationYAxis, xMinLimit, xMaxLimit);
			
//			Quaternion fromRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
			Quaternion toRotation = Quaternion.Euler(rotationXAxis, rotationYAxis, 0);
			Quaternion rotation = toRotation;
			/*
			distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * 5, distanceMin, distanceMax);

			RaycastHit hit;
			if (Physics.Linecast(target.position, transform.position, out hit))
			{
				distance -= hit.distance;
			}*/
			Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);	
			Vector3 position = rotation * negDistance + target.position;


			transform.rotation = rotation;
			transform.position = position;
			
			velocityX = Mathf.Lerp(velocityX, 0, Time.deltaTime * smoothTime);
			velocityY = Mathf.Lerp(velocityY, 0, Time.deltaTime * smoothTime);
		}

		else {
			// Convert the angle into a rotation.
			rotationResult = Quaternion.Euler(CameraRotation);
			//rotationResult = Quaternion.Euler(rotation);
			
			// Set the camera position reference.
			targetAdjustedPosition = rotationResult * zoomResult;
			//targetAdjustedPosition = AnguloInicial * zoomResult;
			transform.position = target.position + targetAdjustedPosition;

		}


		// Face the desired position.
		transform.LookAt(target);

	}
public static float ClampAngle(float angle, float min, float max)
{
	if (angle < -360F)
		angle += 360F;
	if (angle > 360F)
		angle -= 360F;
	
	return Mathf.Clamp(angle, min, max);
}
}
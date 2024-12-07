using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviourNew : MonoBehaviour
{
    public Vector3 CamOffset= new Vector3(0f, 1.2f, -2.6f); 
    public GameObject target; 
    public GameObject player;
    public GameObject targetVisualiser;
    public bool visualiseTarget = false;


    void Start() 
    { 
        player = GameObject.Find("PlayerV1");
        transform.position = player.transform.TransformPoint(CamOffset);
        targetVisualiser = GameObject.Find("target visualiser");
    } 

    /*
    void LateUpdate() 
    { 
        
        this.transform.position = _target.TransformPoint(CamOffset); 
        

        this.transform.LookAt(_target); 

        /*
        //credit to Franco Marini on Unity Discussions, adapted from there
        if (Input.GetMouseButton (0)) 
        {
            Debug.Log("Click registered");
			_difference=Camera.main.ScreenToWorldPoint(Input.mousePosition) - Camera.main.transform.position;
			if (_drag==false)
            {
                Debug.Log("Drag start");
				_drag=true;
				_origin=Camera.main.ScreenToWorldPoint (Input.mousePosition);
			}
		} 
        else 
        {
			_drag=false;
		}
		if (_drag==true)
        {
            Debug.Log("Changing camera position");
			//Camera.main.transform.position = _origin-_difference;
            //try two
            transform.position = _origin-_difference;
        }  

        //RESET CAMERA TO STARTING POSITION WITH RIGHT CLICK
		if (Input.GetMouseButton (1)) 
        {
            Debug.Log("Right click, resetting?");
			Camera.main.transform.position=_resetPoint;
		}
        
    }
    */

    //here's an idea
    //credit to asafsitner on Unity discussions for initial start script
    //values that will be set in the Inspector
	public float RotationSpeed;
    public Vector3 viewPoint = new Vector3(-5, 3, 3);

	//values for internal use
	private Quaternion _lookRotation;
	private Vector3 _direction;
	
	// Update is called once per frame
	void Update()
	{
		//find the vector pointing from our position to the target 
		//_direction = (target.transform.position - transform.position).normalized;

        //but, what if we split the difference between looking at the player, and looking at the target?
        Vector3 halfdistance = (target.transform.position - player.transform.position) / 2;
        Vector3 halfwaypoint = player.transform.position + halfdistance;
        //then look at that point
        Vector3 _direction2 = (halfwaypoint-transform.position).normalized;
        
        if (targetVisualiser != null && visualiseTarget)
        {
            targetVisualiser.transform.position = halfwaypoint;
        }
        

		//create the rotation we need to be in to look at the target
		//_lookRotation = Quaternion.LookRotation(_direction);

        //or look at the halfwaypoint
        _lookRotation = Quaternion.LookRotation(_direction2);

		//rotate us over time according to speed until we are in the required rotation
		transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);

        //now I just need to set the camera position
        transform.position = player.transform.TransformPoint(CamOffset);

	}

    
		



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public Vector3 CamOffset= new Vector3(0f, 1.2f, -2.6f); 
    public Vector3 DefaultOffset = new Vector3(5f, 2.5f, 0f);
    private Transform _target; 

    private bool _drag;
    private Vector3 _origin;
    private Vector3 _difference;
    private Vector3 _resetPoint;

    void Start() 
    { 
        _target = GameObject.Find("PlayerV1").transform; 
        this.transform.position = _target.TransformPoint(DefaultOffset); 
        _resetPoint = Camera.main.transform.position;
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
    //credit to asafsitner on Unity discussions
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
		_direction = (_target.TransformPoint(viewPoint) - transform.position).normalized;

     
		//create the rotation we need to be in to look at the target
		_lookRotation = Quaternion.LookRotation(_direction);

		//rotate us over time according to speed until we are in the required rotation
		transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);

        //now I just need to set the camera position
        this.transform.position = _target.TransformPoint(CamOffset);
	}

    
		



}

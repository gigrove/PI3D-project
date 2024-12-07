using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ClickCamera : MonoBehaviour
{
     private bool _drag;
    private Vector3 _origin;
    private Vector3 _difference;
    private Vector3 _resetPoint;


    public float RotationSpeed = 5;
    //public Vector3 viewPoint = new Vector3(-5, 3, 3);

	//values for internal use
	private Quaternion _lookRotation;
	private Vector3 _direction;
    private Vector3 _clickPoint;

  

    // Update is called once per frame
    void Update()
    {
        /* This is useless rn
        if (Input.GetMouseButton (0)) 
        {
            Debug.Log("Left click registered");
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
        */

        //next attempt, credit for inspiration to asafsitner on unity discussions
	
        if(Input.GetMouseButtonDown(0))
        {
            _clickPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log("Left click to " + _clickPoint.ToString());
        }
	
		//find the vector pointing from our position to the target
		_direction = (_clickPoint - transform.position).normalized;

		//create the rotation we need to be in to look at the target
		_lookRotation = Quaternion.LookRotation(_direction);

		//rotate us over time according to speed until we are in the required rotation
		transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);

	
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float MoveSpeed = 10f;
    public float RotateSpeed = 75f;
    public float FlyVelocity = 5f;
    public TMP_Text ScoreText;
    public TMP_Text WingWedgeText;
    public GameObject ChargingIndicator;
    public static bool isCharging = false;

    public float playerChargeSpeed = 0.001f;



    public Material normalMaterial;
    public Material chargeMaterial;

    public Color normalColour;
    public Color chargeColour;

 

    private float _vInput;
    private float _hInput;
   
    private bool _isBoosting = false;
    private CapsuleCollider _col;
    private MeshRenderer _meshRenderer;
    private Rigidbody _rb;

    private float chargingCounter = 0;
    private float chargeModifier;
    //private int debugVar = 5;


    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _col = GetComponent<CapsuleCollider>();
        _meshRenderer = GetComponent<MeshRenderer>();
        if (ChargingIndicator == null) {
            Debug.Log("No charging indicator assigned");
        }
        else
        {
            ChargingIndicator.SetActive(false);
        }
        

    }

    void Update()
    {
        _vInput = Input.GetAxis("Vertical") * MoveSpeed;
        _hInput = Input.GetAxis("Horizontal") * RotateSpeed;

       
        //WingWedgeText.text = $"{WingWedges} // {chargingCounter}";
        //WingWedgeText.text = WingWedges.ToSafeString();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isBoosting = true;
        }

        if (isCharging)
        {
            normalMaterial.color = chargeColour;
            WingWedgeManager.instance.isCharging = true;
             if(chargingCounter >= 1)
            {
                chargingCounter = 0f;
                WingWedgeManager.instance.WingWedges++;
            }
            else
            {
                chargingCounter += playerChargeSpeed * chargeModifier;
            };
        }
        else
        {
            //_meshRenderer.material = normalMaterial;
            normalMaterial.color = normalColour;
            WingWedgeManager.instance.isCharging = false;
        }

    }

    void FixedUpdate()
    {
        if (_isBoosting) 
        {
            Debug.Log("Attempting to fly...");

            if (WingWedgeManager.instance.WingWedges == 0) 
            {
                chargingCounter = 0f;
                Debug.Log("no wing wedges");
            }
            else 
            {
                Debug.Log("boosting");
                WingWedgeManager.instance.WingWedges -= 1;
                _rb.AddForce(Vector3.up * FlyVelocity, ForceMode.Impulse);
            }
            _isBoosting = false;
        }
     

        Vector3 rotation = Vector3.up * _hInput;
        //Debug.Log(rotation);
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);

        _rb.MovePosition(this.transform.position + this.transform.forward * _vInput * Time.fixedDeltaTime);
        _rb.MoveRotation(_rb.rotation * angleRot);
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "killPlane")
        {
            this.transform.SetPositionAndRotation(Vector3.up * 5, Quaternion.identity);
            Debug.Log("Don't fall off!");
        }

    }


    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Lightsource"))
        {
            isCharging = true;
            chargeModifier = other.GetComponent<LightSource>().chargeModifier;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Lightsource"))
        {
            isCharging = false;
        }
    }

}

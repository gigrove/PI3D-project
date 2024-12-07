using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LightSource : MonoBehaviour
{
    public bool playerCandle = false;
    public bool isLit = false;
    public bool lightsOtherLights = true;
    public float chargeModifier = 1;
    public GameObject Flame;

    void Start()
    {
        gameObject.tag = "Lightsource";
        Flame = transform.Find("LightSourceFlame").gameObject;
        if(Flame == null) 
        {Debug.Log("No flame found");}
        if (!playerCandle) 
        {Flame.SetActive(false);}
    }
    void OnTriggerEnter(Collider other)
    {
        //Debug.Log($"{this.name} detected a trigger enter");
        if (other.CompareTag("Lightsource") && !isLit)
        {
            Debug.Log("light source detected");
            if (other.gameObject.GetComponent<LightSource>() != null && other.gameObject.GetComponent<LightSource>().lightsOtherLights)
            {
                //Debug.Log("Lighting the candle?");
                isLit = true;
                Flame.SetActive(true);
                ScoreManager.instance.Score++;
            }
        }
        
        //else {Debug.Log("The trigger wasn't right");}
    }
}

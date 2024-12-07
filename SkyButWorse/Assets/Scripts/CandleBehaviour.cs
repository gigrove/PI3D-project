using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CandleBehaviour : MonoBehaviour
{
    public bool IsLit = false;
    public GameObject Flame; //assign
    
    void Start()
    {
        Flame.SetActive(false);
    }    
    
    void Update()
    {
        if(IsLit)
        {
            Flame.SetActive(true);
        }
        else {Flame.SetActive(false);}
    }

}

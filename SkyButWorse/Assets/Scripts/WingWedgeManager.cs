using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingWedgeManager : MonoBehaviour
{
    
    public static WingWedgeManager instance;
    public GameObject[] WWDisplays;
    public int maxWingWedges = 4;
    public float scaleIncrease = 3;

    private RectTransform rectTransform;
    private Vector3 baseScale;
    private Vector3 chargeScale;

    private int _ww;
    public int WingWedges 
    {
        get { return _ww; }
        set 
        {
            if (value < 0)
            {
                _ww = 0;
            }
            else if ( value > maxWingWedges)
            {
                _ww = maxWingWedges;
            }
            else
            {
                _ww = value;
            }
        }
    }

    private float chargingCounter = 0;
    public int playerChargeSpeed = 10;
    public bool isCharging = false;
    
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        foreach (GameObject g in WWDisplays)
        {
            g.SetActive(false);
        }
        _ww = maxWingWedges;
        rectTransform = GetComponent<RectTransform>();
        baseScale = rectTransform.localScale;
        chargeScale = baseScale * scaleIncrease;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i <= maxWingWedges; i++)
        {
            if (i == _ww)
            {
                WWDisplays[i].SetActive(true);
            }
            else
            {
                WWDisplays[i].SetActive(false);
            }

        }
        
        if (isCharging)
        {
            rectTransform.localScale = chargeScale;
        }
        else
        {
            rectTransform.localScale = baseScale;
        }
    }
    
}

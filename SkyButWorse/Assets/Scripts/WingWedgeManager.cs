using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingWedgeManager : MonoBehaviour
{
    
    public static WingWedgeManager instance;
    public GameObject[] WWDisplays;
    public int maxWingWedges = 4;

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
    }
}

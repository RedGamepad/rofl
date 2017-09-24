using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stat : MonoBehaviour {
    public Image cont;
    private float currentHlth;
    private float currentFill;

    public float CurrentHlth
    {
        get
        {
            return currentHlth;
        }

        set
        {
            currentHlth = value;
        }
    }

    public float CurrentFill
    {
        get
        {
            return currentFill;
        }

        set
        {
            currentFill = value;
        }
    }

    public void DealDamage (float dmg)
    {
        CurrentHlth -= dmg;
    }

    // Use this for initialization
    void Start () {
        cont.GetComponent<Image>();
        CurrentHlth = 100;
        CurrentFill = 1;
    }
	
	// Update is called once per frame
	void Update () {
        CurrentFill = CurrentHlth / 100;
        cont.fillAmount = CurrentFill;
    }
}

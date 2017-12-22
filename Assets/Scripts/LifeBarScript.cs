using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBarScript : MonoBehaviour {

    public Transform Player;
    public Transform LifeBar;
    public float PvMax;
    public float CurrentPv;

	// Use this for initialization
	void Start () {
        CurrentPv = PvMax;
	}

    public void Damage(int i)
    {
        CurrentPv -= i;
        float fact = CurrentPv / PvMax;
        if(fact <= 0)
            fact = 0;
        LifeBar.localScale = new Vector3(fact, 1, 1);
    }
}

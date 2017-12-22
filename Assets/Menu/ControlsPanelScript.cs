using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlsPanelScript : MonoBehaviour {

	public GameObject panel;

	// Use this for initialization
	void Start () {
		Button btn = GetComponent<Button>();
        btn.onClick.AddListener(StartOnClick);
	}
	
	void StartOnClick()
    {
        panel.SetActive(true);
    }
}

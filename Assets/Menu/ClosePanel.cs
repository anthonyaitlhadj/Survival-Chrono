using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClosePanel : MonoBehaviour {

	public GameObject panel;
	void Start () {
		Button btn = GetComponent<Button>();
        btn.onClick.AddListener(CloseOnClick);
	}
	
	void CloseOnClick()
    {
       panel.SetActive(false);
    }
}

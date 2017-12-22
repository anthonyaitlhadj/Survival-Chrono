using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {

	// Use this for initialization
	void Start(){
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
		Button btn = GetComponent<Button>();
        btn.onClick.AddListener(StartOnClick);
	}
	void StartOnClick()
    {
        SceneManager.LoadScene ("SalleGame");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public GameObject player;
    float currentHeight;
    // Use this for initialization
    void Start () 
    {currentHeight = player.transform.position.y;
    }
    
    void LateUpdate () 
    {
		//float y = Input.GetAxis("Mouse X");
        float x = Input.GetAxis("Mouse Y");
        //Debug.Log(x + " " + y);
        //transform.eulerAngles += 
        //float XClamp = Mathf.Clamp(CamTransform.eulerAngles.x + x, 60, -60);
        //player.transform.eulerAngles += new Vector3(0, y, 0) * 1;
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        
        Vector3 velocity = Vector3.zero;
		Vector3 needPos = player.transform.position - player.transform.forward * 1.5f ;
        needPos.y = currentHeight -= x * Time.deltaTime;
		transform.position = Vector3.SmoothDamp(new Vector3 (transform.position.x, currentHeight-=x* Time.deltaTime, transform.position.z), needPos ,ref velocity,0.05f);
        
		transform.LookAt(player.transform);
		//transform.rotation = player.transform.rotation;
    }

}
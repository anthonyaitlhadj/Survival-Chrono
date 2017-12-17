using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public GameObject player;       //Public variable to store a reference to the player game object

    private Vector3 offset;         //Private variable to store the offset distance between the player and camera

    // Use this for initialization
    void Start () 
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
    }
    
    // LateUpdate is called after Update each frame
    void LateUpdate () 
    {
		//float y = Input.GetAxis("Mouse X");
        //float x = Input.GetAxis("Mouse Y");
        //Debug.Log(x + " " + y);
        //transform.eulerAngles += new Vector3(-x, y, 0) * 1;
        //float XClamp = Mathf.Clamp(CamTransform.eulerAngles.x + x, 60, -60);
        //player.transform.eulerAngles += new Vector3(0, y, 0) * 1;
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.

        Vector3 velocity = Vector3.zero;
		Vector3 forward = player.transform.forward;
		Vector3 needPos = player.transform.position - forward;
		needPos.y = transform.position.y;
		//needPos.z = transform.position.z;
		transform.position = Vector3.SmoothDamp(transform.position, needPos,ref velocity,0.05f);
		transform.LookAt (player.transform);
		//transform.rotation = player.transform.rotation;
    }

}
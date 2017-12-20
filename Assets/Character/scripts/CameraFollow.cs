using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject player;
    float currentHeight;

    void Start () 
    {
        currentHeight = player.transform.position.y;
    }
    
    void LateUpdate () 
    {
        float x = Input.GetAxis("Mouse Y");
        Vector3 velocity = Vector3.zero;
		Vector3 targetPos = player.transform.position - player.transform.forward * 1.5f ;
        Vector3 currentPos = transform.position;
        targetPos.y = currentPos.y = currentHeight -= x * Time.deltaTime;
		transform.position = Vector3.SmoothDamp(currentPos, targetPos ,ref velocity,0.05f);
		transform.LookAt(player.transform);
    }

}
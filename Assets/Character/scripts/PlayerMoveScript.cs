using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour {

    public float m_moveSpeed = 2;
    public float m_turnSpeed = 200;
    public float m_jumpForce = 4;
    public Rigidbody m_rigidBody;
    public Transform CamTransform;

    private float m_currentV = 0;
    private float m_currentH = 0;
    private readonly float m_interpolation = 10;

    private bool m_wasGrounded;
    private Vector3 m_currentDirection = Vector3.zero;
    private float m_jumpTimeStamp = 0;
    private float m_minJumpInterval = 0.25f;
    private bool m_isGrounded;
    private List<Collider> m_collisions = new List<Collider>();

	// Use this for initialization
	void Start () {
		
	}

    void Update(){
        MoveUpdate();
        //m_wasGrounded = m_isGrounded;
    }

    private void MoveUpdate()
    {
        float mouse_y = Input.GetAxis("Mouse X");
        float mouse_x = Input.GetAxis("Mouse Y");
         transform.eulerAngles += new Vector3(0, mouse_y, 0) * m_moveSpeed/2;
        CamTransform.eulerAngles += new Vector3(-mouse_x, 0, 0) * m_moveSpeed/2;

        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        bool walk = Input.GetKey(KeyCode.LeftShift);

        m_currentV = Mathf.Lerp(m_currentV, v, Time.deltaTime * m_interpolation);
        m_currentH = Mathf.Lerp(m_currentH, h, Time.deltaTime * m_interpolation);

        // devant derrière
        transform.position += transform.forward * m_currentV * m_moveSpeed * Time.deltaTime;
        // gauche droite
        transform.position += transform.right * m_currentH * m_moveSpeed * Time.deltaTime;
        //transform.Rotate(0, m_currentH * m_turnSpeed * Time.deltaTime, 0);

        JumpingAndLanding();
    }

    private void OnCollisionStay(Collision collision)
    {
        ContactPoint[] contactPoints = collision.contacts;
        bool validSurfaceNormal = false;
        for (int i = 0; i < contactPoints.Length; i++)
        {
            if (Vector3.Dot(contactPoints[i].normal, Vector3.up) > 0.5f)
            {
                validSurfaceNormal = true; break;
            }
        }

        if(validSurfaceNormal)
        {
            m_isGrounded = true;
            if (!m_collisions.Contains(collision.collider))
            {
                m_collisions.Add(collision.collider);
            }
        } else
        {
            if (m_collisions.Contains(collision.collider))
            {
                m_collisions.Remove(collision.collider);
            }
            if (m_collisions.Count == 0) { m_isGrounded = false; }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(m_collisions.Contains(collision.collider))
        {
            m_collisions.Remove(collision.collider);
        }
        if (m_collisions.Count == 0) { m_isGrounded = false; }
    }

    private void JumpingAndLanding()
    {
        bool jumpCooldownOver = (Time.time - m_jumpTimeStamp) >= m_minJumpInterval;

        if (jumpCooldownOver && m_isGrounded && Input.GetKey(KeyCode.Space))
        {
            m_jumpTimeStamp = Time.time;
            m_rigidBody.AddForce(Vector3.up * m_jumpForce, ForceMode.Impulse);
        }
    }
}

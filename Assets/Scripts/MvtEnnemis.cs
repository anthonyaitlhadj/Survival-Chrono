using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MvtEnnemis : LifeScript {

	private NavMeshAgent agent;
	public Transform LifeBar;
	private Transform Destination;
	private Animator animator;

	void Start(){
		agent = GetComponent<NavMeshAgent>();
		Destination = GameObject.FindGameObjectWithTag("Player").transform;
	}

	public override void Damage(int d)
	{
		base.Damage(d);
		GetComponent<Animator>().SetInteger("Pv", Pv);
		if (Pv <= 0) 
		{
			GetComponent<BoxCollider>().enabled = false;
			gameObject.tag = "Untagged";
			Destroy (this);
		}
	}

	void Update(){
		agent.destination = Destination.position;
	}
}

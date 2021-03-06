﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MvtEnnemis : LifeScript {

	private NavMeshAgent agent;
	private Transform Destination;
	private Animator animator;
	bool waitActive = false;
	private bool isAttack = false;
    public int scoreValue = 10;
    private ScoreScript ScoreManager;
    public int damage = 5;

	void Start(){
		agent = GetComponent<NavMeshAgent>();
        Destination = GameObject.FindGameObjectWithTag("Player").transform;
        ScoreManager = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreScript>();
	}

	public override void Damage(int d)
	{
		base.Damage(d);
		GetComponent<Animator>().SetFloat("Pv", Pv);
		if (Pv <= 0) 
		{
			GetComponent<BoxCollider>().enabled = false;
			gameObject.tag = "Untagged";
            ScoreManager.score += scoreValue;
			Destroy (this.gameObject, 2f);
		}
	}

	void Update(){
		agent.destination = Destination.position;
	}

	private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Corps")
        {
            if (other.gameObject.GetComponentInParent<LifeScript>())
            {
                if (!waitActive)
                {
                    /*if (ScoreManager.score>0)
                        damage = damage + ScoreManager.score/2;*/
                    other.gameObject.GetComponentInParent<LifeScript>().Damage(damage);
                    StartCoroutine(Wait());
                }
            }
        }
    }
	
	private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Corps")
        {
            isAttack = true;
            GetComponent<Animator>().SetBool("IsAttack", isAttack);
            agent.isStopped = true;
        } 
    }

	private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Corps")
        {
            isAttack = false;
            GetComponent<Animator>().SetBool("IsAttack", isAttack);
            agent.isStopped = false;
        }
    }

	IEnumerator Wait()
    {
        waitActive = true;
        yield return new WaitForSeconds(1.0f);
        waitActive = false;
    }
}

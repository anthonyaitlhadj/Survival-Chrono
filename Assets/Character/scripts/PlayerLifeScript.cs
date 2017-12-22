using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLifeScript : LifeScript
{
	public LifeBarScript LifeBar;
	
	public override void Damage(int d){
		base.Damage(d);
		LifeBar.Damage(d);
		if(Pv <= 0){
			SceneManager.LoadScene("Menu");
		}
	}

}

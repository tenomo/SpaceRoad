using UnityEngine;
using System.Collections;
using UI;
using Spaceships;
using System;

namespace Controlle.AI{
	public class EnemyAI : MonoBehaviour 
	{ 

		public SpaceShip EnemySpaseShip{ get; set;}
		private float visibleDis; 
		private Vector3 Position { get; set;}
		//private	IControllObserverFromDistributor ThisControllObserver;
	 



	// Use this for initialization
	void Start ()
	{ 
			this.visibleDis = 15;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//	if ()
	}


		private bool isVisibleenemy ()
		{
			if (Vector3.Distance (this.transform.position, EnemySpaseShip.transform.position) <= visibleDis)
				return true;
			else
				return false;
		} 
    }
}


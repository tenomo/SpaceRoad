//using System;
//using UnityEngine;

//namespace  Spaceships
//{
//	public class ControlObserver: IControllObserverFromDistributor 
//    {
//		public	delegate void MoveEventHandler(Vector2 dir);
//		public	delegate void TurneventHandler(Vector2 dir);
//		public  delegate void AtackHandler (SkillsEnum skill);

//		public event MoveEventHandler MoveEvent;
//		///public event TurneventHandler TurnEvent;
//		 public event AtackHandler AtackEvent;

//		public	void Move (Vector3 dir)
//		{ 
//			if (this.MoveEvent != null)
//				this.MoveEvent (dir);
//		} 
//		//public	void Turn (Vector2 dir)
//		//{
//		//	if (this.TurnEvent != null)
//		//		this.TurnEvent (dir);
//		//}
//		// no need?
//		public	void Atack (SkillsEnum skill)
//		{
//			if (this.AtackEvent != null)
//				AtackEvent (skill);
//		} 

//		public static ControlObserver  Create ()
//		{
//			return new ControlObserver ();
//		}

//        public void Turn(Vector2 dir)
//        {
//            throw new NotImplementedException();
//        }
//    }
//	public	interface IControllObserverFromDistributor
//	{
//		void Move (Vector3 dir);
//		//void Turn (Vector2 dir);
//		void Atack (SkillsEnum skill); 
//	} 	
 
//}

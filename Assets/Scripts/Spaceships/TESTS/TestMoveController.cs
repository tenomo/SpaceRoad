using UnityEngine;
using Spaceships;
 
public class TestMoveController : MonoBehaviour
	{ 
	public GameObject obj;
	ISpaceship spaceShip;

	public void Start ()
	{
		spaceShip = obj.GetComponent<SpaceShip> () as ISpaceship;

	//	spaceShip.MoveController.InitMoveController (1, 1);


	}

	void Update ()
	{
		//if (Input.GetKey (KeyCode.A))

		//spaceShip.controlObserver.Move (Vector3.left);
	}
}

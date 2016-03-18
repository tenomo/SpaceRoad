using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace  Spaceships.UI
{
    public class InputMoveAggregator : MonoBehaviour, IInputMoveAggregator
    {

        
        /// <summary>
        /// Link on spaceship controller;
        /// </summary>
        public IMoveController MoveController { get; set; }
     

        public void PassLinkToMoveController(IMoveController moveController)
        {
            this.MoveController = moveController;
        }


        // Update is called once per frame
        private void Update()
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                MoveController.Move(Vector2.left);
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                MoveController.Move(Vector2.right);
            }

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                MoveController.Move(Vector2.up);
            }
        }
    }
   
    public interface IInputMoveAggregator
    {
        /// <summary>
        /// Link on spaceship controller;
        /// </summary>
        IMoveController MoveController { get; set; }
        void PassLinkToMoveController(IMoveController moveController);
    }
}

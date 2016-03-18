using UnityEngine;
using System.Collections;
using System;
using Spaceships.Skills;

namespace Spaceships
{ 
    public class SpaceShip : MonoBehaviour, ISpaceship, IPlayer
    {
        public SkillManager SkillManager { get; set; }
        public IMoveController MoveController { get; set; }
        public Spaceships.Health health { get; set; } 
        public Energy energy { get; set; }
        public Vector3 Position { get { return this.transform.position; } set { } }

        // Use this for initialization
        void Awake()
        {
            // base state
            this.energy = Energy.Create(100);
            this.health = Health.Create(100);
            this.health.DeathEvent += Health_DeathEvent;
            this.health.ReceiveDemageEvent += Health_ReceiveDemageEvent; 
            if (SkillManager == null)
            {
                this.gameObject.AddComponent<SkillManager>();
                this.SkillManager = this.gameObject.GetComponent<SkillManager>();
            }

            if (MoveController == null)
            {
                this.gameObject.AddComponent<MoveController>();
                MoveController = this.gameObject.GetComponent<MoveController>();
            }
               
        }

 

        private void Health_ReceiveDemageEvent(float value)
        {
             //anim
        }

        void Health_DeathEvent()
        {
            //anim
        }       


      
        void Update()
        {
            this.health.RestorePerSecond();
            this.energy.RestorePerSecond();
        }

        public SkillManager GetSkillManager()
        {
            return this.SkillManager;
        }

        public IMoveController GetMoveController()
        {
            return this.MoveController;
        }
    }


    public interface IPlayer
    {
        Spaceships.Health health { get; set; } 
        UnityEngine.Vector3 Position { get; set; } 
        Energy energy { get; set; }
        string name { get; set; }
        string tag { get; set; }
        SkillManager  SkillManager{ get; set; }
        IMoveController MoveController { get; set; }
    }
    public interface ISpaceship
    {
        Spaceships.Health health { get; set; }
        
        UnityEngine.Vector3 Position { get; set; } 
        Energy energy { get; set; }
        string name { get; set; }
        string tag{ get; set; }
        SkillManager GetSkillManager();
        IMoveController GetMoveController();
    }
}
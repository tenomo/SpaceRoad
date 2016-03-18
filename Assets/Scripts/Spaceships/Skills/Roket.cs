using UnityEngine;
using Spaceships;
using System.Collections;
using System;

namespace Spaceships.Skills
{
    class HomingRoket : Bulet, ObjectPool.IElementObjectPool, IRoket
    {
        private Vector3 TargetPosition { get { return TargetSpaceShip.Position; } }
        public ISpaceship TargetSpaceShip { get; set; } 
               
        private Animator animator;
        


        public delegate void ExplosiontionHandler();
        public event ExplosiontionHandler Explosion;

        protected override void OnEneble()
        {
            InitTimer();
            timer.startTimer();
            this.myTransfrom = this.gameObject.transform;
            this.Explosion += RoketExplosionAnimation;
            this.animator = this.gameObject.GetComponent<Animator>();
        }      

        private void RoketExplosionAnimation()
        {
            string animation_name = "Explosion";

            try
            {
                this.animator.SetBool(animation_name, true);
            }
            catch (UnityEngine.UnityException uex)
            {
                Debug.Log("the object does not contain animation named " + animation_name + ", " + uex);
            }
        }

        private void Update()
        {
            MoveToTarget();
        }

        private void MoveToTarget()
        {
            this.transform.position = Vector3.Lerp(this.transform.position, this.TargetPosition, Time.deltaTime * Speed);
        }

        protected override void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<ISpaceship>() == TargetSpaceShip && other.tag != this.tag)
            {
                TargetSpaceShip.health.SetReceiveDemage(Demage);
            }

            PerformExplosion();
            timer.interval = 0.2f;
        }

        private void PerformExplosion()
        {
            if (Explosion != null)
                Explosion();
        } 

        public override void DefaultConfiguretions()
        {
            IRoket ir = this;
            if (Radius <= 0 || Demage <= 0)
            {
                ir.Demage = 15;
                ir.LiveTime = 5;
                ir.Speed = 4;
            }
        }

        public override void SetConfiguretions(IBulet config)
        {
            this.Demage = config.Demage;
            this.Speed = config.Speed;
            this.LiveTime = config.LiveTime;
        }
    }       
}

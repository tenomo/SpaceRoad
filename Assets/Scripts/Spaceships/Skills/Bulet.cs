using System;
using UnityEngine;
using UnityEditor;
using ViewProperty;

namespace Spaceships.Skills
{
    [Serializable]
    class Bulet : MonoBehaviour, IBulet, IAttackingSkill, ObjectPool.IElementObjectPool
    {       

        protected Transform myTransfrom;
        protected ITimer timer;

        private IMoveController moveController;

        [SerializeField]
        protected float demage;
        [SerializeField]
        protected float speed;
        [SerializeField]
        protected float tineLive;
        [SerializeField]
        protected float radius;

        public virtual float Demage { get { return this.demage; } set { this.demage = value; } }
        public virtual float Speed { get { return this.speed; } set { this.speed = value; } }
        public virtual float Radius { get { return radius = this.Speed * this.LiveTime; } }
        public virtual float LiveTime { get { return this.tineLive; } set { this.tineLive = value; } }

        public event ObjectPool.OnDisableEventHandler OnDisableEvent;

        protected virtual void InitTimer()
        {
            timer = Timer.AddTimer(this.gameObject);
            timer.interval = this.LiveTime;
            timer.Elapsed += TimerElapsedHandler;
        }

        protected virtual void TimerElapsedHandler()
        {
            Disable();
            this.myTransfrom.gameObject.SetActive(false);
        }

        protected virtual void OnEneble()
        {
            InitTimer();
            this.DefaultConfiguretions();
            timer.startTimer();
            myTransfrom = this.transform; 
            moveController = MoveController.AddMoveController(this.gameObject);
        }

        private void Update()
        {
            moveController.Move(myTransfrom.up, speed);
        }

       protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            ISpaceship spaceship = other.GetComponent<ISpaceship>();
            if (spaceship.tag != this.tag)
            {
                spaceship.health.SetReceiveDemage(Demage);
            }
        }

        public virtual void DefaultConfiguretions()
        {
            IBulet ib = this;
            if (Radius <= 0 || Demage <= 0)
            {
                ib.Demage = 15;
                ib.LiveTime = 5;
                ib.Speed = 4;
            }
        }

        protected void Disable()
        {
            if (OnDisableEvent != null)
                OnDisableEvent(this.gameObject);
        }

        public virtual void SetConfiguretions(IBulet config)
        {
            this.Demage = config.Demage;
            this.Speed = config.Speed;
            this.LiveTime = config.LiveTime;
        }
    }

    //[CustomEditor(typeof(Bulet))]
    //public class BuletEditor : Editor
    //{
    //    Bulet m_Instance;
    //    PropertyField[] m_fields;
    //    public void OnEnable()
    //    {
    //        m_Instance = target as Bulet;
    //        m_fields = ExposeProperties.GetProperties(m_Instance);
    //    }
    //    public override void OnInspectorGUI()
    //    {
    //        if (m_Instance == null)
    //        {
    //            return;
    //        }
    //        this.DrawDefaultInspector();
    //        ExposeProperties.Expose(m_fields);
    //    }
    //}
}

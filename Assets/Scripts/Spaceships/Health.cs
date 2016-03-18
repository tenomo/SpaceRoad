using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spaceships
{
    public class Health
    {
        private int maxHealth;
        private float Health_Points;
        public int MaxHealth
        {
            get { return maxHealth; }
            private set { maxHealth = value; }
        }
        public float HealthPoints
        {
            get { return Health_Points; }
            set
            {
                Health_Points = value;
                if (Health_Points < 0)
                    Health_Points = 0;
                if (Health_Points > maxHealth)
                    Health_Points = maxHealth;
                if (Health_Points == 0 && DeathEvent != null)
                    DeathEvent();
            }
        }
        public int RestoreFactor { get; private set; }
        public Health(int maxHealth)
        {
            this.maxHealth = maxHealth;
            Health_Points = this.maxHealth;
        }

        public delegate void DeathEventHandler();
        public event DeathEventHandler DeathEvent;
        public delegate void ReceivedDemageEventHandler(float value);
        public event ReceivedDemageEventHandler ReceiveDemageEvent;

        public static Health Create(int maxHealth)
        {
            return new Health(maxHealth);
        }

        public void RestorePerSecond()
        {
            if (this.HealthPoints < this.MaxHealth)
            {
                this.HealthPoints += RestoreFactor / UnityEngine.Time.deltaTime;
                if (Restore != null)
                    Restore(this.HealthPoints);
            }
        }

        public delegate void RestoreEventHandler(float energyPoints);
        public event RestoreEventHandler Restore;

        public void SetReceiveDemage(float value)
        {
            this.HealthPoints-= value;

            if (this.ReceiveDemageEvent != null)
            {
                this.ReceiveDemageEvent(this.HealthPoints);
            }
        }
    }
}

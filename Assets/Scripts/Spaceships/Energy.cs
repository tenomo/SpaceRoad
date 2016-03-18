using UnityEngine;
namespace Spaceships
{
    public class Energy
    {

        private int maxEnergy;
        private float Energy_Points;

        public float RestoreFactor { get; set; }

        public int MaxEnergy
        {
            get
            {
                return maxEnergy;
            }
            private set { maxEnergy = value; }
        }
     
        public float EnergyPoints
        {
            get
            {
                return Energy_Points;
            }
            set
            { 
                Energy_Points = value;
                if (Energy_Points < 0)
                    Energy_Points = 0;
                if (Energy_Points > maxEnergy)
                    Energy_Points = maxEnergy;              
            }
        }
        public Energy(int maxEnergy)
        {
            this.maxEnergy = maxEnergy;
            Energy_Points = this.maxEnergy;
        }    



        public void SetReceive(float value)
        {
            this.EnergyPoints -= value;

            if (this.ReceiveDemageEvent != null)
            { 
                this.ReceiveDemageEvent(EnergyPoints);
            }
        }

        public void RestorePerSecond()
        {
            if (this.EnergyPoints < this.MaxEnergy)
            {
                this.EnergyPoints += RestoreFactor / Time.deltaTime;
                if (Restore != null)
                    Restore(this.EnergyPoints);
            }
        }

        public delegate void RestoreEventHandler(float energyPoints);
        public event RestoreEventHandler Restore;

        public delegate void ReceivedDemageEventHandler(float energyPoints);
        public event ReceivedDemageEventHandler ReceiveDemageEvent;

        public static Energy Create(int maxEnergy)
        {
            return new Energy(maxEnergy);
        }

    }

}
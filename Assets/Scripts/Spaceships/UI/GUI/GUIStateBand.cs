using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
namespace Spaceships.UI.GUI
{
    class GUIStateBand : MonoBehaviour
    {

        public Spaceships.ISpaceship SpaceShip;
        private Scrollbar EnergyBar;
        private Scrollbar HealthgyBar;
        public GameObject EnergyBarObj;
        public GameObject HealthgyBarObj;


      private  void Start()
        {
            SpaceShip.health.ReceiveDemageEvent += Health_ReceiveDemageEvent;
            SpaceShip.energy.ReceiveDemageEvent += Energy_ReceiveDemageEvent;
            EnergyBar = EnergyBarObj.GetComponent<Scrollbar>();
            HealthgyBar = HealthgyBarObj.GetComponent<Scrollbar>();
        }

        private void Energy_ReceiveDemageEvent(float value)
        {
            this.ChangeScrollbarSize(EnergyBar, value);
        }

        private void Health_ReceiveDemageEvent(float value)
        {
            this.ChangeScrollbarSize(HealthgyBar, value);
        }

        void ChangeScrollbarSize(Scrollbar ConcretScrollbar, float value)
        {
            ConcretScrollbar.size = value / 100;
        }
    }
}

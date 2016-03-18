using Spaceships.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace Spaceships.TESTS.UI
{
    class TEST_GUIStateBand : MonoBehaviour, ISpaceship
    {
       public Health hp;
       public  Energy en;

        public Spaceships.UI.GUI.GUIStateBand testObj;
        public GameObject go;

        public Health health
        {
            get
            {
                return hp;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public Vector3 Position
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public Energy energy
        {
            get
            {
                return en;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

       
        void Awake  ()
        {
            hp = Health.Create(100);
            en = Energy.Create(100);
         testObj =   go.GetComponent<Spaceships.UI.GUI.GUIStateBand>();
            testObj.SpaceShip =(ISpaceship) this;
            Debug.Log(testObj);
        }

        

        public void Clic ()
        {
            this.en.SetReceive(10);

            Debug.Log("hp "+this.hp.HealthPoints + "   en " + this.en.EnergyPoints);
        }

        public void SetDemage(float value)
        {
            throw new NotImplementedException();
        }

        public SkillManager GetSkillManager()
        {
            throw new NotImplementedException();
        }

        public IMoveController GetMoveController()
        {
            throw new NotImplementedException();
        }
    }
}

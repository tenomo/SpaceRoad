using UnityEngine;
using System.Collections;

namespace Spaceships.Skills
{
    public class EnergyShield : MonoBehaviour
    {
        /// <summary>
        /// Gets or sets my space ship.
        /// </summary>
        /// <value>My space ship.</value>
        public ISpaceship MySpaceShip { get; set; }
        /// <summary>
        /// The energy stock in spaceship.
        /// </summary>
        public Energy energy { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Spaceships.EnergyShield"/> is enebed.
        /// </summary>
        /// <value><c>true</c> if is enebed; otherwise, <c>false</c>.</value>
        public bool isEnebed { get; set; }
        /// <summary>
        /// Gets or sets the power shield.
        /// </summary>
        /// <value>The power shield.</value>
        public float PowerShield { get; set; }
        /// <summary>
        /// Calcls the power shield in to procent.
        /// </summary>
        /// <returns>The power shield.</returns>
        /// <param name="value">Value.</param>
        private float CalclPowerShield(float value)
        {
            return PowerShield / 100;
        }

        /// <summary>
        /// Возвращает минимальное количестве энергии которое необходимо для работы щита.
        /// </summary>
        /// <returns></returns>
       private float MinEenegryForWorked()
        {
          return  energy.MaxEnergy * 0.10f;
        }

        /// <summary>
        /// Reflect the demage and returned the remainder of the damage after reflection.
        /// </summary>
        /// <param name="demage">Demage.</param>
        private float Reflect(float demage)
        {              
            float ResidualDamage = demage;
            if (isEnebed)
                if (energy.EnergyPoints >= MinEenegryForWorked())
                {
                    ResidualDamage = demage * CalclPowerShield(PowerShield);
                    energy.SetReceive(demage - ResidualDamage);
                }
            return ResidualDamage;
        }

        void Start()
        {
            MySpaceShip = this.gameObject.GetComponentInParent<SpaceShip>();
            this.energy = this.MySpaceShip.energy;
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (isEnebed)
            {
                IAttackingSkill atakingSkill = other.GetComponent<IAttackingSkill>();
                if (atakingSkill != null)
                {
                    this.MySpaceShip.health.SetReceiveDemage(Reflect(atakingSkill.Demage));
                }
            }
        }


    }
}
				 
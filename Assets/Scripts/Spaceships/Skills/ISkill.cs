 
namespace  Spaceships.Skills
{ 

    interface IAttackingSkill
    {         
        float Demage { get; set; }
    }

    internal interface IRoket : IBulet
    {
        ISpaceship TargetSpaceShip { get; set; }
    }
    internal interface IBulet
    {
        float Demage { get; set; }
        float Speed { get; set; }
        float Radius { get;  }
        float LiveTime { get; set; }
        void DefaultConfiguretions();
        void SetConfiguretions(IBulet config);

    }
   
}

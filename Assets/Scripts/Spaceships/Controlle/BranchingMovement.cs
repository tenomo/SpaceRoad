
using UnityEngine;

namespace  Spaceships.Controle
{
    public class BranchingMovement : IMovement
    {
        private float Deviation;
        private ITimer timerDeviation;

        public UnityEngine.Transform transform { get; private set; }
        public float InitervalDeviation { get; set; }
        public float Speed { get; set; }
        public UnityEngine.Vector2 DeviationRange { get; set; }
        public UnityEngine.Vector2 direction { get; set; }

        // Use this for initialization
      public  BranchingMovement (Transform transform, float moveSpeed, Vector2 direction)
        {
            this.DeviationRange = new UnityEngine.Vector2(-2, 2);   // default value
            this.transform = transform;
            this.Speed = moveSpeed;
            this.InitTiner(); 
        }

        public BranchingMovement(Transform transform, float speed, Vector2 DeviationRange,Vector2 direction)
        {
            this.transform = transform;
            this.Speed = speed;
            this.InitTiner();
        } 

        private void InitTiner ()
        {
            this.timerDeviation = Timer.AddTimer(transform.gameObject);
            this.InitervalDeviation = 0.4f; // default value
            this.timerDeviation.interval = this.InitervalDeviation;
            this.timerDeviation.Elapsed += TimerDeviation_Elapsed;
            this.timerDeviation.startTimer();
        }


        private void TimerDeviation_Elapsed()
        {
            Deviation = UnityEngine.Random.Range(this.DeviationRange.x, this.DeviationRange.y);
            timerDeviation.startTimer();
        }

        public void Move()
        {
            UnityEngine.Vector2 moveDir = UnityEngine.Vector2.zero;

            if (direction.x != 0)
            {
                moveDir = new UnityEngine.Vector2(direction.x, Deviation);
            }
            else if (direction.y != 0)
            {
                moveDir = new UnityEngine.Vector2(Deviation, direction.y);
            }
            this.transform.Translate(moveDir * UnityEngine.Time.deltaTime * Speed);
        }
        public void Move(UnityEngine.Vector2 directiom)
        {
            this.direction = direction;
            this.Move();
        }
    }   
    
    
    class MovementTotarget : IMovement
    {
       public float Speed { get; set; } 
       public Vector2 direction { get;  set; }
      public  Transform transform { get; set; }
        public Transform target { get; set; }

        private void Move()
        {
            this.transform.position = Vector3.Lerp(this.transform.position, target.position, Time.deltaTime * Speed);
        }
    }

    class ForvardMovement : IMovement
    {
        float Speed { get; set; }
        Vector2 direction { get; set; }
        Transform transform { get; set; }
    }


}

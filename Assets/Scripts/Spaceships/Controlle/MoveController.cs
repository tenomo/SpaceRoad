 
namespace  Spaceships
{
	public class MoveController : UnityEngine.MonoBehaviour, IMoveController
    {

		private UnityEngine.Transform cacheTransfrom;

        public float MoveSpeed { get; set; }
        public float TurnSpeed { get; set; }

        public static MoveController AddMoveController(UnityEngine.GameObject gameObject)
        {
            MoveController moveCont_r = gameObject.AddComponent<MoveController>(); 
            moveCont_r.cacheTransfrom = gameObject.transform;
            return moveCont_r;
        }

        public void Move(UnityEngine.Vector3 direction)
        {
            direction.Normalize();
            StartCoroutine(MoveCoroutine(direction));

        }
        public void Move(UnityEngine.Vector3 direction, float speed)
        {             
            this.MoveSpeed = speed;
            this.Move(direction);
        }       

        public void Turn(UnityEngine.Vector3 diection )
        {
            diection.Normalize(); 
            StartCoroutine(TurnCoroutine(diection));
        }

        public void Turn(UnityEngine.Vector3 diection, float speed)
        { 
            this.TurnSpeed = speed;
            this.Turn(diection);
        }

         
        private System.Collections.IEnumerator MoveCoroutine (UnityEngine.Vector3 direction)
		{
			this.cacheTransfrom.Translate (direction* UnityEngine.Time.deltaTime*this.MoveSpeed);
			yield return null;
		}

        private System.Collections.IEnumerator TurnCoroutine(UnityEngine.Vector3 direction)
        {            
            this.cacheTransfrom.Rotate(direction * UnityEngine.Time.deltaTime * this.TurnSpeed);
            yield return null;
        }
    }

    public interface IMoveController
    {
        void Move(UnityEngine.Vector3 direction, float speed);
        void Turn(UnityEngine.Vector3 direction, float speed);

        void Move(UnityEngine.Vector3 direction);
        void Turn(UnityEngine.Vector3 direction);
    }
}

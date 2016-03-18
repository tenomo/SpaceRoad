using UnityEngine;

namespace Spaceships.Controle
{
    public interface IMovement
    {
        float Speed { get; set; }
        Vector2 direction { get; set; } 
        Transform transform { get; set; }
    }
} 
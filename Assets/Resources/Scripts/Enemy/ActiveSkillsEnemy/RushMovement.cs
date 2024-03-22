
using UnityEngine;
using UnityEngine.Serialization;

namespace Resources.Scripts.Enemy.ActiveSkillsEnemy
{
    public class RushMovement : MonoBehaviour
    {
        private Movement movement;
        private Transform target;
        private Rotation rotation;
        
        public float rushAmplifier;
        public float distanceYToRush;
        public float rotationImprovement;
        private bool amplified = false;
        
        void Start()
        {
            movement = GetComponent<global::Enemy>().Movement;
            rotation = GetComponent<global::Enemy>().Rotation;
            target = GameObject.Find("Hero").transform;
        }

        void Update()
        {
            if (WithingBoundaries() && !amplified)
            {
                movement.MvAmplifier += rushAmplifier;
                rotation.RotationSpeed += rotationImprovement;
                amplified = true;
            }
            else if (!WithingBoundaries() && amplified)
            {
                movement.MvAmplifier -= rushAmplifier;
                rotation.RotationSpeed -= rotationImprovement;
                amplified = false;
            }
        }

        bool WithingBoundaries()
        {
            Vector2 position = transform.position;
            Vector2 targetPos = target.position;
            return (Mathf.Abs(position.y - targetPos.y) < distanceYToRush);
        }
    }

}
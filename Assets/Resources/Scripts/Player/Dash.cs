using UnityEngine;
using UnityEngine.Windows;

namespace Resources.Scripts.Player
{
    public class Dash
    {
        private MovementHero _movement;
        private float _cooldownMax;
        private float _cooldown = 0f;
        private float _duration = -1f;
        public Dash(MovementHero movement, float cooldownMax)
        {
            _movement = movement;
            _cooldownMax = cooldownMax;
        }

        public void UpdateCooldown()
        {
            _cooldown -= Time.deltaTime;
            _duration -= Time.deltaTime;

            if (_duration <= -0.2f)
            {
                _movement.MvModifier = 1f;
            }
            else if (_duration <= 0f)
            {
                _movement.MvModifier = 0.6f;
            }


        }
        public void Execute()
        {
            if (_cooldown > 0f) return;
            _movement.MvModifier = 2.5f;
            _duration = 0.25f;
            _cooldown = _cooldownMax;
        }
    }
}
using UnityEngine;

namespace Resources.Scenes.Scripts.States
{
    public class BurnState : State
    {
        private Enemy enemy;
        private float _timeLeft;
        private float timeLeft = 5f;
        private float tickTime = 0.5f;
        private float _tickTime;
        private int stacks;
        private Animator animator;

        public BurnState(Enemy enemy, Animator animator)
        {
            this.enemy = enemy;
            this._tickTime = tickTime;
            _timeLeft = timeLeft;
            this.stacks = 1;
            this.animator = animator;
            this.animator.SetBool("isBurning", true);
        }

        void ExecuteState()
        {
            enemy.LoseHealth(2f * stacks);
        }

        public void UpdateState()
        {
            _tickTime -= Time.deltaTime;
            _timeLeft -= Time.deltaTime;
            if (_timeLeft <= 0f)
            {
                this.animator.SetBool("isBurning", false);
                enemy.SetState(new UnaffectedState(enemy), 0);
            }

            if ((_tickTime > 0f)) return;
            ExecuteState();
            _tickTime = tickTime;

        }

        public void RefreshState()
        {
            _timeLeft = timeLeft;
            this.stacks += 1;
        }
    }
}
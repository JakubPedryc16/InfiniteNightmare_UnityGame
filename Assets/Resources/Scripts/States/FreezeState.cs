using UnityEngine;

namespace Resources.Scenes.Scripts.States
{
    public class FreezeState : State
    {
        private Enemy enemy;
        private float timeLeft = 10f;
        private float _timeLeft;
        private float tickTime = 2;
        private float _tickTime;
        private int stacks;
        private Animator animator;
     
        
        public FreezeState(Enemy enemy, Animator animator)
        {
            this.enemy = enemy;
            this.stacks = 0;
            this.animator = animator;
            this.animator.SetBool("isFreezing", true);
            RefreshState();

        }
        void ExecuteState()
        {
            enemy.LoseHealth(0.25f * stacks);
        }

        public void UpdateState()
        {
            _tickTime -= Time.deltaTime;
            _timeLeft -= Time.deltaTime;
            if (_timeLeft <= 0f)
            {
                enemy.Movement.MvModifier = 1f;
                this.animator.SetBool("isFreezing", false);
                enemy.SetState(new UnaffectedState(enemy), 1);
            }   

            if (_tickTime <= 0f)
            {
                ExecuteState();
                _tickTime = tickTime;
            }

        }

        public void RefreshState()
        {
            _timeLeft = timeLeft;
            stacks = Mathf.Clamp( stacks + 1, 0, 10);
            enemy.Movement.MvModifier = 1f - 0.05f * stacks;
        }
    }
}
using UnityEngine;

namespace Resources.Scripts.Enemy.ActiveSkillsEnemy
{
    public class Summonner : MonoBehaviour
    {
        public float cooldown = 3f;
        public int type = 901;
        
        float _cooldown;
        private GameObject enemy;

        void Start () {
            _cooldown = 1f;
            enemy = UnityEngine.Resources.Load<GameObject>("Prefabs/Enemies/Enemy" + type);
        }
        
        void Update () {
            _cooldown -= Time.deltaTime;

            if(_cooldown <= 0f)
            {
                enemy.transform.position = new Vector3(transform.position.x - 0.8f, transform.position.y, 0f);
                Instantiate(enemy);
                _cooldown = Random.Range(cooldown * 0.7f, cooldown * 1.3f);
            }
		
        }
    }
}
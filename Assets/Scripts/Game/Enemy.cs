using UnityEngine;
using QFramework;
using System;
using static UnityEngine.EventSystems.EventTrigger;

namespace ProjectSurvivor
{
    public partial class Enemy : ViewController
    {
        public float HP = 3;
        public float MovementSpeed = 2.0f;

        private void Start()
        {
            EnemyGenerator.EnemyCount.Value++;
        }

        private void OnDestroy()
        {
            EnemyGenerator.EnemyCount.Value--;
        }

        private void Update()
        {

            if (Player.Default)
            {
                var direction = (Player.Default.transform.position - transform.position).normalized;

                transform.Translate(direction * Time.deltaTime * MovementSpeed);

            }

            if(HP <= 0)
            {
                // TODO: 经验值掉落 
                Global.GeneratePowerUp(gameObject);

                //Debug.Log($"[Death] HP <= 0, 当前经验值: {Global.Exp.Value}");
                this.DestroyGameObjGracefully();

                
            }

        }

        //private bool mIgnoreHurt = false;
        //无敌帧，暂时不加，我这里好像没有bug
        internal void Hurt(float value)
        {
            //if (mIgnoreHurt) return;
            HP -= Global.SimpleAbilityDamage.Value;
            if (HP > 0)
            {

                this.Sprite.color = Color.red;

                ActionKit.Delay(0.3f, () =>
                {
                    this.Sprite.color = Color.white;
                }
                ).Start(this);
            }
        }
    }
}

using UnityEngine;
using QFramework;

namespace ProjectSurvivor
{
    public partial class SimpleAbility : ViewController
    {
        private float mCurrentGenerateSeconds = 0;

        void Start()
        {
            // Code Here
        }
        private void Update()
        {
            mCurrentGenerateSeconds += Time.deltaTime;

            if (mCurrentGenerateSeconds >= 1.5f)
            {
                mCurrentGenerateSeconds = 0;
                var enemies = FindObjectsByType<Enemy>(FindObjectsInactive.Exclude, FindObjectsSortMode.None);
                foreach (var enemy in enemies)
                {
                    var distance = (Player.Default.transform.position - enemy.transform.position).magnitude;

                    if (distance <= 5)
                    {
                        enemy.HP -= Global.SimpleAbilityDamage.Value;
                        if (enemy.HP > 0)
                        {
                            enemy.Sprite.color = Color.red;
                            var enemyRefCache = enemy;

                            ActionKit.Delay(0.3f, () =>
                            {
                                //enemyRefCache.HP--;
                                enemyRefCache.Sprite.color = Color.white;
                            }
                            ).StartGlobal();
                        }

                    }
                }

            }
        }
    }
}

using UnityEngine;
using QFramework;

namespace ProjectSurvivor
{
    public partial class EnemyGenerator : ViewController
    {
        private float mCurrentSeconds = 0;

        private void Update()
        {
            mCurrentSeconds += Time.deltaTime;

            if (mCurrentSeconds >= 1)
            {
                mCurrentSeconds = 0;

                var player = Player.Default;
                var randomAngle = Random.Range(0, 360f);
                var randomRadius = randomAngle * Mathf.Deg2Rad;
                var direction = new Vector3(Mathf.Cos(randomRadius), Mathf.Sin(randomRadius));
                if (player)
                {
                    var generatePos = player.transform.position + direction * 10;

                    Enemy.Instantiate()
                        .Position(generatePos)
                        .Show();
                }

            }
        }
    }
}

using UnityEngine;
using QFramework;
using System.Collections.Generic;
using System;

namespace ProjectSurvivor
{
    [Serializable]
    public class EnemyWave
    {
        public float GenerateDuraton = 1;
        public GameObject EnemyPrefab;
        public int Seconds = 10;
    }
    public partial class EnemyGenerator : ViewController
    {
        private float mCurrentGenerateSeconds = 0;//当前敌人生成时间
        private float mCurrentWaveSeconds = 0;//波次持续时间

        [SerializeField]
        public List<EnemyWave> EnemyWaves = new List<EnemyWave>();


        public Queue<EnemyWave> mEnemyWavesQueue = new Queue<EnemyWave>();


        public int WaveCount = 0;

        public bool LastWave => WaveCount == EnemyWaves.Count;

        private void Start()
        {
            foreach (var enemyWave in EnemyWaves)
            {
                mEnemyWavesQueue.Enqueue(enemyWave);
            }

        }

        private EnemyWave mCurrentWave = null;



        private void Update()
        {
            if (mCurrentWave == null)
            {
                if (mEnemyWavesQueue.Count > 0)
                {
                    WaveCount++;
                    mCurrentWave = mEnemyWavesQueue.Dequeue();
                    mCurrentGenerateSeconds = 0;
                    mCurrentWaveSeconds = 0;
                    Debug.Log($" 当前波次刷新间隔: {mCurrentWave.GenerateDuraton}");
                }
            }

            if (mCurrentWave != null)
            {
                mCurrentGenerateSeconds += Time.deltaTime;
                mCurrentWaveSeconds += Time.deltaTime;


                if (mCurrentGenerateSeconds >= mCurrentWave.GenerateDuraton)
                {
                    mCurrentGenerateSeconds = 0;

                    var player = Player.Default;

                    if (player)
                    {
                        var randomAngle = UnityEngine.Random.Range(0, 360f);
                        var randomRadius = randomAngle * Mathf.Deg2Rad;
                        var direction = new Vector3(Mathf.Cos(randomRadius), Mathf.Sin(randomRadius));
                        var generatePos = player.transform.position + direction * 10;

                        mCurrentWave.EnemyPrefab.Instantiate()
                            .Position(generatePos)
                            .Show();
                    }

                }

                if (mCurrentWaveSeconds >= mCurrentWave.Seconds)
                {
                    mCurrentWave = null;
                }

            }

            //mCurrentGenerateSeconds += Time.deltaTime;
        }
    }
}

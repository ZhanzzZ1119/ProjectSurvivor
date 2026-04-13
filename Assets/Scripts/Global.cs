using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectSurvivor
{

    public class Global
    {
        /// <summary>
        /// 经验值
        /// </summary>
        public static BindableProperty<int> Exp = new BindableProperty<int>(0);

        public static BindableProperty<int> Level = new BindableProperty<int>(1);

        public static BindableProperty<float> CurrentSeconds = new BindableProperty<float>(0);

        public static BindableProperty<float> SimpleAbilityDamage = new BindableProperty<float>(1);

        public static BindableProperty<float> SimpleAbilityDuration = new BindableProperty<float>(1.5f);
        
        public static void RestartData()
        {
            Exp.Value = 0;
            Level.Value = 1;
            CurrentSeconds.Value = 0;
            SimpleAbilityDamage.Value = 1;
            SimpleAbilityDuration.Value = 1.5f;
            EnemyGenerator.EnemyCount.Value = 0;
        }


        public static int ExpToNextLevel()
        {
            return ExpToNextLevel(Level.Value);
        }
        public static int ExpToNextLevel(int lv)
        {
            return lv * 3 + 2;
        }

        //public static void GeneratePowerUp(GameObject gameObject)
        //{
        //    //90%掉落经验值

        //    var random = Random.Range(0, 100.0f);

        //    if(random <= 90)
        //    {
        //        //掉落经验值

        //        PowerUpManager.Default.Exp.Instantiate()
        //            .Position(gameObject.Position())
        //            .Show();

        //    }
        //}
        public static void GeneratePowerUp(GameObject gameObject)
        {
            // ----- 简洁调试（定位空引用）-----
            if (PowerUpManager.Default == null) { Debug.LogError("PowerUpManager.Default is null"); return; }
            if (PowerUpManager.Default.Exp == null) { Debug.LogError("PowerUpManager.Default.Exp is null"); return; }
            if (gameObject == null) { Debug.LogError("GeneratePowerUp: gameObject is null"); return; }
            // --------------------------------

            //90%掉落经验值
            var random = Random.Range(0, 100.0f);
            if (random <= 90)
            {
                //掉落经验值
                PowerUpManager.Default.Exp.Instantiate()
                    .Position(gameObject.Position())
                    .Show();
            }
        }
    }
}
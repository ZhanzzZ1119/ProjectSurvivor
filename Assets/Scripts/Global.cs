using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectSurvivor
{

    public class Global
    {
        /// <summary>
        /// æ≠—È÷µ
        /// </summary>
        public static BindableProperty<int> Exp = new BindableProperty<int>(0);

        public static BindableProperty<int> Level = new BindableProperty<int>(1);

        public static BindableProperty<float> CurrentSeconds = new BindableProperty<float>(0);

        public static BindableProperty<float> SimpleAbilityDamage = new BindableProperty<float>(1);

        public static void RestartData()
        {
            Exp.Value = 0;
            Level.Value = 1;
            CurrentSeconds.Value = 0;
            SimpleAbilityDamage.Value = 1;
            EnemyGenerator.EnemyCount.Value = 0;
        }

    }
}
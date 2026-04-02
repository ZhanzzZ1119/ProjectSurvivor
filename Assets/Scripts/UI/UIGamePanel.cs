using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace ProjectSurvivor
{
    public class UIGamePanelData : UIPanelData
    {
    }
    public partial class UIGamePanel : UIPanel
    {
        protected override void OnInit(IUIData uiData = null)
        {
            mData = uiData as UIGamePanelData ?? new UIGamePanelData();
            // please add init code here

            EnemyGenerator.EnemyCount.RegisterWithInitValue(enemyCount =>
            {
                EnemyCountText.text = "敌人数量：" + enemyCount;
            }
               ).UnRegisterWhenGameObjectDestroyed(gameObject);

            Global.CurrentSeconds.RegisterWithInitValue(CurrentSeconds =>
            {
                if (Time.frameCount % 30 == 0)
                {
                    var currentSecondsInt = Mathf.FloorToInt(CurrentSeconds);
                    var seconds = currentSecondsInt % 60;
                    var minutes = currentSecondsInt / 60;
                    TimeText.text = "时间：" + $"{minutes:00}:{seconds:00}";
                }


            }
               ).UnRegisterWhenGameObjectDestroyed(gameObject);

            Global.Exp.RegisterWithInitValue(exp =>
            {

                ExpText.text = "经验值：(" + exp +  "/"  +  Global.ExpToNextLevel() + ")";
                
            }
               ).UnRegisterWhenGameObjectDestroyed(gameObject);

            Global.Level.RegisterWithInitValue(lv =>
            {
                LevelText.text = "等级：" + lv;
            }
            ).UnRegisterWhenGameObjectDestroyed(gameObject);

            Global.Level.Register(lv =>
            {
                Time.timeScale = 0;
                UpgradeRoot.Show();
            }
            ).UnRegisterWhenGameObjectDestroyed(gameObject);


            Global.Exp.RegisterWithInitValue(exp =>
            {
                if (exp >= Global.ExpToNextLevel())
                {

                    Global.Level.Value++;
                    Global.Exp.Value -= Global.ExpToNextLevel(Global.Level.Value - 1);
                    //前面lv++了，要用前一个等级，这里重载了计算函数
                    //如果把++放在后面，Exp更新的时候所需经验值会滞后，我暂时不知道怎么漂亮的解决
                }
            }
            ).UnRegisterWhenGameObjectDestroyed(gameObject);

            //////////////////////////
            //技能选项部分
            //////////////////////////
            UpgradeRoot.Hide();

            BtnUpgrade.onClick.AddListener(() =>//攻击升级
            {
                Time.timeScale = 1.0f;
                Global.SimpleAbilityDamage.Value *= 1.5f;
                UpgradeRoot.Hide();
            }
            );
            BtnSimpleDurationUpgrade.onClick.AddListener(() =>//攻击间隔升级
            {
                Time.timeScale = 1.0f;
                Global.SimpleAbilityDuration.Value *= 0.8f;
                UpgradeRoot.Hide();
            }
            );

            var enemyGenerator = FindObjectOfType<EnemyGenerator>();

            ActionKit.OnUpdate.Register(() =>
            {
                Global.CurrentSeconds.Value += Time.deltaTime;

            if (enemyGenerator.LastWave
                 && enemyGenerator.CurrentWave == null
                     && EnemyGenerator.EnemyCount.Value == 0)
                {
                    UIKit.OpenPanel<UIGamePassPanel>();
                }
            }
            ).UnRegisterWhenGameObjectDestroyed(gameObject);

        }

        protected override void OnOpen(IUIData uiData = null)
        {
        }

        protected override void OnShow()
        {
        }

        protected override void OnHide()
        {
        }

        protected override void OnClose()
        {
        }
    }
}

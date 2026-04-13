using UnityEngine;
using QFramework;

namespace ProjectSurvivor
{
	public partial class PowerUpManager : ViewController
	{

		public static PowerUpManager Default;

        private void Awake()
        {
            Debug.Log($"[PowerUpManager] Awake at frame {Time.frameCount}");
            Default = this;
        }

        private void OnDestroy()
        {
            Default = null;
        }
    }
}

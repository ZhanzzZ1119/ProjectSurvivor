using UnityEngine;
using QFramework;

namespace ProjectSurvivor
{
	public partial class Hitbox : ViewController
	{

		public GameObject Owner;

		void Start()
		{
			if (Owner)
			{
				Owner = transform.parent.gameObject;
			}
		}
	}
}

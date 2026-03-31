using UnityEngine;
using QFramework;
using UnityEditor;
using System;

namespace ProjectSurvivor
{
	public partial class Player : ViewController
	{
		public float MovementSpeed = 5.0f;

        public static Player Default;

        private void Awake()
        {
            Default = this;
        }

        private void OnDestroy()
        {
            Default = null;
        }

        void Start()
		{
			// Code Here
			("Hello QFramework").LogInfo();
			Hurtbox.OnTriggerEnter2DEvent(collider2D =>
			{
				this.DestroyGameObjGracefully();

                UIKit.OpenPanel<UIGameOverPanel>();
			}
			).UnRegisterWhenGameObjectDestroyed(gameObject);
		}


        private void Update()
        {
			var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");

			var direction = new Vector2(horizontal, vertical).normalized;
			SelfRigidbody2D.velocity = direction * MovementSpeed;
        }
    }
}

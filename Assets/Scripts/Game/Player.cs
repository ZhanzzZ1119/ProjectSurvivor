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
			
			Hurtbox.OnTriggerEnter2DEvent(collider2D =>
			{
                var hitbox = collider2D.GetComponent<Hitbox>();
                if(hitbox)
                {
                    if (hitbox.Owner.CompareTag("Enemy"))
                    {
                        this.DestroyGameObjGracefully();

                        UIKit.OpenPanel<UIGameOverPanel>();
                    }
                }
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

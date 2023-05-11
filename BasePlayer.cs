using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MyGame.Entities;

namespace MyGame.Player{

    public class BasePlayer : Base
    {

        private float lastAttackTime;
        private float delayBetweenAttack = 2.0f;

        public BasePlayer() : base(){
            position = new Vector3(100, 20, 0);
            health = 100;
        }

        // Start is called before the first frame update
        void Start()
        {
            transform.position = this.position;

            transform.localScale = new Vector3(10, 10, 10);

            lastAttackTime = Time.time;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyUp(KeyCode.E) && canAttack())
            {
                instantiateBot(base.enemy);
                lastAttackTime = Time.time;
            }
        }

        bool canAttack()
        {
            if (Time.time > lastAttackTime + delayBetweenAttack || lastAttackTime == 0.0f)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Create a new bot that will attack a Base 
        /// </summary>
        /// <param name="enemy">Enemy that bot have to attack</param>
        private void instantiateBot(Base enemy)
        {
            GameObject capsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);

            Bot bot = capsule.AddComponent<Bot>();
            bot.tag = "Bot";
            Rigidbody rb = capsule.AddComponent<Rigidbody>();

            bot.destination = base.enemy.transform;
            bot.transform.position = new Vector3(transform.position.x, bot.Size, transform.position.z);
        }
    }
}

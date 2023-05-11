using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MyGame.Entities;

namespace MyGame.Player{

    public class BasePlayer : Base
    {

        public BasePlayer() : base(){
            position = new Vector3(100, 20, 0);
            hp = 100;
        }

        // Start is called before the first frame update
        void Start()
        {
            transform.position = this.position;

            transform.localScale = new Vector3(10, 10, 10);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                instantiateBot(base.enemy);
            }
        }

        /// <summary>
        /// Create a new bot that will attack a Base 
        /// </summary>
        /// <param name="enemy">Enemy that bot have to attack</param>
        private void instantiateBot(Base enemy)
        {
            GameObject capsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);

            Rigidbody rb = capsule.AddComponent<Rigidbody>();
            Bot bot = capsule.AddComponent<Bot>();

            bot.destination = base.enemy.transform;
        }
    }
}

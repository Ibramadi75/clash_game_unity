using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MyGame.World;

namespace MyGame{
    public class Base : MonoBehaviour
    {
        protected Vector3 position;
        public Vector3 Position { get; set;}
        protected int health;

        public Base enemy;
        public Ground terrain;

        public int Health { get; set; }

        protected float safetyRadius = 80f;

        public Base(){
            position = new Vector3(0, 20, 0);
            health = 100;
        }

        // Start is called before the first frame update
        void Start()
        {
            // Base position
            transform.position = this.position;

            // Base dimensions
            transform.localScale = new Vector3(10, 10, 10);
        }

        // Update is called once per frame
        void Update()
        {
        }

        /// <summary>
        /// Allow to change position of a Base on the x axis.
        /// </summary>
        /// <param name="x">x value to set</param>
        public void positionX(float x){
            this.position = new Vector3(x, 20, 0);
        }
    }
}
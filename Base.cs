using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MyGame.World;

namespace MyGame{
    public class Base : MonoBehaviour
    {
        protected Vector3 position;
        public Vector3 Position { get; set;}
        protected int hp;

        public Base enemy;
        public Ground terrain;

        public int Hp { get; set; }

        public Base(){
            position = new Vector3(0, 20, 0);
            hp = 100;
        }

        // Start is called before the first frame update
        void Start()
        {
            // Définir la position du cube
            transform.position = this.position;

            // Définir la taille du cube
            transform.localScale = new Vector3(10, 10, 10);
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void positionX(float x){
            this.position = new Vector3(x, 20, 0);
        }
    }
}
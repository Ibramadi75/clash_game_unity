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
            // Définir la position du cube
            transform.position = this.position;
            // Définir la taille du cube
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

        private void instantiateBot(Base enemy)
        {
            // Créer une capsule
            GameObject capsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);

            // Ajouter un composant personnalisé à l'objet capsule
            Rigidbody rb = capsule.AddComponent<Rigidbody>();
            Bot bot = capsule.AddComponent<Bot>();

            bot.destination.position = enemy.transform.position;
        }
    }
}

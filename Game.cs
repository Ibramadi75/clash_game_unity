using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MyGame;
using MyGame.World;
using MyGame.Player;

namespace MyGame{
    class Game : MonoBehaviour{
        private Ground terrain = null;
        private BasePlayer player;
        private Base enemy;

        void Start(){
            if (terrain == null)
            {
                // Créer un cube
                GameObject terrainObject = GameObject.CreatePrimitive(PrimitiveType.Plane);
                terrainObject.transform.localScale = new Vector3(20f, 2f, 6f);

                // Ajouter un composant personnalisé à l'objet cube
                terrain = terrainObject.AddComponent<Ground>();

                terrain = gameObject.AddComponent<Ground>();

            }

            if(player == null)
            {
                // Créer un cube
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

                player = cube.AddComponent<BasePlayer>();

                player.terrain = terrain;
                // player.positionX(terrain.getMinX());
                player.positionX(-100);
            }

            if(enemy == null)
            {
                // Create cube
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

                Base enemy = cube.AddComponent<Base>();
                enemy.terrain = terrain;
                enemy.enemy = player;
                // enemy.positionX(terrain.getMaxX());
                enemy.positionX(100);

                if (player != null){
                    player.enemy = enemy;
                }
            }
        }

        // Update is called once per frame
        void Update()
        {
        }
    }
}
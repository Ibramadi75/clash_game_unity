using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MyGame;
using MyGame.Player;

namespace MyGame.World{
    public class Ground : MonoBehaviour
    {
        private float maxX;
        private float minX;
        private float maxZ;
        private float minZ;

        public float MaxX { get; set; }
        public float MinX { get; set; }
        public float MaxZ { get; set; }
        public float MinZ { get; set; }

        private BasePlayer player = null;
        private Base enemy = null;

        private void Awake()
        {
        }

        // Start is called before the first frame update
        void Start()
        {
            // Récupérer le composant Renderer de l'objet
            Renderer renderer = GetComponent<Renderer>();

            // Récupérer les dimensions de l'objet à partir de la propriété bounds
            float objectWidth = renderer.bounds.size.x;
            float objectHeight = renderer.bounds.size.y;
            float objectDepth = renderer.bounds.size.z;
            float positionX = transform.position.x;

            // Calculer les valeurs maximales et minimales pour x et z
            maxX = objectWidth / 2f;
            minX = -maxX;
            maxZ = objectDepth / 2f;
            minZ = -maxZ;

            if(player == null){
                // Créer un cube
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

                // Ajouter un composant personnalisé à l'objet cube
                player = cube.AddComponent<BasePlayer>();

                player.terrain = this;
                player.positionX(100);
            }

            if(enemy == null){
                // Créer un cube
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

                // Ajouter un composant personnalisé à l'objet cube
                Base enemy = cube.AddComponent<Base>();

                enemy.terrain = this;
                enemy.enemy = player;
                enemy.positionX(minX);

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

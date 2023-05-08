using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame.Entities
{
    public class Bot : MonoBehaviour
    {
        public Transform destination; // La destination que le bot doit atteindre
        public float speed; // Vitesse de déplacement du bot

        
        private GameObject basePlayer;
        private GameObject baseEnemy;

        private void Awake()
        {
            GameObject basePlayer = GameObject.Find("basePlayer");
            GameObject baseEnemy = GameObject.Find("baseEnemy");
        }

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            // Calculer la direction vers la destination
            Vector3 direction = destination.position - transform.position;

            // Déplacer le bot vers la destination à la vitesse spécifiée
            transform.position += direction.normalized * speed * Time.deltaTime;

            // Faire en sorte que l'objet regarde vers sa direction de déplacement
            transform.LookAt(transform.position + direction.normalized);
        }

        void OnDrawGizmosSelected()
        {
            // Dessiner une ligne reliant le bot à la destination
            if (destination != null)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawLine(transform.position, destination.position);
            }
        }

    }
}

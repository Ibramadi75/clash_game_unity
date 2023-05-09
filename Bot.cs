using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame.Entities
{
    public class Bot : MonoBehaviour
    {
        public Transform destination; // La destination que le bot doit atteindre
        public float speed = 5f; // Vitesse de déplacement du bot

        
        private GameObject basePlayer;
        private GameObject baseEnemy;

        private void Awake()
        {
        }

        // Start is called before the first frame update
        void Start()
        {
            // Définir la taille du cube
            transform.localScale = new Vector3(5, 5, 5);
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 direction = destination.position - transform.position;
            if (destination.position.x > transform.position.x)
            {
                transform.position += direction.normalized * speed * Time.deltaTime;
            }


            Debug.Log("destination " + destination.position);
            Debug.Log("direction " + direction);

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

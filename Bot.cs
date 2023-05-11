using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame.Entities
{
    public class Bot : MonoBehaviour
    {
        public Transform destination; // Destination that the bot have to join
        public float speed = 5f; // Bot speed

        private GameObject basePlayer;
        private GameObject baseEnemy;

        private void Awake()
        {
        }

        // Start is called before the first frame update
        void Start()
        {
            // Define cube size
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

        }

        /// <summary>
        /// Show a green line between the bot and his destination
        /// </summary>
        void OnDrawGizmosSelected()
        {
            if (destination != null)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawLine(transform.position, destination.position);
            }
        }

    }
}

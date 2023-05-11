using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame.Entities
{
    public class Bot : MonoBehaviour
    {
        public Transform destination; // Destination that the bot have to join
        protected Rigidbody rb;

        public float speed = 30f; // Bot speed

        private GameObject basePlayer;
        private GameObject baseEnemy;

        public float pushForce = 10f;

        private int size = 5;
        public int Size
        {
            get { return size; }
            set { size = value; }
        }

        private void Awake()
        {
        }

        // Start is called before the first frame update
        void Start()
        {
            // Define cube size
            transform.localScale = new Vector3(size, size, size);

            rb = GetComponent<Rigidbody>();
            // do not move
            rb.freezeRotation = true;
            rb.interpolation = RigidbodyInterpolation.Extrapolate;
        }

        // Update is called once per frame
        void Update()
        {
            goToDestination(destination);
            keepOnTheGround();
            if(fallOff())
            {
                gameObject.SetActive(false);
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

        /// <summary>
        /// Make the bot go to a specific destination
        /// </summary>
        /// <param name="destination"></param>
        void goToDestination(Transform destination)
        {
            Vector3 direction = destination.position - transform.position;
            if (destination.position.x > transform.position.x)
            {
                transform.position += direction.normalized * speed * Time.deltaTime;
            }
        }

        /// <summary>
        /// Restrict Y movement of bots
        /// </summary>
        void keepOnTheGround()
        {
            var pos = transform.position;
            // Vérifier si la mini-entité va s'envoler
            if (pos.y > size)
            {
                // Si la mini-entité va s'envoler, ne pas la déplacer en Y
                pos.y = size;
                transform.position = pos;
            }
        }

        /// <summary>
        /// TODO : Comment this method
        /// </summary>
        /// <param name="collision"></param>
        void OnCollisionEnter(Collision collision)
        {
            // Vérifie si l'objet avec lequel le bot entre en collision est un autre bot
            if (collision.gameObject.CompareTag("Bot"))
            {
                // Calcule la direction à laquelle pousser les bots pour les sortir de la zone de collision
                Vector3 pushDirection = transform.position - collision.transform.position;
                pushDirection = pushDirection.normalized;

                // Applique une force inverse pour pousser les bots à l'extérieur de la zone de collision
                rb.AddForce(pushDirection * pushForce, ForceMode.Impulse);
            }
        }

        /// <summary>
        /// Check if bot fall off the platform
        /// </summary>
        /// <returns>True if fall, False if not</returns>
        bool fallOff()
        {
            var pos = transform.position;
            if (pos.y < -30.0f)
            {
                return true;
            }
            return false;
        }
    }
}

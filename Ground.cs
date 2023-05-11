using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MyGame;
using MyGame.Player;

namespace MyGame.World{
    public class Ground : MonoBehaviour
    {
        private Vector3 scale;

        public void Initialize(float x = 20f,float y =  20f,float z =  20f)
        {
            transform.localScale = new Vector3(x, y, z);
        }

        private void Awake()
        {
        }

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }
    }

}

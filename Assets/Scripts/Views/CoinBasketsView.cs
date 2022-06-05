using System;
using UnityEngine;

namespace Views
{
    public class CoinBasketsView : MonoBehaviour
    {
        public event EventHandler<Collision> OnCollision;
        
        private void Update()
        {
            Move();
        }

        private void OnCollisionEnter(Collision coll)  => OnCollision?.Invoke(this, coll);
        
        private void Move()
        {
            var mousePos2D = Input.mousePosition;
        
            if (Camera.main is null) return;
            var mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

            var transformLink = transform;
            var pos = transformLink.position;
            pos.x = mousePos3D.x;
            transformLink.position = pos;
        }
    }
}
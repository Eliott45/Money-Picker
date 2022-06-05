using Pooling_System;
using UnityEngine;

public class Basket : MonoBehaviour
{
    private void Update()
    {
        Move();
    }

    public void OnCollisionEnter(Collision coll) {
        Pool.Return(coll.gameObject);
    }

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

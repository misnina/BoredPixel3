using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneFall : MonoBehaviour
{
    private RaycastHit2D hitdown;
    private bool moveFinished = true;

    void Update()
    {
        hitdown = Physics2D.Raycast(transform.position, Vector2.down, 1);

        //fall if nothing under you
        if (hitdown.collider == null && moveFinished)
        {
            moveFinished = false;
            transform.position = Vector3.Lerp(transform.position, transform.position += Vector3.down, 0.1f);
            Invoke("FinishMove", 0.1f);

        }

    }

    private void FinishMove()
    {
        moveFinished = true;
    }

}

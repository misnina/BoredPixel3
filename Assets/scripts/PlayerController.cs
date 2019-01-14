using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private LerpHelper lerp;

    private bool moveFinished = true;
    private bool flying;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        lerp = GetComponent<LerpHelper>();
    }

    void Update()
    {
        RaycastHit2D hitdown = Physics2D.Raycast(transform.position, Vector2.down, 1);
        RaycastHit2D hitup = Physics2D.Raycast(transform.position, Vector2.up, 1);
        RaycastHit2D hitright = Physics2D.Raycast(transform.position, Vector2.right, 1);
        RaycastHit2D hitleft = Physics2D.Raycast(transform.position, Vector2.left, 1);

        //Fly Up
        if (Input.GetKey(KeyCode.W) && moveFinished)
        {
            if (hitup.collider == null)
            {
                StartMove();
                lerp.startPosition = transform.position;
                lerp.endPosition = transform.position + Vector3.up;
                lerp.StartLerping();

            }
        }

        //Dig Down
        if (Input.GetKey(KeyCode.S) && moveFinished)
        {
            if (hitdown.collider != null)
            {
                Destroy(hitdown.collider.gameObject);
                StartMove();
                lerp.startPosition = transform.position;
                lerp.endPosition = transform.position +  Vector3.down;
                lerp.StartLerping();
            }

        }

        //Dig Right
        if (Input.GetKey(KeyCode.D) && moveFinished)
        {
            if (hitright.collider != null)
            {
                Destroy(hitright.collider.gameObject);
            }
            StartMove();
            lerp.startPosition = transform.position;
            lerp.endPosition = transform.position + Vector3.right;
            lerp.StartLerping();

        }

        //Dig left
        if (Input.GetKey(KeyCode.A) && moveFinished)
        {
            if (hitleft.collider != null)
            {
                Destroy(hitleft.collider.gameObject);
            }
            StartMove();
            lerp.startPosition = transform.position;
            lerp.endPosition = transform.position + Vector3.left;
            lerp.StartLerping();

        }

        //fall if nothing under you
        if (hitdown.collider == null && moveFinished)
        {
            StartMove();
            lerp.startPosition = transform.position;
            lerp.endPosition = transform.position + Vector3.down;
            lerp.StartLerping();
        }

    }

    private void StartMove()
    {
        moveFinished = false;
        Invoke("EndMove", 0.2f);
    }

    private void EndMove()
    {
        moveFinished = true;
    }

   
}

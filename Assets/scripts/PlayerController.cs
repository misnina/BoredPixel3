using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private LerpHelper lerp;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        lerp = GetComponent<LerpHelper>();
    }

    void Update()
    {
        RaycastHit2D hitdown = Physics2D.Raycast(transform.position, Vector2.down);
        RaycastHit2D hitup = Physics2D.Raycast(transform.position, Vector2.up);
        RaycastHit2D hitright = Physics2D.Raycast(transform.position, Vector2.right);
        RaycastHit2D hitleft = Physics2D.Raycast(transform.position, Vector2.left);

        //Dig Down
        if (Input.GetKeyUp(KeyCode.S))
        {
            if (hitdown.collider != null)
            {
                Destroy(hitdown.collider.gameObject);
                lerp.startPosition = transform.position;
                lerp.endPosition = transform.position +  Vector3.down;
                lerp.StartLerping();
            }

        }

        //Dig Right
        if (Input.GetKeyUp(KeyCode.D))
        {
            if (hitright.collider != null)
            {
                Destroy(hitright.collider.gameObject);
                lerp.startPosition = transform.position;
                lerp.endPosition = transform.position + Vector3.right;
                lerp.StartLerping();
            }

        }

        //Dig left
        if (Input.GetKeyUp(KeyCode.A))
        {
            if (hitleft.collider != null)
            {
                Destroy(hitleft.collider.gameObject);
                lerp.startPosition = transform.position;
                lerp.endPosition = transform.position + Vector3.left;
                lerp.StartLerping();
            }

        }


        //Fly Up
        if (Input.GetKey(KeyCode.W))
        {
            if (hitdown.collider != null)
            {
                lerp.startPosition = transform.position;
                lerp.endPosition = transform.position + Vector3.up;
                lerp.StartLerping();
            }

        }

        //fall if nothing under you
        if (hitdown.collider == null && !Input.GetKey(KeyCode.W))
        {
            lerp.startPosition = transform.position;
            lerp.endPosition = transform.position + Vector3.down;
            lerp.StartLerping();
        }

    }
}

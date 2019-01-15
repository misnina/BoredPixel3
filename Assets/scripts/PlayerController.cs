using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private LerpHelper lerp;

    private bool moveFinished = true;
    private bool falling;

    RaycastHit2D hitdown;
    RaycastHit2D hitup;
    RaycastHit2D hitright;
    RaycastHit2D hitleft;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        lerp = GetComponent<LerpHelper>();
    }

    void Update()
    {

         hitdown = Physics2D.Raycast(transform.position, Vector2.down, 1);
        hitup = Physics2D.Raycast(transform.position, Vector2.up, 1);
        hitright = Physics2D.Raycast(transform.position, Vector2.right, 1);
        hitleft = Physics2D.Raycast(transform.position, Vector2.left, 1);

        //Fly Up
        if (Input.GetKey(KeyCode.W) && moveFinished)
        {
           
            if (hitup.collider == null)
            {
                Inventory.instance.fuel--;
                StartMove();
                lerp.endPosition = transform.position + Vector3.up;
                LerpSetup();

            }
        }

        //Dig Down
        if (Input.GetKey(KeyCode.S) && moveFinished)
        {
           
            if (hitdown.collider != null && hitdown.collider.gameObject.tag == "Block")
            {
                Inventory.instance.fuel--;
                hitdown.collider.GetComponent<Destroy>().destroyed = true;
                MoveDown();
            } else if (hitdown.collider != null && hitdown.collider.gameObject.tag == "Mineral")
            {
                Inventory.instance.fuel--;
                Mineral.instance.Mine(hitdown.collider);
                hitdown.collider.GetComponent<Destroy>().destroyed = true;
                MoveDown();
            }

        }

        //Dig Right
        if (Input.GetKey(KeyCode.D) && moveFinished)
        {
            Inventory.instance.fuel--;
            if (hitright.collider != null && hitright.collider.gameObject.tag == "Block" && !falling)
            {
                Inventory.instance.fuel--;
                hitright.collider.GetComponent<Destroy>().destroyed = true;
            }
            else if (hitright.collider != null &&  hitright.collider.gameObject.tag == "Mineral" && !falling)
            {
                Inventory.instance.fuel--;
                Mineral.instance.Mine(hitright.collider);
                Mineral.instance.Mine(hitdown.collider);
                hitright.collider.GetComponent<Destroy>().destroyed = true;
                StartMove();
                lerp.endPosition = transform.position + Vector3.right;
                LerpSetup();
            }
            else if (hitright.collider == null)
            {
                Inventory.instance.fuel--;
                StartMove();
                lerp.endPosition = transform.position + Vector3.right;
                LerpSetup();
            }

        }

        //Dig left
        if (Input.GetKey(KeyCode.A) && moveFinished)
        {
            Inventory.instance.fuel--;
            if (hitleft.collider != null && hitleft.collider.gameObject.tag == "Block" && !falling)
            {
                Inventory.instance.fuel--;
                hitleft.collider.GetComponent<Destroy>().destroyed = true;
            }
            else if (hitleft.collider != null && hitleft.collider.gameObject.tag == "Mineral" && !falling)
            {
                Inventory.instance.fuel--;
                Mineral.instance.Mine(hitleft.collider);
                Mineral.instance.Mine(hitdown.collider);
                hitleft.collider.GetComponent<Destroy>().destroyed = true;
                StartMove();
                lerp.endPosition = transform.position + Vector3.left;
                LerpSetup();
            }
            else if (hitleft.collider == null)
            {
                Inventory.instance.fuel--;
                StartMove();
                lerp.endPosition = transform.position + Vector3.left;
                LerpSetup();
            }

        }

        //fall if nothing under you
        if (hitdown.collider == null)
        {
            falling = true;
            if (moveFinished)
            {

                StartMove();
                lerp.endPosition = transform.position + Vector3.down;
                //lerp.lerpTime = 0.1f;
                LerpSetup();
            }

        }
        else
        {
            falling = false;
        }

    }

    private void MoveDown()
    {
        StartMove();
        lerp.endPosition = transform.position + Vector3.down;
        LerpSetup();
    }

    private void LerpSetup()
    {
        lerp.startPosition = transform.position;
        lerp.StartLerping();
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public bool destroyed;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(destroyed)
        {
            anim.SetBool("destroy", true);
            Invoke("DestroyBlock", 0.2f);
        }
    }

    private void DestroyBlock()
    {
        Destroy(this.gameObject);
    }
}

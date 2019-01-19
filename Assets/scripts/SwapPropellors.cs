using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapPropellors : MonoBehaviour
{
    private SpriteSwapDemo spriteSwap;
    void Start()
    {
        spriteSwap = GameObject.Find("Player").GetComponent<SpriteSwapDemo>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            spriteSwap.SpriteSheetName = "player_alt";
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            spriteSwap.SpriteSheetName = "player";
        }
    }
}

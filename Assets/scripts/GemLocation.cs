using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GemLocation : MonoBehaviour
{
 
    void Start()
    {
        transform.position = new Vector3(Random.Range(0.5f, 45.5f), transform.position.y, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            SceneManager.LoadScene("win");
        }
    }
}

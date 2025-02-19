using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STAIRS : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<StairMovement>().enabled = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.GetComponent<StairMovement>().enabled = false;
    }

    private void OnEnable()
    {
        GetComponent<Rigidbody2D>().gravityScale = 0;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
    private void OnDisable()
    {
        GetComponent<Rigidbody2D>().gravityScale = 1;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairMovement : MonoBehaviour
{
    public float stairSpeed = 3;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float y = Input.GetAxis("Vertical");

        transform.Translate(new Vector2(0, y) * stairSpeed * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveTowards : MonoBehaviour
{
    public float speed = 3f;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PLAYERMOVEMENT>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newposition = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        transform.position = newposition;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(target);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

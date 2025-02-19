using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coin = 1;
    public AudioClip Audio;
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
        if(collision.GetComponent<PLAYERMOVEMENT>())
        {
            AudioManager.instance.PlayAudio(Audio, "AudioMoneda");
            Destroy(gameObject);
        }
    }
}

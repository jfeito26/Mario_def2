using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMusic : MonoBehaviour
{
    public AudioClip background;
    private List<AudioSource> Background;
    // Start is called before the first frame update
    void Start()
    {
        if(AudioManager.instance != null)
        {
            
            DontDestroyOnLoad(gameObject);//no destruir escena anterior
            AudioManager.instance.PlayAudio(background, "background", true);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

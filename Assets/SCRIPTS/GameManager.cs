using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum InterfaceVariable {TIME, COINS }
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    private List<AudioSource> sounds;//allActiveSounds
    //public AudioClip NombreAudio;
    //GameManager.instance.PlayAudio(NombreAudio, "NombreAudio", true(si queremos que sea loop));
    private float currentGameTime = 0.0f;
    private int coins = 0;
    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);//no destruir escena anterior
        }
        else
        {
            Destroy(gameObject);//si ya hay manager destruir
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        sounds = new List<AudioSource>();
    }

    public AudioSource PlayAudio(AudioClip clip, string gameObjectName, bool isloop = false, float volume = 1)
    {
        //1- Create empty
        GameObject nObj = new GameObject();
        //2- ponerle nombre
        nObj.name = gameObjectName;
        //3-Añadir el AudioSorce
        AudioSource audioSourceComponent = nObj.AddComponent<AudioSource>();
        //4-Arrastrar audioClip
        audioSourceComponent.clip = clip;
        //5-seteamos el loop
        audioSourceComponent.loop = isloop;
        //6-regular propiedades...
        audioSourceComponent.volume = volume;
        //7-añadimos objeto a la lista
        sounds.Add(audioSourceComponent);
        //8-que retumbe
        audioSourceComponent.Play();
        //9-Cuando deje de sonar se destruye(performance(rendimiento))
        StartCoroutine(WaitForAudio(audioSourceComponent));

        return audioSourceComponent;
    }

    private IEnumerator WaitForAudio(AudioSource source)
    {
        if(source.loop)
        {
            yield return null;
        }
        else
        {
            //esperamos mientras el audio este sonando
            while (source.isPlaying)
            {
                yield return new WaitForSeconds(0.3f);
            }

            //cuando el audio deja de sonar lo destruimos
            Destroy(source.gameObject);
        }
    }

    public void StartPlaying()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Inicio");
    }


    public float GetTime()
    {
        return currentGameTime;
    }

    public void PlusCoin(int value)
    {
        coins += value;
    }

    public float ValueCoins()
    {
        return coins;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    //switch (variableUpdate) {
    //    case InterfaceVariable.COINS:
    //    textComponent.text = "Puntos: " + AudioManager.instance.GetCoins();
    //    break; F2(2 decimales)
}

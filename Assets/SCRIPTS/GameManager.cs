using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public enum InterfaceVariable { TIME, COINS }
public class GameManager : MonoBehaviour
{
    private float currentGameTime = 0.0f;
    private int coins = 0;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI coinsText;
    public static GameManager instance;
    // Start is called before the first frame update

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

    void Start()
    {
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        currentGameTime += Time.deltaTime;
        UpdateInterface(InterfaceVariable.COINS);
        UpdateText();
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
        UpdateInterface(InterfaceVariable.COINS);
        UpdateText();
    }

    public float ValueCoins()
    {
        return coins;
    }
    private void UpdateText()
    {

        if (timeText != null)
        {
            timeText.text = "Tiempo: " + currentGameTime.ToString("F2"); // "F2" para 2 decimales.
        }

        if (coinsText != null)
        {
            coinsText.text = "Monedas: " + coins.ToString();
        }
    }

    public void UpdateInterface(InterfaceVariable variableUpdate)
    {
        switch (variableUpdate)
        {
            case InterfaceVariable.TIME:
                if (timeText != null)
                {
                    timeText.text = "Tiempo: " + currentGameTime.ToString("F2");
                }
                break;
            case InterfaceVariable.COINS:
                if (coinsText != null)
                {
                    coinsText.text = "Monedas: " + coins.ToString();
                }
                break;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIControl : MonoBehaviour
{
    public LanguageSettings languageSet;
    [Header("Textos de UI")]
    [SerializeField] TMP_Text ButtonPlayTEXT;
    [SerializeField] TMP_Text ButtonPlayTEXT2;
    [SerializeField] TMP_Text velocidadeCarroUM;
    [SerializeField] TMP_Text velocidadeCarroDOIS;
    [SerializeField] TMP_Text esperarParaIniciarUM;
    [SerializeField] TMP_Text esperarParaIniciarDOIS;
    [SerializeField] TMP_Text tempoGame;

    [Header("Textos em suas Linguagens")]
    [Header("PTBR")]
    [SerializeField] string iniciar;
    [SerializeField] string velocidade;
    [SerializeField] string esperar;
    [SerializeField] string tempo;
    [SerializeField] string linguagem;

    [Header("ING")]
    [SerializeField] string startB;
    [SerializeField] string velocity;
    [SerializeField] string wait;
    [SerializeField] string tempoING;
    [SerializeField] string language;
    private void Awake()
    {
        languageSet = new LanguageSettings();
    }
    void Start()
    {
        SetPTBR();
        SetING();
        if (Application.systemLanguage == SystemLanguage.Portuguese)
        {
            LoadPTBR();
            Debug.Log("This system is in Brasil. ");
        }
        else
        {
            LoadING();
            Debug.Log("This system is in English. ");
        }
        loadSettings();
    }
    void SetPTBR()
    {
        linguagem = "PTBR";
        iniciar = "INICIAR";
        velocidade = "VELOCIDADE";
        esperar = "ESPERAR PARA INICIAR?";
        tempo = "TEMPO";
    }
    void SetING()
    {
        language = "ING";
        startB = "PLAY";
        velocity = "VELOCITY";
        wait = "WAIT TO START?";
        tempoING = "TIME";
    }
    void LoadPTBR()
    {
        languageSet.language = linguagem;
        languageSet.playButton = iniciar;
        languageSet.velocityUM = velocidade;
        languageSet.velocityDOIS = velocidade;
        languageSet.waitForSecondsUM = esperar;
        languageSet.waitForSecondsDOIS = esperar;
        languageSet.tempo = tempo;
        languageSet.SaveLanguage();
    }
    void LoadING()
    {
        languageSet.language = language;
        languageSet.playButton = startB;
        languageSet.velocityUM = velocity;
        languageSet.velocityDOIS = velocity;
        languageSet.waitForSecondsUM = wait;
        languageSet.waitForSecondsDOIS = wait;
        languageSet.tempo = tempoING;
        languageSet.SaveLanguage();
    }
    void loadSettings()
    {
        languageSet.LoadLanguage();
        if(ButtonPlayTEXT != null)
        {
            ButtonPlayTEXT.text = languageSet.playButton.ToString();
        }
        if(ButtonPlayTEXT2 != null)
        {
            ButtonPlayTEXT2.text = languageSet.playButton.ToString();
        }
        if(velocidadeCarroUM != null)
        {
            velocidadeCarroUM.text = languageSet.velocityUM.ToString();
        }
        if (velocidadeCarroDOIS != null)
        {
            velocidadeCarroDOIS.text = languageSet.velocityDOIS.ToString();
        }
        if(esperarParaIniciarUM != null)
        {
            esperarParaIniciarUM.text = languageSet.waitForSecondsUM.ToString();
        }
        if (esperarParaIniciarDOIS != null)
        {
            esperarParaIniciarDOIS.text = languageSet.waitForSecondsDOIS.ToString();
        }
        if(tempoGame != null)
        {
            tempoGame.text = languageSet.tempo.ToString();
        }
    }
}

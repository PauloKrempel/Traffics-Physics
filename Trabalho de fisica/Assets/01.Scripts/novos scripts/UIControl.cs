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
    private void Awake()
    {
        languageSet = new LanguageSettings();
    }
    void Start()
    {
        if (Application.systemLanguage == SystemLanguage.Portuguese)
        {
            languageSet.LoadLanguagePT();
            loadSettings();
            Debug.Log("This system is in Brasil. ");
        }
        else
        {
            languageSet.LoadLanguageEUA();
            loadSettings();
            Debug.Log("This system is in English. ");
        }
        loadSettings();
    }
    void loadSettings()
    {
        //languageSet.LoadLanguage();
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

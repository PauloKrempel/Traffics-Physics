using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public CharacterCar characterCar;

    [Header("Painel de Layout")]
    [SerializeField] GameObject LayerMenu;
    [SerializeField] GameObject LayerVariaveis;

    [Header("Botão de Start")]
    [SerializeField] Button starGame;

    [Header("Inputs")]
    //Inputfields
    [SerializeField] InputField speedCarUM;
    [SerializeField] InputField speedCarDOIS;
    [SerializeField] InputField IFsecondsUM;
    [SerializeField] InputField IFsecondsDOIS;

    private void Awake()
    {
        LayerVariaveis.SetActive(false);
    }
    void Start()
    {
        characterCar = new CharacterCar();
    }
    private void Update()
    {

    }

    public void SaveAndStart()
    {
        characterCar.speed01 = float.Parse(speedCarUM.text);
        characterCar.speed02 = float.Parse(speedCarDOIS.text);
        characterCar.waitSeconds01 = int.Parse(IFsecondsUM.text);
        characterCar.waitSeconds02 = int.Parse(IFsecondsDOIS.text);
        characterCar.secondsAssigned01 = int.Parse(IFsecondsUM.text);
        characterCar.secondsAssigned02 = int.Parse(IFsecondsDOIS.text);

        PlayerPrefs.SetFloat("speedUM", characterCar.speed01);
        PlayerPrefs.SetFloat("speedDOIS", characterCar.speed02);
        PlayerPrefs.SetFloat("waitSecondsUM", characterCar.waitSeconds01);
        PlayerPrefs.SetFloat("waitSecondsDOIS", characterCar.waitSeconds02);
        PlayerPrefs.SetFloat("secondsAssigned01", characterCar.secondsAssigned01);
        PlayerPrefs.SetFloat("secondsAssigned02", characterCar.secondsAssigned02);

        characterCar.SaveCharacter();
        StartCoroutine(loadSceneGame());
    }

    public void OpenChoicesVar()
    {
        LayerMenu.SetActive(false);
        LayerVariaveis.SetActive(true);
    }
    public void CloseChoicesVar()
    {
        LayerMenu.SetActive(true);
        LayerVariaveis.SetActive(false);
    }

    public void cancelar()
    {
        LayerMenu.SetActive(true);
        LayerVariaveis.SetActive(false);
    }

    public void closeGame()
    {
        Application.Quit();
    }
    IEnumerator loadSceneGame()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("teste");
        StopAllCoroutines();
    }
}

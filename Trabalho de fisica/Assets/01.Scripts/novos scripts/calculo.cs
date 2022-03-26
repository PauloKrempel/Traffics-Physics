using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class calculo : MonoBehaviour
{
    public CharacterCar characterCar;
    //public GameObject player;

    [Header("Variaveis")]
    [Header("Buscando")]
    [SerializeField] bool buscando;
    [SerializeField] int permissionBusca;
    [Header("Carro 01")]
    [SerializeField] float velocidadeCarroUM;
    [SerializeField] float esperaCarroUm;
    [SerializeField] float SoUM = 0f;
    [SerializeField] float SfinalUM;
    [Header("Carro 02")]
    [SerializeField] float velocidadeCarroDOIS;
    [SerializeField] float esperaCarroDOIS;
    [SerializeField] float SoDOIS = 48.12f;//49.181385f; //48.11304f
    [SerializeField] float SfinalDOIS;
    [Header("Tempo")]
    [SerializeField] float tempo;

    [Header("UI")]
    [Header("UI CARRO 01")]
    [SerializeField] TMP_Text Sf01;
    [SerializeField] TMP_Text So01;
    [SerializeField] TMP_Text v01;
    [SerializeField] TMP_Text tempo01;
    [Header("UI CARRO 02")]
    [SerializeField] TMP_Text Sf02;
    [SerializeField] TMP_Text So02;
    [SerializeField] TMP_Text v02;
    [SerializeField] TMP_Text tempo02;
    void Start()
    {
        characterCar = new CharacterCar();
        buscando = true;
        //player = GetComponent<carControl>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.faseConfirmacao && buscando)
        {
            characterCar.LoadCharacter();
            velocidadeCarroUM = characterCar.speed01;
            velocidadeCarroDOIS = characterCar.speed02;
            esperaCarroUm = characterCar.waitSeconds01;
            esperaCarroDOIS = characterCar.waitSeconds02;
            tempo = characterCar.encontroTime;
        }
    }
    public void buscandoFalse()
    {
        buscando = false;
        calculoFinalUM();
        calculoFinalDOIS();
    }
    public void calculoFinalUM()
    {
        if(esperaCarroUm == 0)
        {
            SfinalUM = SoUM + velocidadeCarroUM * tempo;
            Debug.LogError("A posição final do carro UM é: " + SfinalUM + " Metros");
            Sf01.text = SfinalUM.ToString();
            So01.text = "0";
            v01.text = velocidadeCarroUM.ToString();
            tempo01.text = tempo.ToString();
        }
        else
        {
            SfinalUM = SoUM + velocidadeCarroUM * (tempo - esperaCarroUm);
            Debug.LogError("A posição final do carro UM é: " + SfinalUM + " Metros");
            Sf01.text = SfinalUM.ToString();
            So01.text = "0";
            v01.text = velocidadeCarroUM.ToString();
            tempo01.text = tempo.ToString() + " - " + esperaCarroUm.ToString();
        }
        
    }
    public void calculoFinalDOIS()
    {
        if (esperaCarroDOIS == 0)
        {
            SfinalDOIS = SoDOIS - velocidadeCarroDOIS * tempo;
            Debug.LogError("A posição final do carro DOIS é: " + SfinalDOIS + " Metros");
            Sf02.text = SfinalDOIS.ToString();
            //So02.text = SoDOIS.ToString();
            So02.text = "48,12";
            v02.text = velocidadeCarroDOIS.ToString();
            tempo02.text = tempo.ToString();
            Debug.LogError("A origem do carro 2 é: " + SoDOIS);
        }
        else
        {
            SfinalDOIS = SoDOIS - velocidadeCarroDOIS * (tempo - esperaCarroDOIS);
            Debug.LogError("A posição final do carro DOIS é: " + SfinalDOIS + " Metros");
            Sf02.text = SfinalDOIS.ToString();
            So02.text = SoDOIS.ToString();
            v02.text = velocidadeCarroDOIS.ToString();
            tempo02.text = tempo.ToString() + " - " + esperaCarroDOIS.ToString();
        }
        
    }
}

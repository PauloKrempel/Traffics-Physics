using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class carUMControl : MonoBehaviour
{
    public CharacterCar characterCar;
    [Header("Escale")] //Escala
    [SerializeField] Vector2 escaleGame;
    [SerializeField] float DefinedScale;
    //--------------
    [Header("Current Position")] //Posição atual
    Vector2 posUM;
    //--------------
    [Header("Meeting point")] //Ponto de encontro
    [SerializeField] GameObject iconFound;
    [SerializeField] Transform car2;
    [SerializeField] bool FoundPosition;
    //---------------
    [Header("Attributes")] //Atributos
    [SerializeField] float speed;
    [SerializeField] float FinalSpeed;
    [SerializeField] bool RightDirection;
    Vector2 dir;
    //---------------
    [Header("Timer")]
    [SerializeField] bool counter;
    [SerializeField] TMP_Text timer;
    [SerializeField] float startTime;
    [SerializeField] float ToCalculate;
    [SerializeField] bool Calculating;
    //---------------
    [Header("Seconds Verifiers")]
    [SerializeField] float IFsegundos;
    [SerializeField] float segundos;
    [SerializeField] bool aguardar;
    //---------------
    [Header("Contador")]
    [SerializeField] float counterTime;
    [SerializeField] float countdown = 5f;
    [SerializeField] TMP_Text backwardTEXT;
    public bool startGame;
    public bool Play;
    public bool CounterBool;
    public GameObject backwardGO;

    private void Awake()
    {
        characterCar = new CharacterCar();
    }
    void Start()
    {
        escaleGame = new Vector2(DefinedScale, 0f);
        characterCar.LoadCharacter();
        speed = characterCar.speed01;
        print(characterCar.speed01);
        IFsegundos = characterCar.waitSeconds01;
        segundos = characterCar.secondsAssigned01;

        FoundPosition = false;

        FinalSpeed = speed * 0.5f;

        //verifierIFSeconds();
    }

    // Update is called once per frame
    void Update()
    {
        if (startGame)
        {
            //TranslateGO();
            if (!aguardar && !FoundPosition)
            {
                transform.Translate(dir * FinalSpeed * Time.deltaTime);
            }
        }
        // if (counter && !FoundPosition && Play)
        // {
        //     float t = Time.time - startTime;
        //     string seconds = (t % 60).ToString();
        //     timer.text = seconds;
        //     characterCar.encontroTime = float.Parse(timer.text);
        //     ToCalculate = characterCar.encontroTime;
        //     print("numero armazenado: " + characterCar.encontroTime);
        //     Debug.LogWarning("Numero sendo calculado é: " + ToCalculate);
        // }
        // if (FoundPosition)
        // {
        //     if (Calculating)
        //     {
        //         if (ToCalculate != 0)
        //         {
        //             characterCar.SaveCharacter();
        //             Debug.LogError("o numero calculado de tempo �: " + ToCalculate);
        //             Calculating = false;
        //             GameManager.instance.EncontroCars = true;
        //         }
        //     }
        // }
        if (Vector2.Distance(new Vector2(transform.position.x, transform.position.y), new Vector2(car2.transform.position.x, transform.position.y)) == 0f)
        {
            Debug.LogError("Econtrouuuuuuuuuuuuuuuuu");
        }
    }

    void TranslateGO()
    {
        if (!aguardar && !FoundPosition)
        {
            transform.Translate(dir * FinalSpeed * Time.deltaTime);
        }
    }
    void verifierIFSeconds()
    {
        if (IFsegundos != 0)
        {
            aguardar = true;
            StartCoroutine(CDForStart());
        }
        else
        {
            aguardar = false;
        }
    }

    IEnumerator CDForStart()
    {
        yield return new WaitForSeconds(segundos);
        aguardar = false;
        StopCoroutine(CDForStart());
    }
}

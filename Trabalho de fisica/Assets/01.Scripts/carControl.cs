using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class carControl : MonoBehaviour
{
    public CharacterCar characterCar;

    [Header("Atributos")]
    [SerializeField] float speed = 5f;
    [SerializeField] float speedFinal;
    [SerializeField] bool RightDirection;
    [SerializeField] bool carUM;
    [SerializeField] bool npc;
    Vector2 dir;
    [Header("Ponto de encontro")]
    [SerializeField] bool encontrou;
    [SerializeField] GameObject pontoEncontro;
    [Header("Timer")]
    [SerializeField] bool contador;
    [SerializeField] TMP_Text timer;
    [SerializeField] float startTime;
    [SerializeField] float forCalcular;
    [SerializeField] bool calculando;
    [Header("Verificadores de segundos")]
    [SerializeField] float IFsegundos;
    [SerializeField] float segundos;
    [SerializeField] bool aguardar;
    [Header("Raycast")]
    [SerializeField] float distanceRayCast = 0.8f;

    [Header("UI")]
    [SerializeField] GameObject confirmarPonto;
    private void Awake()
    {
        characterCar = new CharacterCar();
    }
    void Start()
    {
        if(npc)
        {
            speed = 2;
        }
        if(carUM && !npc)
        {
            characterCar.LoadCharacter();
            speed = characterCar.speed01;
            print(characterCar.speed01);
            IFsegundos = characterCar.waitSeconds01;
            segundos = characterCar.secondsAssigned01;
            verifierIFSeconds();
        }
        else if(!carUM && !npc)
        {
            characterCar.LoadCharacter();
            speed = characterCar.speed02;
            print(characterCar.speed02);
            IFsegundos = characterCar.waitSeconds02;
            segundos = characterCar.secondsAssigned02;
            verifierIFSeconds();
        }
        encontrou = false;
        verifierDirection();

        speedFinal = speed * 0.5f;
        startTime = Time.time;
        calculando = true;
    }

    void Update()
    {
        if(!aguardar && !encontrou)
        {
            transform.Translate(dir * speedFinal * Time.deltaTime);
        }
        if(!npc)
        {
            if(contador && !encontrou)
            {
                float t = Time.time - startTime;
                string seconds = (t % 60).ToString();
                timer.text = seconds;
                characterCar.encontroTime = float.Parse(timer.text);
                forCalcular = characterCar.encontroTime;
                print("numero armazenado: " + characterCar.encontroTime);
                Debug.LogWarning("Numero sendo calculado é: " + forCalcular);
            }
            verifierColision();
        }
        if(encontrou)
        {
            if(calculando)
            {
                if (forCalcular != 0)
                {
                    characterCar.SaveCharacter();
                    Debug.LogError("o numero calculado de tempo é: " + forCalcular);
                    calculando = false;
                    GameManager.instance.EncontroCars = true;
                }
            }
        }
    }
    void verifierDirection()
    {
        if(RightDirection)
        {
            dir = Vector2.right;
        }
        else
        {
            dir = Vector2.left;
        }
    }
    void verifierIFSeconds()
    {
        if(IFsegundos != 0)
        {
            aguardar = true;
            StartCoroutine(CDForStart());
        }
        else
        {
            aguardar = false;
        }
    }

    void verifierColision()
    {
        RaycastHit2D encontro = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + 0.75f), Vector2.up, distanceRayCast, LayerMask.GetMask("car"));
        Debug.DrawRay(transform.position, Vector2.up * distanceRayCast, Color.red);
        if (encontro.collider != null && encontrou == false)
        {
            Instantiate(pontoEncontro, transform.position, transform.rotation);
            encontrou = true;
            Debug.LogError("Encontrou o carro por cima");
        }
        RaycastHit2D encontroDown = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 0.75f), Vector2.down, distanceRayCast, LayerMask.GetMask("car"));
        Debug.DrawRay(transform.position, Vector2.down * distanceRayCast, Color.yellow);
        if (encontroDown.collider != null && encontrou == false)
        {
            Instantiate(pontoEncontro, transform.position, transform.rotation);
            encontrou = true;
            Debug.LogError("Encontrou o carro por baixo");
        }
    }

    IEnumerator CDForStart()
    {
        yield return new WaitForSeconds(segundos);
        aguardar = false;
        StopCoroutine(CDForStart());
    }
}

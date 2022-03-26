using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    [Header("Encontrou?")]
    public bool EncontroCars;
    [Header("UI")]
    [SerializeField] GameObject confirmar;
    [SerializeField] GameObject calcular;
    [SerializeField] GameObject MenuGO;
    [SerializeField] TMP_Text textConfirmar;
    public bool faseConfirmacao = false;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            gameObject.SetActive(false);
            return;
        }
        instance = this;
        //DontDestroyOnLoad(gameObject);

    }
    void Start()
    {
        faseConfirmacao = false;
        EncontroCars = false;
        
        confirmar.SetActive(false);
        calcular.SetActive(false);
        MenuGO.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(EncontroCars && !faseConfirmacao)
        {
            confirmar.SetActive(true);
            StartCoroutine(confirmarEncontro());

        }
        else if(EncontroCars && faseConfirmacao)
        {
            calcular.SetActive(true);
        }
    }

    public void closeCalculo()
    {
        faseConfirmacao = false;
        EncontroCars = false;
        calcular.SetActive(false);
        confirmar.SetActive(false);
        MenuGO.SetActive(true);
    }
    public void returnMenu()
    {
        SceneManager.LoadScene("menu");
    }
    IEnumerator confirmarEncontro()
    {
        yield return new WaitForSeconds(2);
        for (int i = 5; i > 0; i--)
        {
            Debug.LogError("Confirmando em: " + i);
            yield return new WaitForSeconds(1);
            //textConfirmar.text = i.ToString();
            
        }
        faseConfirmacao = true;
        //SceneManager.LoadScene("teste");
        StopAllCoroutines();
        
    }
}

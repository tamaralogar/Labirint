using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Trgovina : MonoBehaviour
{
    public Dictionary<string, int> ceneNakupov = new Dictionary<string, int>();

    public UnityEngine.UI.Button gumbZdravje;
    public UnityEngine.UI.Button gumbHitrost;
    public UnityEngine.UI.Button gumbDenar;
    public UnityEngine.UI.Button gumbZdravljenje;

    void Awake()
    {
        ceneNakupov.Add("Zdravje", 50);
        ceneNakupov.Add("Hitrost", 30);
        ceneNakupov.Add("Denar", 60);
        ceneNakupov.Add("Zdravljenje", 40);

        DontDestroyOnLoad(gameObject);
    }

    public void KupiNadgradnjoZdravja() 
    {
        int cena = ceneNakupov["Zdravje"];

        if (GameMaster.Instanca.skupniDenar >= cena && GameMaster.Instanca.levelNadgradnjeZdravje < 3)
        {
            GameMaster.Instanca.skupniDenar -= cena;
            GameMaster.Instanca.KupiZdravje();
            Debug.Log("Kupljeno! Preostanek denarja: " + GameMaster.Instanca.skupniDenar);
       
            if (GameMaster.Instanca.levelNadgradnjeZdravje == 3)
            {
                gumbZdravje.interactable = false;
            }
        }
        else
        {
            Debug.Log("Premalo denarja za zdravje!");
        }
    }


    public void KupiNadgradnjoHitrosti() 
    {
        int cena = ceneNakupov["Hitrost"];

        if (GameMaster.Instanca.skupniDenar >= cena && GameMaster.Instanca.levelNadgradnjeHitrost < 2)
        {
            GameMaster.Instanca.skupniDenar -= cena;
            GameMaster.Instanca.KupiHitrost();
            Debug.Log("Kupljeno! Preostanek denarja: " + GameMaster.Instanca.skupniDenar);
            
            if (GameMaster.Instanca.levelNadgradnjeHitrost == 2)
            {
                gumbHitrost.interactable = false;
            }
        }
        else
        {
            Debug.Log("Premalo denarja za hitrost!");
        }
    }


    public void KupiNadgradnjoDenarja() 
    {
        int cena = ceneNakupov["Denar"];

        if (GameMaster.Instanca.skupniDenar >= cena && GameMaster.Instanca.levelNadgradnjeDenar < 2)
        {
            GameMaster.Instanca.skupniDenar -= cena;
            GameMaster.Instanca.KupiVecDenarja();
            Debug.Log("Kupljeno! Preostanek denarja: " + GameMaster.Instanca.skupniDenar);
            
            if (GameMaster.Instanca.levelNadgradnjeDenar == 2)
            {
                gumbDenar.interactable = false;
            }
        }
        else
        {
            Debug.Log("Premalo denarja za vec denarja!");
        }
    }


    public void KupiNadgradnjoZdravljenja() 
    {
        int cena = ceneNakupov["Zdravljenje"];

        if (GameMaster.Instanca.skupniDenar >= cena && GameMaster.Instanca.levelNadgradnjeZdravljenje < 1)
        {
            GameMaster.Instanca.skupniDenar -= cena;
            GameMaster.Instanca.KupiZdravljenje();
            Debug.Log("Kupljeno! Preostanek denarja: " + GameMaster.Instanca.skupniDenar);
            
            if (GameMaster.Instanca.levelNadgradnjeZdravljenje == 1)
            {
                gumbZdravljenje.interactable = false;
            }
        }
        else
        {
            Debug.Log("Premalo denarja za zdravljenje!");
        }
    }

    public void NaNaslednjiLevel()
    {
        GameMaster.Instanca.trenutniLevel++;
        GameMaster.Instanca.ZapriTrgovino();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}

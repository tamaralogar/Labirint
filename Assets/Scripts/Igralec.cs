using UnityEngine;
using UnityEngine.SceneManagement;

public class Igralec : MonoBehaviour

{
    public int zdravje;
    public Vector3 zacetnaPozicija;


    void Start()
    {
        // shrani zacetno pozicijo
        zacetnaPozicija = transform.position;
        zdravje = GameMaster.Instanca.trenutnoMaxZdravje;

    }

    public void OdbijZdravje(int skoda)
    {
        zdravje = zdravje - skoda;
        Debug.Log("Igralec se je zaletel v rdeco steno! Preostalo zdravje: " + zdravje);

        if (zdravje <= 0)
        {
            Debug.Log("Igralec je mrtev!");

            //odbitje denarja pridobljenega v tem levelu
            GameMaster.Instanca.IzgubiDenar();

            //posodobitev scene - da se ponovno naložijo zakladi in igralec vrne na start
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void DodajZdravje(int pozdravi)
    {
        int trenutniMax = GameMaster.Instanca.trenutnoMaxZdravje;

        zdravje = zdravje + pozdravi;

        if (zdravje > trenutniMax)
        {
            zdravje = trenutniMax;
            Debug.Log($"Zdravje je ze polno ({trenutniMax})!");
        }
        else
        {
            Debug.Log($"Igralec se je pozdravil! Novo zdravje: {zdravje}");
        }
    }

    public void TeleportirajNaStart()
    {
        transform.position = zacetnaPozicija;
        Debug.Log("Igralec teleportiran na zaèetek.");
    }

    public void DodajDenar(int kolicina)
    {
        GameMaster.Instanca.DodajDenar(kolicina);
        Debug.Log("Denar + bonusi: " + GameMaster.Instanca.skupniDenar);
    }

}

using UnityEngine;
using System.Collections.Generic;

public sealed class GameMaster : MonoBehaviour
{
    public static GameMaster Instanca { get; private set; }

    public GameObject trgovinaPanel;
    
    public int trenutnoMaxZdravje;//iz igralec
    public float trenutnaHitrost;//iz igralec
    private IIgralec igralecDekorator; //iz dekoratorja

    public int trenutniLevel = 1;
    public int skupniDenar = 0;
    public int levelDenar = 0;

    public int levelNadgradnjeZdravje = 0;
    public int levelNadgradnjeHitrost = 0;
    public int levelNadgradnjeDenar = 0;
    public int levelNadgradnjeZdravljenje = 0;

    public List<string> kupljeneNadgradnje = new List<string>();

    private void Awake() //Unity ustvari ustvari objekt in sproži awake - namesto konstruktorja
    {
        if (Instanca == null)
        {
            Instanca = this;
            DontDestroyOnLoad(gameObject);
            // TUKAJ inicializiramo osnovnega igralca ob zagonu igre
            PonastaviIgralca();
        }
        else
        {// èe se ustvari še ena instanca se unièi
            Destroy(gameObject);
        }

    }

    public void PonastaviIgralca()
    {
        igralecDekorator = new OsnovniIgralec();
        trenutnoMaxZdravje = igralecDekorator.PridobiMaxZdravje();
        trenutnaHitrost = igralecDekorator.PridobiHitrost();
    }

    //ko pobere denar
    public void DodajDenar(int kolicina)
    {
        int dodanDenar = igralecDekorator.IzracunajPobranDenar(kolicina);
        levelDenar = levelDenar + dodanDenar;
        Debug.Log($"Igralec je dobil: {skupniDenar}");
    }

    //ko konca level
    public void ShraniDenar()
    {
        skupniDenar += levelDenar;
        levelDenar = 0;
        Debug.Log("Level denar prestavljen v skupni denar.");
    }

    //ko umre
    public void IzgubiDenar()
    {
        levelDenar = 0;
        Debug.Log("Ves denar s tega levela je izgubljen!");
    }

    //nakupi nadgradenj
    public void KupiZdravje()
    {
        if (levelNadgradnjeZdravje < 3)
        {
            igralecDekorator = new ZdravjeDekorator(igralecDekorator);
            trenutnoMaxZdravje = igralecDekorator.PridobiMaxZdravje();
            levelNadgradnjeZdravje++;
            kupljeneNadgradnje.Add("Zdravje");
        }
        else
        {
            Debug.Log("Zdravje je že na maksimumu!");
        }
    }

    public void KupiHitrost()
    {
        if (levelNadgradnjeHitrost < 2) 
        {
            igralecDekorator = new HitrostDekorator(igralecDekorator);
            trenutnaHitrost = igralecDekorator.PridobiHitrost();
            levelNadgradnjeHitrost++;
            kupljeneNadgradnje.Add("Hitrost");
        }
        else
        {
            Debug.Log("Hitrost je že na maksimumu!");
        }
    }

    public void KupiVecDenarja() 
    {
        if (levelNadgradnjeDenar < 2)
        {
            igralecDekorator = new DenarDekorator(igralecDekorator);
            levelNadgradnjeDenar++;
            kupljeneNadgradnje.Add("Denar");
        }
        else
        {
            Debug.Log("Bonus za denar je že na maksimumu!");
        }
    }

    public void KupiZdravljenje()
    {
        if (levelNadgradnjeZdravljenje < 1)
        {
            igralecDekorator = new ZdravljenjeDekorator(igralecDekorator);
            levelNadgradnjeZdravljenje++;
            kupljeneNadgradnje.Add("Zdravljenje");
        }
        else
        {
            Debug.Log("Bonus za zdravljenje je že na maksimumu!");
        }
    }

    //za zeleno steno
    public int IzracunajDejanskoZdravljenje(int osnova)
    {
        return igralecDekorator.IzracunajZdravljenje(osnova);
    }

    public void OdpriTrgovino()
    {
        trgovinaPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ZapriTrgovino()
    {
        trgovinaPanel.SetActive(false);
        Time.timeScale = 1.0f;
    }

    // za shranjevanje v bazo
    public string ShraniPodatke()
    {
        PaketZaVBazo paket = new PaketZaVBazo();
        paket.level = trenutniLevel;
        paket.denar = skupniDenar;
        paket.nadgradnje = kupljeneNadgradnje;

        Shraniti<PaketZaVBazo> shranitiVBazo = new Shraniti<PaketZaVBazo>();
        shranitiVBazo.imeIgralca = "Igralec1";
        shranitiVBazo.vsebina = paket;

        return JsonUtility.ToJson(shranitiVBazo);
    }
}


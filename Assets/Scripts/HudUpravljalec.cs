using UnityEngine;
using TMPro;

public class HudUpravljalec : MonoBehaviour
{   
    
    public TextMeshProUGUI levelIzpis;
    public TextMeshProUGUI denarIzpis;
    public TextMeshProUGUI zdravjeIzpis;
    
    private Igralec igralec;


    void Update()
    {
        levelIzpis.text = "Trenutni level: " + GameMaster.Instanca.trenutniLevel;
        denarIzpis.text = "Denar: " + (GameMaster.Instanca.skupniDenar + GameMaster.Instanca.levelDenar).ToString();


        if (igralec == null)
        {
             igralec = Object.FindAnyObjectByType<Igralec>();
        }

        if (igralec != null)
        {
            zdravjeIzpis.text = "Zdravje: " + igralec.zdravje + "/" + GameMaster.Instanca.trenutnoMaxZdravje;
        }
    }
}

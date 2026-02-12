using Newtonsoft.Json; //Branje matrike iz json
using UnityEngine;
using System.IO; //branje json
using System.Threading.Tasks; //za async

public class LevelBuilder : MonoBehaviour // za unity 
{
    public string imeDatoteke;
    private ElementFactory factory;
    public float velikostCelice = 1.0f;
    public GameObject loadingPanel;

    async void Start()
    {
        factory = GetComponent<ElementFactory>(); //ker sta na istem objektu
        imeDatoteke = "level" + GameMaster.Instanca.trenutniLevel + ".json";
        if (loadingPanel != null) loadingPanel.SetActive(true);
        await ZgradiLabirintAsync();
        if (loadingPanel != null) loadingPanel.SetActive(false);
    }

    public async Task ZgradiLabirintAsync()
    {
        string pot = Path.Combine(Application.streamingAssetsPath, imeDatoteke);

        if (File.Exists(pot))
        {
            string jsonVsebina = await Task.Run(() => File.ReadAllText(pot));
            LevelPodatki podatki = JsonConvert.DeserializeObject<LevelPodatki>(jsonVsebina);

            for (int y = 0; y < podatki.visina; y++)
            {
                for (int x = 0; x < podatki.sirina; x++)
                {
                    int tipElementa = podatki.matrika[y][x];

                    //èe je 0 se niè ne zgodi, tla so že
                    if (tipElementa == 0) continue;

                    //izraèun pozicije
                    Vector3 pozicija = new Vector3(x * velikostCelice, -y * velikostCelice, 0);
                    Vector3 korigiranaPozicija = pozicija + new Vector3(0.5f * velikostCelice, -0.5f * velikostCelice, 0);

                    //za 8: start in igralec
                    if (tipElementa == 8)
                    {
                        GameObject startPlosca = factory.Ustvari(8, korigiranaPozicija);
                        startPlosca.transform.SetParent(this.transform);
                        startPlosca.GetComponent<SpriteRenderer>().sortingOrder = 1;
                        
                        GameObject igralec = factory.UstvariIgralca(korigiranaPozicija);
                        igralec.GetComponent<SpriteRenderer>().sortingOrder = 2; //da je nad vsem
                     
                    }
                    else
                    {
                        //ostalo: stene 1-4, zaklad 5, cilj 9
                        GameObject novObjekt = factory.Ustvari(tipElementa, korigiranaPozicija);

                        if (novObjekt != null)
                        {
                            novObjekt.transform.SetParent(this.transform);
                            SpriteRenderer renderer = novObjekt.GetComponent<SpriteRenderer>();
                            if (renderer != null)
                            {
                                // Zakladi in cilj so lahko na plasti 2, stene na 1
                                renderer.sortingOrder = (tipElementa == 5 || tipElementa == 9) ? 2 : 1;
                            }
                        }
                    }
                }
                await Task.Yield();
            }
        }
        else
        {
            Debug.LogError("Datoteke ni na poti: " + pot);
        }
    }
}

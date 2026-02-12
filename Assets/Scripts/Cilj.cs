using UnityEngine;

public class Cilj : LabirintElement, IPoberljivo
{
    public GameObject trgovinaPanel;

    public override void IzvrsiUcinek(Igralec igralec)
    {
        Debug.Log("Prispeli na cilj. Level Zakljucen!");
        Poberi();
        GameMaster.Instanca.ShraniDenar();
        GameMaster.Instanca.ShraniPodatke();
        GameMaster.Instanca.OdpriTrgovino();
    }

    public void Poberi()
    {
        Destroy(gameObject);
    }
}

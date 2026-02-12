using UnityEngine;

public class ZelenaStena : LabirintElement
{
    public int osnovnoZdravljenje = 5;

    public override void IzvrsiUcinek(Igralec igralec)
    {
         int dejanskoZdravljenje = GameMaster.Instanca.IzracunajDejanskoZdravljenje(osnovnoZdravljenje);
         igralec.DodajZdravje(dejanskoZdravljenje);
         Debug.Log($"Stena je ozdravila igralca za: {dejanskoZdravljenje}");
         Debug.Log("Zadeta ZELENA stena.");
    }

}


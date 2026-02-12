using UnityEngine;

public class ModraStena : LabirintElement
{
    public override void IzvrsiUcinek(Igralec igralec)
    {
        igralec.TeleportirajNaStart();
        Debug.Log("Zadeta MODRA stena.");
    }
}

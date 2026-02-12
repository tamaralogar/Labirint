using UnityEngine;

public class RdecaStena : LabirintElement
{
    public int skoda = 10;

    public override void IzvrsiUcinek(Igralec igralec)
    {
        igralec.OdbijZdravje(skoda);
        Debug.Log("Zadeta RDECA stena.");
    }
}


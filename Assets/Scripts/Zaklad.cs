using UnityEngine;

public class Zaklad : LabirintElement, IPoberljivo
{
    public int vrednost = 10;

    public override void IzvrsiUcinek(Igralec igralec)
    {
        igralec.DodajDenar(vrednost);
        Poberi();
    }

    public void Poberi() 
    {
        Debug.Log("Zaklad pobran! Vrednost: " + vrednost);
        Destroy(gameObject);
    }

}


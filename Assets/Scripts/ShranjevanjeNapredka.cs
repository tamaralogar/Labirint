using UnityEngine;
using System.Collections.Generic;

public class ShranjevanjeNapredka
{
    
}

//shranjevanje v bazo
[System.Serializable] // da deluje JsonUtility - pogleda vsebino strukture
public struct Shraniti<T>
{
    public string imeIgralca;
    public T vsebina;
}

[System.Serializable]
public class PaketZaVBazo
{
    public int level;
    public int denar;
    public List<string> nadgradnje;
}



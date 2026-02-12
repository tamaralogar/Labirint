using UnityEngine;

public class ElementFactory : MonoBehaviour // v unity, da je to interactable
{
    public GameObject navadnaStena; //GameObject iz unity - hierarchy/prefabs iz assets
    public GameObject rdecaStena;
    public GameObject modraStena;
    public GameObject zelenaStena;
    public GameObject zaklad;
    public GameObject start;
    public GameObject cilj;
    public GameObject prefabIgralec;
  

    public GameObject Ustvari(int tip, Vector3 pozicija) //tip je kar se prebere iz json datoteke;
                                                         //pozicija se prebere iz matrike iz json datoteke oz. jo izraèuna levelbuilder
    {
        switch (tip)
        {
            case 1: 
                return Instantiate(navadnaStena, pozicija, Quaternion.identity); //Instantate naredi kopijo in mora biti oblike (Prefab, Vector3, Quaternation)
                                                                                 //pozicija pove kam postavi; Quaternion.identity v unity pomeni brez rotacije
            case 2: 
                return Instantiate(rdecaStena, pozicija, Quaternion.identity);
            case 3: 
                return Instantiate(modraStena, pozicija, Quaternion.identity);
            case 4: 
                return Instantiate(zelenaStena, pozicija, Quaternion.identity);
            case 5: 
                return Instantiate(zaklad, pozicija, Quaternion.identity);
            case 8: 
                return Instantiate(start, pozicija, Quaternion.identity);
            case 9: 
                return Instantiate(cilj, pozicija, Quaternion.identity);
            default: 
                return null; // 0 je prazno
        }
    }

    public GameObject UstvariIgralca(Vector3 pozicija)
    {
        return Instantiate(prefabIgralec, pozicija, Quaternion.identity);
    }

}

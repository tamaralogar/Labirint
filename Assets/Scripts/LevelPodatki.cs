using UnityEngine;
using System; // da [Serializable] dela

[Serializable] // da Unity prebere JSON v ta razred
public class LevelPodatki
{
    public string level;
    public int sirina;
    public int visina;
    public int[][] matrika; //izgled levela
}

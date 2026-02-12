using UnityEngine;

//MonoBehaviour je unity class za premikanje, zaznavanje trkov, izrisovanje stvari
public abstract class LabirintElement : MonoBehaviour 
{
    // za stene (Collider)
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        PreveriInIzvrsi(collision.gameObject);
    }

    // Za objekte z 'Is Trigger' (zaklad, start, cilj)
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        PreveriInIzvrsi(other.gameObject);
    }

    private void PreveriInIzvrsi(GameObject obj)
    {
        if (obj.CompareTag("Player"))
        {
            Igralec igralec = obj.GetComponent<Igralec>();
            if (igralec != null)
            {
                IzvrsiUcinek(igralec);
            }
        }
    }

    // Vsak element (stena ali zaklad) še vedno napiše samo svojo logiko tukaj
    public abstract void IzvrsiUcinek(Igralec igralec);
}

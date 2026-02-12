using UnityEngine;

public class IgralecPremikanje : MonoBehaviour
{
    public float hitrost;
    private Rigidbody2D rb;
    private Vector2 smerPremikanja;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.freezeRotation = true;
    }

    void Update()
    {
        // W, A, S, D ali pušèice
        float vnosX = Input.GetAxisRaw("Horizontal");
        float vnosY = Input.GetAxisRaw("Vertical");
        smerPremikanja = new Vector2(vnosX, vnosY).normalized;
    }

    void FixedUpdate()
    {
        hitrost = GameMaster.Instanca.trenutnaHitrost;
        rb.MovePosition(rb.position + smerPremikanja * hitrost * Time.fixedDeltaTime);
    }

}

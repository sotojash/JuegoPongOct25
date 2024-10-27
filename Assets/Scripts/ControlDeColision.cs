using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDeColision : MonoBehaviour
{
    public MoverPelota moverPelota;
    public ControlPuntaje controlPuntaje;

    void ReboteConRaqueta(Collision2D col)
    {
        Vector3 posicionPelota = this.transform.position;
        Vector3 posicionRaqueta = col.gameObject.transform.position;
        float alturaRaqueta = col.collider.bounds.size.y;

        float x;
        if (col.gameObject.name == "Raqueta1")
        {
            x = 1;
        }
        else
        {
            x = -1;
        }

        float y = (posicionPelota.y - posicionRaqueta.y) / alturaRaqueta;

        this.moverPelota.AumentarContadorGolpes();
        this.moverPelota.MovimientoPelota(new Vector2(x, y));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Raqueta1" || collision.gameObject.name == "Raqueta2")
        {
            this.ReboteConRaqueta(collision);
        }
        else if (collision.gameObject.name == "ParedIzquierda")
        {
            this.controlPuntaje.GolJugador2();
            StartCoroutine(this.moverPelota.IniciarPelota(true));
        }
        else if (collision.gameObject.name == "ParedDerecha")
        {
            this.controlPuntaje.GolJugador1();
            StartCoroutine(this.moverPelota.IniciarPelota(false));
        }
    }
}

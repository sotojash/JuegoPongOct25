using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPelota : MonoBehaviour
{
    public float velocidadMovimiento;
    public float velocidadExtraPorGolpe;
    public float velocidadExtraMaxima;

    int contadorGolpes = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(this.IniciarPelota());
    }

    public IEnumerator IniciarPelota(bool comienzaJugador1 = true)
    {
        this.contadorGolpes = 0;

        yield return new WaitForSeconds(2);

        if (comienzaJugador1)
        {
            this.MovimientoPelota(new Vector2(-1, 0));
        }
        else
        {
            this.MovimientoPelota(new Vector2(1, 0));
        }
    }

    public void MovimientoPelota(Vector2 dir)
    {
        dir = dir.normalized;

        float velocidad = this.velocidadMovimiento + this.contadorGolpes * velocidadExtraPorGolpe;

        Rigidbody2D rigidBody2D = this.gameObject.GetComponent<Rigidbody2D>();

        rigidBody2D.velocity = dir * velocidad;
    }

    public void AumentarContadorGolpes()
    {
        if (this.contadorGolpes * this.velocidadExtraPorGolpe <= this.velocidadExtraMaxima)
        {
            this.contadorGolpes++;
        }
    }
}

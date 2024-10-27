using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSonido : MonoBehaviour
{
    public AudioSource sonidoRaqueta;
    public AudioSource sonidoPared;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Raqueta1" || collision.gameObject.name == "Raqueta2")
        {
            this.sonidoRaqueta.Play();
        }
        else
        {
            this.sonidoPared.Play();
        }
    }
}

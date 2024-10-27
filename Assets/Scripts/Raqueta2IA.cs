using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raqueta2IA : MonoBehaviour
{
    public float velocidadMovimiento;
    public GameObject pelota;

    private void FixedUpdate()
    {
        if (Mathf.Abs(this.transform.position.y - pelota.transform.position.y) > 50)
        {
            if (this.transform.position.y < pelota.transform.position.y)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1) * velocidadMovimiento;
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1) * velocidadMovimiento;
            }
        }
        else
        {
            //Establecer velocidad de cero
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }
}

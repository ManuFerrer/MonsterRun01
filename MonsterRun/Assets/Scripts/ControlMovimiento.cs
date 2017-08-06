using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlMovimiento : MonoBehaviour {

    public int contador;
    public  Rigidbody rb;
    public CapsuleCollider cap;
    public Text puntuacion;
    public float velocidad;
    public float Original_Speed;
    public float salto;
    protected bool OnAir;
    public Vector3 movimiento;
    public Vector3 originalmovement;
    public int salud = 100;
    public float movimientoHorizontal;
    protected PlayerController Pc;
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Destructible")
        {
            Destroy(other.gameObject);
            Debug.Log("Ñaam!" + other.name);
            contador = contador + 1;
            puntuacion.text = "" + contador;
        }
      
        else if(other.tag == "Floor")
        {
            OnAir = false;
        }
    }
    
    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cap = GetComponent<CapsuleCollider>();
        contador = 0;
        
        Original_Speed = velocidad;
        velocidad = 5;
        Pc = GetComponent<PlayerController>();
        
    }
    public void FixedUpdate()
    {   // Aqui se recogen los inputs para decirle al ordenador cual es el valor de cada float
        movimientoHorizontal = Pc.direccion;
        puntuacion.text = "" + contador;

        //Aqui creamos un vector que cambia en cada Update.
        movimiento = new Vector3(movimientoHorizontal, 0, 1f);
        originalmovement = movimiento;

        //Aqui aplicamos una fuerza basada en el vector enterior + una velocidad.
        
        rb.AddForce(movimiento * velocidad);


       /* if (Input.GetKeyDown(KeyCode.Space) && OnAir == false) 
        {
            Debug.Log("OnAir =" + OnAir);
            rb.AddForce(Vector3.up * salto, ForceMode.Impulse);
            OnAir = true;
        }
*/
        if(velocidad <= 5)
        {
            Invoke("AumentarVelocidad", 2);
        }




    }

    protected void AumentarVelocidad()
    {
        velocidad = 10;
    }
    
}


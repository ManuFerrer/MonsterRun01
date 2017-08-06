using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    protected ControlMovimiento control;
    protected Vector3 shockPosition;
    protected Animator anim;
    [SerializeField] protected float explosion;
    [SerializeField] protected float freno;
    [SerializeField] protected float aceleracion;
    protected bool IsDie = false;
    Vector3 retroceso;
    public ElementoInteractivo BotonIzquierda;
    public ElementoInteractivo BotonDerecha;
    public ElementoInteractivo BotonTop;
    public float direccion;

    [SerializeField] protected AudioSource slap;
    [SerializeField] protected AudioSource apple;

    // Use this for initialization
    void Start () {
        control = GetComponent<ControlMovimiento>();
        anim = GetComponent<Animator>();
        retroceso = new Vector3(0, 1, 10);
    }
	
	// Update is called once per frame
	void Update () {
        //Sistema Inputs tactil
       
        if (BotonIzquierda.pulsado)
        {
            direccion = -1;
           
        }
        else if (BotonDerecha.pulsado)
        {
            direccion = 1;
            
        }
        else
        {
            direccion = 0;
        }
        if (BotonTop.pulsado)
        {

          control.rb.AddForce(Vector3.up * control.salto, ForceMode.Impulse);

        }
        

        if(control.velocidad >= 10)
        {
            anim.SetBool("IsRunning", true);
        }
        else
        {
            anim.SetBool("IsRunning", false);
        }

        if(IsDie == true)
        {
            SceneManager.LoadScene("MainMenu01",LoadSceneMode.Single);
        }
      
	}
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Caja")
        {
            anim.SetTrigger(1);
            control.cap.enabled = false;

            control.rb.isKinematic = true;
            control.velocidad = 0;
            control.rb.useGravity = false;
            Invoke("restaurar", 2);
            control.contador -= 5;
            anim.SetBool("IsShock", true);
            shockPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z - explosion);
            slap.Play();
            do
            {
                control.movimiento = new Vector3(0, 0, 0);
                transform.position = Vector3.Lerp(transform.position, shockPosition,0.01f);
            } while (Vector3.Distance(transform.position, shockPosition) >= 0.05f);

            
            Destroy(other.gameObject);
            
        }
       
        if(other.tag == "Bomba"  )
        {

            anim.SetTrigger("Roar");
            control.rb.isKinematic = true;
            Debug.Log(control.salud);
            control.salud -= 50;
            Destroy(other.gameObject);
            Invoke("restaurarvelocidad",3);
            control.contador -= 10;
            slap.Play();
            if(control.salud <= 0)
            {
                anim.SetBool("IsDie", true);
                Debug.Log("GAME OVER");
                control.enabled = false;
                control.rb.isKinematic = true;
                control.cap.enabled = false;
                
                Invoke("Die", 5f);
                
            }
            
        }

        if(other.tag == "Donut")
        {
            apple.Play();
            control.Original_Speed = control.velocidad;
            control.velocidad -= freno;
            Invoke("restaurarvelocidad", 1f);
            control.contador += 10;
            
            Destroy(other.gameObject);
           
        }

       if(other.tag == "Lollipop")
        {
            apple.Play();
            control.Original_Speed = control.velocidad;
            control.velocidad += aceleracion;
            Invoke("restaurarvelocidad", 1f);
            control.contador += 20;
            
            Destroy(other.gameObject);
          
        }
    }

    protected void restaurar()
    {
        control.cap.enabled = true;
        control.rb.useGravity = true;
        control.rb.isKinematic = false;
        control.velocidad = control.Original_Speed;
        control.movimiento = control.originalmovement;
        anim.SetBool("IsShock", false);
    }

    protected void restaurarvelocidad()
    {
        control.velocidad = control.Original_Speed;
        control.rb.isKinematic = false;
    }
    protected void Die()
    {
        IsDie = true;
        Destroy(this.gameObject, 4f);
    }

    
}

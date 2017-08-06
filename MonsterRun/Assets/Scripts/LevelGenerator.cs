using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

    [SerializeField] protected GameObject[] Object;
    protected GameObject choseenObject;
    protected Vector3 newposition;
    protected float distance;
    protected float currentDistance;
    protected int contador;
    protected float SpawnDistance;

    [SerializeField] protected int MapLarge;
    //Esto esta bien
    


    protected void Awake()
    {
        choseenObject = Object[Random.Range(0, Object.Length)];

        distance = choseenObject.transform.localScale.z;

        currentDistance = distance;
        do
        {
            //Elige un objeto
            choseenObject = Object[Random.Range(0, Object.Length)];

            // creamos un vector tres donde instanciar el nuevo objeto
            newposition = new Vector3(transform.position.x, transform.position.y, transform.position.z + distance);
            //creamos el nuevo objeto
            Instantiate(choseenObject, newposition, Quaternion.identity);
            //a distancia le sumamos la anterior seteada
            distance =distance + currentDistance;
            // aumentamos el contador
            contador++;

        } while (contador <= MapLarge);
    }

    protected void Start()
    {
        
    }

    protected void Update()
    {
        
    }
}


    


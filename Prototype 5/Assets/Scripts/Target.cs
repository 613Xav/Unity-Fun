using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    //Mets les propriétés physique de l'objet dans la variable targetRb
    private Rigidbody targetRb;
    
    private GameManager gameManagerScript;
    //Rend les variable de particules modifiables dans Unity.
    public ParticleSystem explosionParticle;

    //Variable qui déclare la vitesse minimale
    private float minSpeed = 12;
    //Variable qui déclare la vitesse maximale
    private float maxSpeed = 16;
    //Variable qui décalre la Puissance maximale pour faire pivoter l'objet.
    private float maxTorque = 10;
    
    //Variable qui déclare la portée de l'axe des X
    private float xRange = 4;
    //Variable qui déclare la portée de l'axe des y pour le "Spawn"
    private float ySpawn = -2;

    //Variable changeable dans l'éditeur Unity pour la valeur des points
    public int pointValue;

    // Start is called before the first frame update
    //au début de la partie...
    void Start()
    {
        //Prend les valeurs de propriétés physique de l'objet.
        targetRb = GetComponent<Rigidbody>();
        //Ajoute une force au hazard à l'objet.
        targetRb.AddForce(GenerateRandomForce(),ForceMode.Impulse);
        //Ajoute de la puissance à l'objet pour le faire pivoter
        targetRb.AddTorque(GenerateRandomTorque(), GenerateRandomTorque(),GenerateRandomTorque(),ForceMode.Impulse);
        //Donne une plage d'apparition au hazard à l'objet.
        transform.position = GenerateRandomPosition();
        //Saisie les valeurs du script Game Manager.
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Lors d'une collision
    private void OnTriggerEnter(Collider other)
    {
        //Détruit l'objet
        Destroy(gameObject);
        //Si l'objet n'est pas "Bad",
        if (!gameObject.CompareTag("Bad"))
        {
            //La partie se termine.
            gameManagerScript.GameOver();
        }
    }

    //Lorsque la souris est appuyé...
    private void OnMouseDown()
    {
        //Si la partie est encore active
        if(gameManagerScript.isGameActive)
        {
            //Détruire l'objet
            Destroy(gameObject);
            //faire apparaitre des effets d'explosion
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            //Mets à jour le score du joueur
            gameManagerScript.updateScore(pointValue);
        }

    }

//Fonction qui génère une force au hazard
    Vector3 GenerateRandomForce()
    {
        //Retourne des valeurs au hazard entre 12 et 16
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

//Fonction qui génère une puissance au hazard à l'objet.
    float GenerateRandomTorque()
    {
        //Retourne une valeur au hazard entre -10 et 10
        return Random.Range(-maxTorque, maxTorque);
    }
//Fonction qui génère une positio au hazard
    Vector3 GenerateRandomPosition()
    {
        //Retourne une valeur x y et z au hazard
        return new Vector3(Random.Range(-xRange, xRange), ySpawn);
    }
}

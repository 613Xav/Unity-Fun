using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Entre la longueur du réseau prefabs dans la variable targets.
    public List<GameObject> targets;
    //Variable pour le texte du score
    public TextMeshProUGUI scoreText;
    //Variable pour le texte de fin de partie
    public TextMeshProUGUI gameOverText;
    //Variable pour le texte d'acceuil
    public GameObject titleScreen;
    //Variable pour le score
    private int score;
    //Donne une valeur positive ou négative pour la situation de partie. 
    public bool isGameActive;
    //Bouton pour recommencer la par tie
    public Button restartButton;


    //Défini le rythme des apparitions     
    private float spawnrate = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

//Fonction qui fait apparaitre des cibles.
    IEnumerator SpawnTarget()
    {
        //Pendant que la partie est active...
        while (isGameActive)
        {
            //Attendre la valeur de la variable "Spawnrate".
            yield return new WaitForSeconds(spawnrate);
            //choisir un objet au hazard
            int randomIndex = Random.Range(0,targets.Count);
            //Faire appparaitre un objet au hazard.
            Instantiate(targets[randomIndex]);
        }
    }
//Fonction pour le score.
    public void updateScore(int scoreToAdd)
    {
        //score = score + le score à ajouter.
        score += scoreToAdd;
        //Mets notre score en texte.
        scoreText.text = "Score: " + score;
    }

//Fonction pour la fin de partie
    public void GameOver()
    {
        //Donne une valeur positive au bouton recommencer
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        //Donne une valeur négative à la situation de partie
        isGameActive = false;
    }

//Fontion pour recommencer la partie
    public void RestartGame()
    {
        //Recharge la scène de jeu
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

//Fonction pour la difficulté..
    public void StartGame(int difficulty)
    {
        //Donne une valeur positive au jeu.
        isGameActive = true;
        //Le rythme d'apparition est en relation avec  la difficulté.
        spawnrate /= difficulty;
        //L'écran d'acceuil se désactive
        titleScreen.gameObject.SetActive(false);
        //réinitialise le score.
        updateScore(0);
        //Fait jouer la fonction qui fait apparaitre les objets.
        StartCoroutine(SpawnTarget());
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    //Les valeur de difficultés sont changeables dans l'éditeur Unity
    public int difficulty;
    //Inclue le GameManger dans le script  
    private GameManager gameManager;
    //Inclue les valeurs des bouttons dans le script
    private Button button;
    
    // Start is called before the first frame update
    void Start()
    {
        //Prend les valeurs du boutton
        button = GetComponent<Button>();
        //Insère les valeurs du gameManager dans la variable gameManager
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        //Changer la difficulté selon le boutton appuyé 
        button.onClick.AddListener(setDifficulty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
//Fonction pour la difficulté
    void setDifficulty()
    {
        //change la difficulté du jeu
        gameManager.StartGame(difficulty);
        //Inscrit la difficulté du jeu dans la console.
        Debug.Log(button.gameObject.name + " was clicked!");
    }
}

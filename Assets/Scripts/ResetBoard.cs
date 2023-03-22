using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBoard : MonoBehaviour
{
    private GameObject cardGrid;

    private ShuffleCards shuffler;
    GameObject gameOverScreen;
    GameObject gameOverText;

    void Awake()
    {
        gameOverScreen = GameObject.Find("GameOverScreen");
        gameOverText = GameObject.Find("GameOverText");
    }

    // Start is called before the first frame update
    void Start()
    {
        cardGrid = GameObject.Find("CardGrid");
        shuffler = cardGrid.GetComponent<ShuffleCards>();
    }

    public void Reset()
    {
        foreach (Transform child in cardGrid.GetComponentsInChildren<Transform>())
        {
            if (!child.name.Equals("CardGrid"))
            {
                Destroy(child.gameObject);
            }
        }

        shuffler.Shuffle(shuffler.cardsArray);
        gameOverScreen.SetActive(false);
        gameOverText.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RememberCards : MonoBehaviour
{
    public ArrayList currentGuess = new ArrayList();
    public ArrayList cardNames = new ArrayList();
    private GameObject cardGrid;

    GameObject gameOverScreen;
    GameObject gameOverText;
    void Start()
    {
        cardGrid = GameObject.Find("CardGrid");
        gameOverScreen = GameObject.Find("GameOverScreen");
        gameOverText = GameObject.Find("GameOverText");
        gameOverScreen.SetActive(false);
        gameOverText.SetActive(false);
    }
    public void makeGuess(GameObject card)
    {
        if (currentGuess.Count == 0)
        {
            currentGuess.Add(card);
            cardNames.Add(card.name);
        }
        else if (currentGuess.Count == 1)
        {
            if (!cardNames.Contains(card.name))
            {
                currentGuess.Add(card);
                StartCoroutine(ActivateCardsBack());
            }
            if (cardNames.Contains(card.name))
            {
                currentGuess.Clear();
                cardNames.Clear();
                checkIfGameOver();
            }
        }
        else if (currentGuess.Count > 1)
        {
            GameObject back = card.transform.Find("back").gameObject;
            back.SetActive(true);
        }
    }

    IEnumerator ActivateCardsBack()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        foreach (GameObject item in currentGuess)
        {
            GameObject back = item.transform.Find("back").gameObject;
            back.SetActive(true);
        }
        currentGuess.Clear();
        cardNames.Clear();
    }


    void checkIfGameOver()
    {
        int counter = 0;
        // check if any card still is not guessed
        foreach (Transform child in cardGrid.GetComponentsInChildren<Transform>())
        {
            if (child.name.Equals("back"))
            {
                if (child.gameObject.activeInHierarchy)
                {
                    counter++;
                }
            }
        }

        // if there are no unflipped cards, display game over screen
        if (counter == 0)
        {
            gameOverScreen.SetActive(true);
            gameOverText.SetActive(true);
        }
    }
}


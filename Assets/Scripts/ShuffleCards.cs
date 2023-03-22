using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuffleCards : MonoBehaviour
{
    [SerializeField]
    public GameObject[] cardsArray;

    private BoxCollider2D gridCollider;

    // Start is called before the first frame update
    void Start()
    {
        gridCollider = GetComponent<BoxCollider2D>();

        Shuffle(cardsArray);
    }

    //Randomly order cards
    public void Shuffle(GameObject[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            int rnd = Random.Range(0, arr.Length);
            var temp = arr[rnd];
            arr[rnd] = arr[i];
            arr[i] = temp;
        }

        InstantiateCards();
    }

    void InstantiateCards()
    {
        Vector2 cardPosition = gridCollider.transform.position;
        cardPosition.x -= gridCollider.bounds.size.x / 2;
        cardPosition.y -= gridCollider.bounds.size.y / 2;
        cardPosition.y += 1.35f;

        var dx = gridCollider.bounds.size.x / 4;
        var dy = gridCollider.bounds.size.y / 4;

        for (int y = 0; y < 4; y++)
        {
            for (int x = 0; x < 4; x++)
            {
                GameObject newCard = Instantiate(cardsArray[x + 4 * y], cardPosition, Quaternion.identity, transform);
                cardPosition.x += dx;
            }
            cardPosition.x = transform.position.x - gridCollider.bounds.size.x / 2;
            cardPosition.y += dy;
        }
    }
}

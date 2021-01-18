using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    int diffulty = 1;
    int currentImage = 0;
    readonly int[] defaultPieces = {0,0,0,0,
                                    1,1,1,1,
                                    2,2,2,2,
                                    3,3,3,3};
    int[] newPieces = new int[16];
    int[] selectedPieces = new int[16];
    int pieceSelector = 0;
    int currentMove = 0;
    public Image help;
    public Sprite[] moves;
    public Sprite[] helpImages;
    public GameManager manager;
    public GameObject[] pieceBuilders;
    public GameObject warning;
    public GameObject self_holder;



    // Start is called before the first frame update
    void Start()
    {
        help.sprite = helpImages[currentImage];
        selectedPieces = defaultPieces;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeDifficulty(string newDifficulty)
    {
        diffulty = int.Parse(newDifficulty);
    }

    public void Play()
    {
        manager.Play(diffulty, selectedPieces);
    }

    public void ChangeImage(bool next)
    {
        if (next)
        {
            if(currentImage < helpImages.Length-1)
            {
                currentImage++;
            }
        }
        else
        {
            if(currentImage > 0)
            {
                currentImage--;
            }
        }

        help.sprite = helpImages[currentImage];

    }

    public void SelectBuilder(int selected)
    {
        (pieceBuilders[pieceSelector].GetComponentsInChildren(typeof(Image))[currentMove + 1] as Image).color = Color.white;
        pieceSelector = selected;
        currentMove = 0;
        (pieceBuilders[pieceSelector].GetComponentsInChildren(typeof(Image))[currentMove + 1] as Image).color = Color.gray;
    }

    public void SetPiece(int move)
    {
        newPieces[pieceSelector * 4 + currentMove] = move;
        (pieceBuilders[pieceSelector].GetComponentsInChildren(typeof(Image))[currentMove + 1] as Image).sprite = moves[move];
        (pieceBuilders[pieceSelector].GetComponentsInChildren(typeof(Image))[currentMove + 1] as Image).color = Color.white;
        currentMove = (currentMove+1)%4;
        (pieceBuilders[pieceSelector].GetComponentsInChildren(typeof(Image))[currentMove + 1] as Image).color = Color.gray;
    }

    public void CheckPiece()
    {
        for(int j = 0; j<4; j++)
        {
            for(int i = 1; i<4; i++)
            {
                if (newPieces[j * 4] == newPieces[((j + i) % 4) * 4] &&
                    newPieces[(j * 4) + 1] == newPieces[(((j + i) % 4) * 4) + 1] &&
                    newPieces[(j * 4) + 2] == newPieces[(((j + i) % 4) * 4) + 2] &&
                    newPieces[(j * 4) + 3] == newPieces[(((j + i) % 4) * 4) + 3])
                {
                    (warning.GetComponentInChildren(typeof(Text)) as Text).text = "Two pieces cannot be equal.";
                    StartCoroutine(ShowWarning());
                    return;

                }
            }
        }
        selectedPieces = newPieces;
        self_holder.SetActive(false);
    }

    public void Cancel()
    {
        newPieces = selectedPieces;
    }

    IEnumerator ShowWarning()
    {
        warning.SetActive(true);
        yield return new WaitForSeconds(2f);
        warning.SetActive(false);
    }
}

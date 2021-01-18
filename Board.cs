using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public Piece p1,p2,p3,p4,p5,p6,p7,p8,p9;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReceiveMovement(int position, int movement, bool opponent = false)
    {
        switch (position)
        {
            case (1):
                p1.ReceiveMovement(movement, opponent);
                break;
            case (2):
                p2.ReceiveMovement(movement, opponent);
                break;
            case (3):
                p3.ReceiveMovement(movement, opponent);
                break;
            case (4):
                p4.ReceiveMovement(movement, opponent);
                break;
            case (5):
                p5.ReceiveMovement(movement, opponent);
                break;
            case (6):
                p6.ReceiveMovement(movement, opponent);
                break;
            case (7):
                p7.ReceiveMovement(movement, opponent);
                break;
            case (8):
                p8.ReceiveMovement(movement, opponent);
                break;
            case (9):
                p9.ReceiveMovement(movement, opponent);
                break;
        }
    }

    public void ToggleButton(int position, bool toggle)
    {
        switch (position)
        {
            case (1):
                p1.ToggleButton(toggle);
                break;
            case (2):
                p2.ToggleButton(toggle);
                break;
            case (3):
                p3.ToggleButton(toggle);
                break;
            case (4):
                p4.ToggleButton(toggle);
                break;
            case (5):
                p5.ToggleButton(toggle);
                break;
            case (6):
                p6.ToggleButton(toggle);
                break;
            case (7):
                p7.ToggleButton(toggle);
                break;
            case (8):
                p8.ToggleButton(toggle);
                break;
            case (9):
                p9.ToggleButton(toggle);
                break;
        }
    }

    public void ToggleBoard(bool toggle)
    {
        p1.ToggleButton(toggle);
        p2.ToggleButton(toggle);
        p3.ToggleButton(toggle);
        p4.ToggleButton(toggle);
        p5.ToggleButton(toggle);
        p6.ToggleButton(toggle);
        p7.ToggleButton(toggle);
        p8.ToggleButton(toggle);
        p9.ToggleButton(toggle);
    }

    public void ResetButton(int position)
    {
        switch (position)
        {
            case (1):
                p1.ResetButton();
                break;
            case (2):
                p2.ResetButton();
                break;
            case (3):
                p3.ResetButton();
                break;
            case (4):
                p4.ResetButton();
                break;
            case (5):
                p5.ResetButton();
                break;
            case (6):
                p6.ResetButton();
                break;
            case (7):
                p7.ResetButton();
                break;
            case (8):
                p8.ResetButton();
                break;
            case (9):
                p9.ResetButton();
                break;
        }
    }

    public void SelectButton(int position)
    {
        switch (position)
        {
            case (1):
                p1.Select();
                break;
            case (2):
                p2.Select();
                break;
            case (3):
                p3.Select();
                break;
            case (4):
                p4.Select();
                break;
            case (5):
                p5.Select();
                break;
            case (6):
                p6.Select();
                break;
            case (7):
                p7.Select();
                break;
            case (8):
                p8.Select();
                break;
            case (9):
                p9.Select();
                break;
        }
    }
}

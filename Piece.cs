using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Piece : MonoBehaviour
{
    Image image, image1, image2, image3, image4;
    Button button;
    public Sprite s1, s2, s3, s4, defaultSprite;
    int currentMov = 0;
    // Start is called before the first frame update
    void Start()
    {
        image = gameObject.GetComponentsInChildren(typeof(Image))[0] as Image;
        image1 = gameObject.GetComponentsInChildren(typeof(Image))[1] as Image;
        image2 = gameObject.GetComponentsInChildren(typeof(Image))[2] as Image;
        image3 = gameObject.GetComponentsInChildren(typeof(Image))[3] as Image;
        image4 = gameObject.GetComponentsInChildren(typeof(Image))[4] as Image;
        button = gameObject.GetComponentInParent(typeof(Button)) as Button;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Create(int mov1, int mov2, int mov3, int mov0)
    {

    }

    public void ToggleButton(bool toggle)
    {
        button.interactable = toggle;
    }

    public void ReceiveMovement(int movement, bool opponent)
    {
        switch (movement)
        {
            case (0):
                 ChangeSprite(s1, opponent);
                break;
            case (1):
                ChangeSprite(s2, opponent);
                break;
            case (2):
                ChangeSprite(s3, opponent);
                break;
            case (3):
                ChangeSprite(s4, opponent);
                break;

        }

    }

    void ChangeSprite(Sprite nextSprite, bool opponent)
    {
        Color color = opponent ? Color.blue : Color.red;
        switch (currentMov)
        {
            case (0):
                image1.sprite = nextSprite;
                image1.color = color;
                currentMov++;
                Select();
                break;
            case (1):
                image2.sprite = nextSprite;
                image2.color = color;
                currentMov++;
                Select();
                break;
            case (2):
                image3.sprite = nextSprite;
                image3.color = color;
                currentMov++;
                Select();
                break;
            case (3):
                image4.sprite = nextSprite;
                image4.color = color;
                currentMov = 0;
                if(opponent)
                    ToggleButton(false);
                image.color = Color.gray;
                
                break;
        }
    }

    public void ResetButton()
    {
        currentMov = 0;
        image1.sprite = defaultSprite;
        image1.color = Color.white;
        image2.sprite = defaultSprite;
        image2.color = Color.white;
        image3.sprite = defaultSprite;
        image3.color = Color.white;
        image4.sprite = defaultSprite;
        image4.color = Color.white;
        ToggleButton(true);
        image.color = Color.white;
    }

    public void Select()
    {
        button.Select();
    }
}

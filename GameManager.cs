using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    int screen_height;
    int screen_width;
    int grid_height;
    int grid_width;

    private int[,] command = new int[2,4];
    private PieceMovs movements;
    private int position;
    private bool idle = true;
    private Dictionary<int, PieceMovs> pieces = new Dictionary<int, PieceMovs>();
    private Dictionary<int, PieceMovs> awayPieces = new Dictionary<int, PieceMovs>();
    private int boardPos = 0;
    private bool home = true;
    private bool attacking;
    private int home_points;
    private int away_points;
    private bool stealing = false;
    private int blocked_pieces = 0;
    bool botBool = true;
    bool playing = false;
    WaitForSeconds shortWait = new WaitForSeconds(0.1f);

    public Board home_board;
    public Board away_board;

    public Text home_points_t;
    public Text away_points_t;

    public GameObject menu_holder;
    public GameObject game_holder;
    public GameObject pause_holder;
    public GameObject[] pieceHelpers;
    public Sprite[] moveSprites;

    public Bot bot;

    List<PieceMovs> keys = new List<PieceMovs>();
    List<PieceMovs> possible_movs;

    // Start is called before the first frame update
    void Start()
    {
        screen_height = Screen.height;
        screen_width = Screen.width;
        grid_height = screen_height / 12;
        grid_width = screen_width / 5;

    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetMouseButtonDown(0) || Input.touchCount > 0 && canPlay)
        //{
            //float x, y;
            //if(Input.touchCount > 0)
            //{
            //    x = Input.GetTouch(0).position.x;
            //    y = Input.GetTouch(0).position.y;
            //}
            //else
            //{
            //    x = Input.mousePosition.x;
            //    y = Input.mousePosition.y;
            //}
        if (idle || !playing)
            return;
        idle = true;
        if(position < 20)
        {
            if(boardPos != -1 && pieces.Count < 4)
                InsertCommand( GetCommand(position), boardPos);
        }else if(position < 40)
        {
            if(movements.Count() > 0 && !awayPieces.ContainsKey(boardPos)) //Possível tratamento muito complicado
            {
                ClearMovements();
            }
            home = true;
            boardPos = GetBoardPosition(position - 20);
            if (pieces.TryGetValue(boardPos, out PieceMovs piece)){
                ClearMovements();
                pieces.Remove(boardPos);
                possible_movs.Add(piece);
            }
            home_board.SelectButton(boardPos);
        }
        else if (!attacking)
        {
            if (movements.Count() > 0 && !awayPieces.ContainsKey(boardPos))
            {
                ClearMovements();
            }
            home = false;
            boardPos = GetBoardPosition(position - 40) + 9;
            if (awayPieces.ContainsKey(boardPos) || stealing)
            {
                boardPos = -1;
                return;
            }
            if (pieces.TryGetValue(boardPos, out PieceMovs piece))
            {
                stealing = false;
                ClearMovements();
                pieces.Remove(boardPos);
                possible_movs.Add(piece);
            }
            away_board.SelectButton(boardPos-9);
        }

        //}

    }


    public void Play(int difficulty, int[] selectedPieces)
    {
        keys.Add(new PieceMovs(selectedPieces[0], selectedPieces[1], selectedPieces[2], selectedPieces[3]));
        keys.Add(new PieceMovs(selectedPieces[4], selectedPieces[5], selectedPieces[6], selectedPieces[7]));
        keys.Add(new PieceMovs(selectedPieces[8], selectedPieces[9], selectedPieces[10], selectedPieces[11]));
        keys.Add(new PieceMovs(selectedPieces[12], selectedPieces[13], selectedPieces[14], selectedPieces[15]));
        possible_movs = new List<PieceMovs>(keys);

        for(int i = 0; i<16; i++)
        {
            (pieceHelpers[Mathf.FloorToInt(i / 4)].GetComponentsInChildren(typeof(Image))[i%4] as Image).sprite = moveSprites[selectedPieces[i]];
        }

        attacking = Random.Range(0, 2) == 0;

        away_points = 0;
        home_points = 0;

        menu_holder.SetActive(false);
        game_holder.SetActive(true);

        StartCoroutine(SetBoard());
        playing = true;
        bot.Initialize(difficulty, !attacking, this);
    }

    public void GetGridPosition(int newPosition)
    {
        position = newPosition;
        idle = false;

    }

    int GetCommand(int position)
    {
        int command = 0;
        switch (position)
        {
            //Command Down
            case (2):
            case (7):
                command = 0;
                break;
            //Command Left
            case (6):
            case (11):
                command = 1;
                break;
            //Command Right
            case (8):
            case (13):
                command = 2;
                break;
            //Command Up
            case (12):
            case (17):
                command = 3;
                break;
            //Command Clear
            case (19):
                command = 4;
                break;
            default:
                command = -1;
                break;

        }
        return command;
    }
    int GetBoardPosition(int position)
    {
        int boardPos = -1;
        switch (position)
        {
            //  | - | - | - |
            //  | - | - | - |
            //  | x | - | - |
            case (1):
                boardPos = 1;
                break;

            //  | - | - | - |
            //  | - | - | - |
            //  | - | x | - |
            case (2):
                boardPos = 2;
                break;

            //  | - | - | - |
            //  | - | - | - |
            //  | - | - | x |
            case (3):
                boardPos = 3;
                break;

            //  | - | - | - |
            //  | x | - | - |
            //  | - | - | - |
            case (6):
                boardPos = 4;
                break;

            //  | - | - | - |
            //  | - | x | - |
            //  | - | - | - |
            case (7):
                boardPos = 5;
                break;

            //  | - | - | - |
            //  | - | - | x |
            //  | - | - | - |
            case (8):
                boardPos = 6;
                break;

            //  | x | - | - |
            //  | - | - | - |
            //  | - | - | - |
            case (11):
                boardPos = 7;
                break;

            //  | - | x | - |
            //  | - | - | - |
            //  | - | - | - |
            case (12):
                boardPos = 8;
                break;

            //  | - | - | x |
            //  | - | - | - |
            //  | - | - | - |
            case (13):
                boardPos = 9;
                break;
                
        }
        return boardPos;
    }

    void InsertCommand(int command, int position)
    {
        if (command == 4)
        {
            ClearMovements();
            return;
        }
        if (command == -1)
            return;

        if (home)
        {
            home_board.ReceiveMovement(position, command);
        }
        else
        {
            away_board.ReceiveMovement(position-9, command);
        }

        movements.Add(command);

        if(movements.Count() == 4)
        {
            CheckPiece();
        }

    }

    void ClearMovements()
    {
        if (home)
        {
            home_board.ResetButton(boardPos);
        }
        else
        {
            away_board.ResetButton(boardPos-9);
        }

        movements.Clear();
  
    }

    void CheckPiece()
    {
        if (possible_movs.Contains(movements))
        {
            if(awayPieces.ContainsKey(boardPos))
            {
                ChangeSides();
                return;
            }
            if (!home)
                stealing = true;

            if(botBool)
                bot.ReceivePiece(boardPos, movements);
            pieces.Add(boardPos, movements);
            possible_movs.Remove(movements);
            movements.Clear();
            boardPos = -1;

        }else
        {
            ClearMovements();
            if (home)
            {
                home_board.SelectButton(boardPos);
            }
            else
            {
                away_board.SelectButton(boardPos-9);
            }
        }

        if (pieces.Count == 4 && attacking)
        {
            SendAttack();
        }
    }

    void SendAttack()
    {
        bool canAttack = CanAttack(pieces.Keys);
        foreach (KeyValuePair<int, PieceMovs> piece in pieces)
        {
            if (!canAttack)
                break;
            if (!awayPieces.ContainsKey(piece.Key + 9))
            {
                home_points += piece.Value.value;
                home_points_t.text = "Home: " + home_points;
            }
            else
            {
                blocked_pieces++;
            }
        }

        StopFor(0.5f);

        if (home_points >= 100)
        {
            FinishGame();
            return;
        }else if(blocked_pieces >= 15)
        {
            ChangeSides();
            return;
        }

        ClearBoard();
        possible_movs = new List<PieceMovs>(keys);
        awayPieces = new Dictionary<int, PieceMovs>();
        pieces.Clear();
        boardPos = -1;
    }

    bool CanAttack(Dictionary<int, PieceMovs>.KeyCollection testing, bool away = false)
    {
        int normalizer = away ? 9 : 0;
        foreach(int position in testing)
        {
            switch (position)
            {
                case (1):
                    if((!pieces.ContainsKey( normalizer + 2)) && (!pieces.ContainsKey( normalizer + 4)))
                        return false;
                    break;
                case (2):
                    if ((!pieces.ContainsKey( normalizer + 1)) && (!pieces.ContainsKey( normalizer + 3)) && (!pieces.ContainsKey( normalizer + 5)))
                        return false;
                    break;
                case (3):
                    if ((!pieces.ContainsKey( normalizer + 2)) && (!pieces.ContainsKey( normalizer + 6)))
                        return false;
                    break;
                case (4):
                    if ((!pieces.ContainsKey( normalizer + 1)) && (!pieces.ContainsKey( normalizer + 5)) && (!pieces.ContainsKey( normalizer + 7)))
                        return false;
                    break;
                case (5):
                    if ((!pieces.ContainsKey( normalizer + 2)) && (!pieces.ContainsKey( normalizer + 4)) && (!pieces.ContainsKey( normalizer + 6)) && (!pieces.ContainsKey( normalizer + 8)))
                        return false;
                    break;
                case (6):
                    if ((!pieces.ContainsKey( normalizer + 3)) && (!pieces.ContainsKey( normalizer + 5)) && (!pieces.ContainsKey( normalizer + 9)))
                        return false;
                    break;
                case (7):
                    if ((!pieces.ContainsKey( normalizer + 0)) && (!pieces.ContainsKey( normalizer + 8)))
                        return false;
                    break;
                case (8):
                    if ((!pieces.ContainsKey( normalizer + 5)) && (!pieces.ContainsKey( normalizer + 7)) && (!pieces.ContainsKey( normalizer + 9)))
                        return false;
                    break;
                case (9):
                    if ((!pieces.ContainsKey( normalizer + 6)) && (!pieces.ContainsKey( normalizer + 8)))
                        return false;
                    break;
            }
        }
        return true;
    }

    IEnumerator SetBoard()
    {
        yield return shortWait;
        away_board.ToggleBoard(!attacking);
        if(botBool)
            bot.Play();
    }

    public void ReceivePiece(int position, PieceMovs newPiece)
    {
        bool away = position > 9;
        Board board = away ? away_board : home_board;
        awayPieces.Add(position, newPiece);
        position = away ? position - 9 : position;
        board.ReceiveMovement(position, newPiece.first, true);
        board.ReceiveMovement(position, newPiece.second, true);
        board.ReceiveMovement(position, newPiece.third, true);
        board.ReceiveMovement(position, newPiece.forth, true);
        if(awayPieces.Count == 4 && !attacking)
        {
            ReceiveAttack();
        }

    }

    void ReceiveAttack()
    {
        bool canAttack = CanAttack(awayPieces.Keys);
        foreach (KeyValuePair<int, PieceMovs> piece in awayPieces)
        {
            if (!canAttack)
                break;
            if (!pieces.ContainsKey(piece.Key - 9))
            {
                away_points += piece.Value.value;
                away_points_t.text = "Away: " + away_points;
            }
            else
            {
                blocked_pieces++;
            }

        }
        StopFor(0.5f);
        if (away_points >= 100)
        {
            FinishGame();
            return;
        } else if (blocked_pieces >= 15)
        {
            ChangeSides();
            return;
        }

        ClearBoard();
        possible_movs = new List<PieceMovs>(keys);
        pieces.Clear();
        awayPieces.Clear();
        stealing = false;
    }


    public void ChangeSides(bool receiving = false)
    {
        if (!receiving)
            bot.ChangeSides();
        attacking = !attacking;
        possible_movs = new List<PieceMovs>(keys);
        pieces.Clear();
        awayPieces.Clear();
        ClearBoard();
        blocked_pieces = 0;
        stealing = false;
    }

    void ClearBoard()
    {
        for (int i = 1; i <= 18; i++)
        {
            home = i <= 9;
            boardPos = i;
            ClearMovements();
        }
        away_board.ToggleBoard(!attacking);
    }

    public void FinishGame()
    {
        bot.Continue();
        playing = false;
        stealing = false;
        blocked_pieces = 0;
        possible_movs = new List<PieceMovs>(keys);
        pieces.Clear();
        awayPieces.Clear();
        home_points = 0;
        away_points = 0;
        away_points_t.text = "Away: " + away_points;
        home_points_t.text = "Home: " + home_points;
        attacking = true; //Mudar!
        ClearBoard();
        if (botBool)
            bot.Finish();
        menu_holder.SetActive(true);
        game_holder.SetActive(false);
        pause_holder.SetActive(false);

    }

    public void Pause(bool pause)
    {
        pause_holder.SetActive(pause);
        if (pause)
            bot.Stop();
        else
            bot.Continue();
    }

    IEnumerator StopFor(float time)
    {
        bot.Stop();
        yield return new WaitForSeconds(time);
        bot.Continue();
    }


}

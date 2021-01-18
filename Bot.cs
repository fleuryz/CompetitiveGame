using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{
    int[][,] PiecesBook = {
                        new int[,] { {1,1,1,1 } ,{2,2,2,2 } ,{3,3,3,3 } ,{0,0,0,0 } },
                        new int[,] { {1,1,1,1 } ,{2,2,2,2 } ,{3,3,3,3 } ,{0,0,0,3 } },
                        new int[,] { {1,1,1,1 } ,{2,2,2,2 } ,{3,3,3,3 } ,{0,0,3,3 } },
                        new int[,] { {1,1,1,1 } ,{2,2,2,2 } ,{3,3,3,3 } ,{0,0,2,3 } },
                        new int[,] { {1,1,1,1 } ,{2,2,2,2 } ,{3,3,3,3 } ,{1,2,3,0 } },

                        new int[,] { {1,1,1,1 } ,{2,2,2,2 } ,{3,3,3,0 } ,{0,0,0,3 } },
                        new int[,] { {1,1,1,1 } ,{2,2,2,2 } ,{3,3,3,0 } ,{0,0,3,3 } },
                        new int[,] { {1,1,1,1 } ,{2,2,2,2 } ,{3,3,3,0 } ,{0,0,2,3 } },
                        new int[,] { {1,1,1,1 } ,{2,2,2,2 } ,{3,3,3,0 } ,{1,2,3,0 } },

                        new int[,] { {1,1,1,1 } ,{2,2,2,2 } ,{3,3,0,0 } ,{0,0,3,3 } },
                        new int[,] { {1,1,1,1 } ,{2,2,2,2 } ,{3,3,0,0 } ,{0,0,2,3 } },
                        new int[,] { {1,1,1,1 } ,{2,2,2,2 } ,{3,3,0,0 } ,{1,2,3,0 } },

                        new int[,] { {1,1,1,1 } ,{2,2,2,2 } ,{3,3,2,0 } ,{0,0,2,3 } },
                        new int[,] { {1,1,1,1 } ,{2,2,2,2 } ,{3,3,2,0 } ,{1,2,3,0 } },

                        new int[,] { {1,1,1,1 } ,{2,2,2,2 } ,{3,1,2,0 } ,{1,2,3,0 } },
//                      ---------------------------------------------------
                        new int[,] { {1,1,1,1 } ,{2,2,2,0 } ,{3,3,3,0 } ,{0,0,0,3 } },
                        new int[,] { {1,1,1,1 } ,{2,2,2,0 } ,{3,3,3,0 } ,{0,0,3,3 } },
                        new int[,] { {1,1,1,1 } ,{2,2,2,0 } ,{3,3,3,0 } ,{0,0,2,3 } },
                        new int[,] { {1,1,1,1 } ,{2,2,2,0 } ,{3,3,3,0 } ,{1,2,3,0 } },

                        new int[,] { {1,1,1,1 } ,{2,2,2,0 } ,{3,3,0,0 } ,{0,0,3,3 } },
                        new int[,] { {1,1,1,1 } ,{2,2,2,0 } ,{3,3,0,0 } ,{0,0,2,3 } },
                        new int[,] { {1,1,1,1 } ,{2,2,2,0 } ,{3,3,0,0 } ,{1,2,3,0 } },

                        new int[,] { {1,1,1,1 } ,{2,2,2,0 } ,{3,3,2,0 } ,{0,0,2,3 } },
                        new int[,] { {1,1,1,1 } ,{2,2,2,0 } ,{3,3,2,0 } ,{1,2,3,0 } },

                        new int[,] { {1,1,1,1 } ,{2,2,2,0 } ,{3,1,2,0 } ,{1,2,3,0 } },
//                      ---------------------------------------------------
                        new int[,] { {1,1,1,1 } ,{2,2,0,0 } ,{3,3,0,0 } ,{0,0,3,3 } },
                        new int[,] { {1,1,1,1 } ,{2,2,0,0 } ,{3,3,0,0 } ,{0,0,2,3 } },
                        new int[,] { {1,1,1,1 } ,{2,2,0,0 } ,{3,3,0,0 } ,{1,2,3,0 } },

                        new int[,] { {1,1,1,1 } ,{2,2,0,0 } ,{3,3,2,0 } ,{0,0,2,3 } },
                        new int[,] { {1,1,1,1 } ,{2,2,0,0 } ,{3,3,2,0 } ,{1,2,3,0 } },

                        new int[,] { {1,1,1,1 } ,{2,2,0,0 } ,{3,1,2,0 } ,{1,2,3,0 } },
//                      ---------------------------------------------------
                        new int[,] { {1,1,1,1 } ,{2,2,3,0 } ,{3,3,2,0 } ,{0,0,2,3 } },
                        new int[,] { {1,1,1,1 } ,{2,2,3,0 } ,{3,3,2,0 } ,{1,2,3,0 } },

                        new int[,] { {1,1,1,1 } ,{2,2,3,0 } ,{3,1,2,0 } ,{1,2,3,0 } },
//                      ---------------------------------------------------
                        new int[,] { {1,1,1,1 } ,{2,1,3,0 } ,{3,1,2,0 } ,{1,2,3,0 } },
//                      ---------------------------------------------------
//                      ---------------------------------------------------
                        new int[,] { {1,1,1,2 } ,{2,2,2,0 } ,{3,3,3,0 } ,{0,0,0,3 } },
                        new int[,] { {1,1,1,2 } ,{2,2,2,0 } ,{3,3,3,0 } ,{0,0,3,3 } },
                        new int[,] { {1,1,1,2 } ,{2,2,2,0 } ,{3,3,3,0 } ,{0,0,2,3 } },
                        new int[,] { {1,1,1,2 } ,{2,2,2,0 } ,{3,3,3,0 } ,{1,2,3,0 } },

                        new int[,] { {1,1,1,2 } ,{2,2,2,0 } ,{3,3,0,0 } ,{0,0,3,3 } },
                        new int[,] { {1,1,1,2 } ,{2,2,2,0 } ,{3,3,0,0 } ,{0,0,2,3 } },
                        new int[,] { {1,1,1,2 } ,{2,2,2,0 } ,{3,3,0,0 } ,{1,2,3,0 } },

                        new int[,] { {1,1,1,2 } ,{2,2,2,0 } ,{3,3,2,0 } ,{0,0,2,3 } },
                        new int[,] { {1,1,1,2 } ,{2,2,2,0 } ,{3,3,2,0 } ,{1,2,3,0 } },

                        new int[,] { {1,1,1,2 } ,{2,2,2,0 } ,{3,1,2,0 } ,{1,2,3,0 } },
//                      ---------------------------------------------------
                        new int[,] { {1,1,1,2 } ,{2,2,0,0 } ,{3,3,0,0 } ,{0,0,3,3 } },
                        new int[,] { {1,1,1,2 } ,{2,2,0,0 } ,{3,3,0,0 } ,{0,0,2,3 } },
                        new int[,] { {1,1,1,2 } ,{2,2,0,0 } ,{3,3,0,0 } ,{1,2,3,0 } },

                        new int[,] { {1,1,1,2 } ,{2,2,0,0 } ,{3,3,2,0 } ,{0,0,2,3 } },
                        new int[,] { {1,1,1,2 } ,{2,2,0,0 } ,{3,3,2,0 } ,{1,2,3,0 } },

                        new int[,] { {1,1,1,2 } ,{2,2,0,0 } ,{3,1,2,0 } ,{1,2,3,0 } },
//                      ---------------------------------------------------
                        new int[,] { {1,1,1,2 } ,{2,2,3,0 } ,{3,3,2,0 } ,{0,0,2,3 } },
                        new int[,] { {1,1,1,2 } ,{2,2,3,0 } ,{3,3,2,0 } ,{1,2,3,0 } },

                        new int[,] { {1,1,1,2 } ,{2,2,3,0 } ,{3,1,2,0 } ,{1,2,3,0 } },
//                      ---------------------------------------------------
                        new int[,] { {1,1,1,2 } ,{2,1,3,0 } ,{3,1,2,0 } ,{1,2,3,0 } },
//                      ---------------------------------------------------
//                      ---------------------------------------------------
                        new int[,] { {1,1,2,2 } ,{2,2,0,0 } ,{3,3,0,0 } ,{0,0,3,3 } },
                        new int[,] { {1,1,2,2 } ,{2,2,0,0 } ,{3,3,0,0 } ,{0,0,2,3 } },
                        new int[,] { {1,1,2,2 } ,{2,2,0,0 } ,{3,3,0,0 } ,{1,2,3,0 } },

                        new int[,] { {1,1,2,2 } ,{2,2,0,0 } ,{3,3,2,0 } ,{0,0,2,3 } },
                        new int[,] { {1,1,2,2 } ,{2,2,0,0 } ,{3,3,2,0 } ,{1,2,3,0 } },

                        new int[,] { {1,1,2,2 } ,{2,2,0,0 } ,{3,1,2,0 } ,{1,2,3,0 } },
//                      ---------------------------------------------------
                        new int[,] { {1,1,2,2 } ,{2,2,3,0 } ,{3,3,2,0 } ,{0,0,2,3 } },
                        new int[,] { {1,1,2,2 } ,{2,2,3,0 } ,{3,3,2,0 } ,{1,2,3,0 } },

                        new int[,] { {1,1,2,2 } ,{2,2,3,0 } ,{3,1,2,0 } ,{1,2,3,0 } },
//                      ---------------------------------------------------
                        new int[,] { {1,1,2,2 } ,{2,1,3,0 } ,{3,1,2,0 } ,{1,2,3,0 } },
//                      ---------------------------------------------------
//                      ---------------------------------------------------
                        new int[,] { {1,1,2,3 } ,{2,2,3,0 } ,{3,3,2,0 } ,{0,0,2,3 } },
                        new int[,] { {1,1,2,3 } ,{2,2,3,0 } ,{3,3,2,0 } ,{1,2,3,0 } },

                        new int[,] { {1,1,2,3 } ,{2,2,3,0 } ,{3,1,2,0 } ,{1,2,3,0 } },
//                      ---------------------------------------------------
                        new int[,] { {1,1,2,3 } ,{2,1,3,0 } ,{3,1,2,0 } ,{1,2,3,0 } },
//                      ---------------------------------------------------
//                      ---------------------------------------------------
                        new int[,] { {0,3,2,1 } ,{2,1,3,0 } ,{3,1,2,0 } ,{1,2,3,0 } },
//                      ---------------------------------------------------
//                      ---------------------------------------------------

                        };

    int[][] PlayBook = { 
                        new int[] {1,2,3,4},
                        new int[] {1,2,3,5},
                        new int[] {1,2,3,6},
                        new int[] {1,2,4,5},
                        new int[] {1,2,4,7},
                        new int[] {1,2,5,6},
                        new int[] {1,2,5,8}, 
                        new int[] {1,4,5,6},
                        new int[] {1,4,5,7},
                        new int[] {1,4,5,8},
                        new int[] {1,4,7,8},

                        new int[] {2,3,4,5},
                        new int[] {2,3,5,6},
                        new int[] {2,3,5,8},
                        new int[] {2,4,5,6},
                        new int[] {2,4,5,7},
                        new int[] {2,4,5,8},
                        new int[] {2,5,6,8},
                        new int[] {2,5,6,9},

                        new int[] {3,4,5,6},
                        new int[] {3,5,6,8},
                        new int[] {3,5,6,9},
                        new int[] {3,6,8,9},

                        new int[] {4,5,6,7},
                        new int[] {4,5,6,8},
                        new int[] {4,5,6,9},
                        new int[] {4,5,7,8},
                        new int[] {4,5,8,9},

                        new int[] {5,6,7,8},
                        new int[] {5,6,8,9},
                        new int[] {5,7,8,9},

                        new int[] {6,7,8,9}
                        };

    //This number will define the speed of play and the ammount of different plays the player uses. The higher the number the faster it plays and higher is the number of plays.
    public int difficulty = 1;
    public float pressing_time_reference = 1f;
    public float reaction_time_reference = 1f;
    public float same_pressing_time_reference = 0.5f;
    public float choosing_time_reference = 1f;
    float steal_agression_reference = 1f;

    float pressing_time;
    float reaction_time;
    float same_pressing_time;
    float choosing_time;
    float steal_agression;

    // This variable defines if a player prefers to play fast and "cheap" or slow and "rich". The lower the number the "cheaper" it plays.
    public int gamble_type = 1;
    public int plays_used = 3;

    private List<int[]> myPlayBook = new List<int[]>(); 
    private bool attacking;
    private bool canPlay = false;
    List<int> positions = new List<int>();
    List<int> myPositions = new List<int>();
    List<PieceMovs> awayPieces = new List<PieceMovs>();
    List<PieceMovs> myPieces = new List<PieceMovs>();
    int pieces = 0;


    GameManager manager;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Initialize(int difficulty, bool attacking, GameManager manager)
    {
        this.difficulty = difficulty;
        this.attacking = attacking;
        this.manager = manager;

        pressing_time = pressing_time_reference / difficulty;
        reaction_time = reaction_time_reference / difficulty;
        same_pressing_time = same_pressing_time_reference / difficulty;
        choosing_time = choosing_time_reference / difficulty;
        steal_agression = steal_agression_reference / difficulty;

        List<int> usedPlays = new List<int>();

        int play = Random.Range(0, PlayBook.Length );
        usedPlays.Add(play);
        myPlayBook.Add(PlayBook[play]);

        for (int i = 1; i< plays_used; i++)
        {
            do
            {
                play = Random.Range(0, PlayBook.Length );
            } while (usedPlays.Contains(play));

            usedPlays.Add(play);
            myPlayBook.Add(PlayBook[play]);
        }

        play = Random.Range(0, PiecesBook.Length);

        for(int i = 0; i<4; i++)
        {
            myPieces.Add(new PieceMovs(PiecesBook[play][i,0], PiecesBook[play][i, 1], PiecesBook[play][i, 2], PiecesBook[play][i, 3]));
        }

    }

    public void Play()
    {
        if (attacking)
            StartCoroutine(Attack());
        else
            StartCoroutine(Defend());
    }

    public void Stop()
    {
        Time.timeScale = 0.0f;
    }

    public void Continue()
    {
        Time.timeScale = 1.0f;
    }

    public void ReceivePiece(int position, PieceMovs piece)
    {
        awayPieces.Add(piece);
        positions.Add(position);
        if (awayPieces.Count == 4 && !attacking)
        {
            ReceiveAttack();
        }

    }

    void ReceiveAttack()
    {
        ClearTurn();
        StopAllCoroutines();
        StartCoroutine(Defend());
    }

    void ClearTurn()
    {
        pieces = 0;
        awayPieces.Clear();
        positions.Clear();
        myPositions.Clear();
    }

    void SendPiece(int position, PieceMovs piece)
    {
        pieces++;
        myPositions.Add(position);
        manager.ReceivePiece(position, piece);

    }

    public void ChangeSides()
    {
        ClearTurn();
        if (attacking)
        {
            StopAllCoroutines();
            StartCoroutine(Defend());
        }
        else
        {
            StopAllCoroutines();
            StartCoroutine(Attack());
        }
        attacking = !attacking;
        manager.ChangeSides(true);
    }

    IEnumerator Defend()
    {
        while (true)
        {
            yield return new WaitUntil(() => (((pieces < awayPieces.Count) || (awayPieces.Count == 3)) && pieces != 4));

            if (pieces < awayPieces.Count)
            {
                yield return new WaitForSeconds(reaction_time);
                //Precisa mudar o tempo de pressionar para verificar se é o mesmo botão duas, três ou quatro vezes
                yield return new WaitForSeconds(4*pressing_time);
                SendPiece(positions[pieces]+9, myPieces[pieces]);
            }else if( awayPieces.Count == 3)
            {
                yield return new WaitForSeconds(choosing_time);
                //Precisa mudar o tempo de pressionar para verificar se é o mesmo botão duas, três ou quatro vezes
                yield return new WaitForSeconds(4 * pressing_time);
                int position;
                do
                {
                    position = Random.Range(1, 10);
                } while (positions.Contains(position));
                SendPiece(position, myPieces[3]);
            }
        }
    }

    IEnumerator Attack()
    {
        while (true)
        {
            int play = Random.Range(0, plays_used);

            for (int piece = 0; piece < 4; piece++)
            {
                int position;
                do
                {
                    position = Random.Range(0, 4);
                } while (myPositions.Contains(myPlayBook[play][position]+9));

                yield return new WaitForSeconds(choosing_time);
                while (positions.Contains(myPlayBook[play][position]))
                {
                    position = (position + 1) % 3;
                    yield return new WaitForSeconds(choosing_time);
                    //
                    if(piece == 3)
                    {
                        position = FindNeighbour();
                    }
                }
                //Arrumar para o tempo de apertar bla bla bla
                yield return new WaitForSeconds(4 * pressing_time);
                if (positions.Contains(myPlayBook[play][position] + 9))
                {
                    ChangeSides();
                }
                else
                {
                    SendPiece(myPlayBook[play][position]+9, myPieces[piece]);
                }
            }

            ClearTurn();

        }
    }

    int FindNeighbour()
    {
        int nextPosition;
        //Realmente achar um vizinho
        do
        {
            nextPosition = Random.Range(0, 10);
        } while (!myPositions.Contains(nextPosition));
        return nextPosition;
    }

    public void Finish()
    {
        StopAllCoroutines();
    }


}

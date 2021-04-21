using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Difficulty
{
    NONE,
    EASY,
    MEDIUM,
    HARD,
    COUNT
}

public class HexBoard : MonoBehaviour
{
    public GameManager gameManager;

    public HexTile[] hexTiles;
    public Difficulty difficulty;

    public float timer = 0;

    public TMPro.TextMeshProUGUI timerText;

    private void Start()
    {
        initHexBoard();
    }

    private void Update()
    {
        timerCheck();
    }

    public void timerCheck()
    {
        if (timer <= Time.deltaTime)
        {
            // Game Over
            gameManager.LoseGame();
        }
        else
        {
            timer -= Time.deltaTime;
            timerText.text = ((int)timer).ToString();
        }
    }

    private void OnEnable()
    {
        initHexBoard();
    }

    private void OnDisable()
    {
        initHexBoard();
    }

    public void PreCheckBoard()
    {
        if(CheckBoard())
        {
            gameManager.WinGame();
            // You Win
        }
    }

    private bool CheckBoard()
    {
        foreach(HexTile ht in hexTiles) if (!ht.checkTile()) return false; return true;
    }

    public void initHexBoard()
    {
        foreach (HexTile ht in hexTiles)
        {
            ht.clearProngs();
        }

        switch (difficulty)
        {
            case Difficulty.EASY:
                timer = 60.0f + gameManager.hackingSkill * 2;
                break;

            case Difficulty.MEDIUM:
                timer = 50.0f + gameManager.hackingSkill * 2;
                break;

            case Difficulty.HARD:
                timer = 40.0f + gameManager.hackingSkill * 2;
                break;
        }

        hexTiles[0].initAdjacentHexTiles(new HexTile[] { null, null, null, hexTiles[1], hexTiles[2], hexTiles[3] });
        for (int d = 0; d < (int)difficulty + 1; d++)
        {
            switch(d)
            {
                case 0: // Index 1, 2nd row, Medium and Hard are the same.

                    switch(difficulty)
                    {
                        case Difficulty.EASY:
                            hexTiles[1].initAdjacentHexTiles(new HexTile[] { null, null, hexTiles[0], null, hexTiles[4], hexTiles[2] });
                            hexTiles[2].initAdjacentHexTiles(new HexTile[] { hexTiles[0], hexTiles[1], hexTiles[3], hexTiles[4], hexTiles[5], hexTiles[6] });
                            hexTiles[3].initAdjacentHexTiles(new HexTile[] { null, hexTiles[0], null, hexTiles[2], hexTiles[6], null });
                            break;

                        case Difficulty.MEDIUM:
                        case Difficulty.HARD:
                            hexTiles[1].initAdjacentHexTiles(new HexTile[] { null, null, hexTiles[0], hexTiles[4], hexTiles[5], hexTiles[2] });
                            hexTiles[2].initAdjacentHexTiles(new HexTile[] { hexTiles[0], hexTiles[1], hexTiles[3], hexTiles[5], hexTiles[6], hexTiles[7] });
                            hexTiles[3].initAdjacentHexTiles(new HexTile[] { null, hexTiles[0], null, hexTiles[2], hexTiles[7], hexTiles[8] });
                            break;

                        default:
                            break;
                    }
                    break;

                case 1: // Index 2, 3 third row
                    switch (difficulty)
                    {
                        case Difficulty.EASY:
                            hexTiles[4].initAdjacentHexTiles(new HexTile[] { hexTiles[1], null, hexTiles[2], null, null, hexTiles[5] });
                            hexTiles[5].initAdjacentHexTiles(new HexTile[] { hexTiles[2], hexTiles[4], hexTiles[6], null , null , null });
                            hexTiles[6].initAdjacentHexTiles(new HexTile[] { hexTiles[3], hexTiles[2], null, hexTiles[5], null, null });
                            break;

                        case Difficulty.MEDIUM:
                            hexTiles[4].initAdjacentHexTiles(new HexTile[] { null, null, hexTiles[1], null, hexTiles[9], hexTiles[5]});
                            hexTiles[5].initAdjacentHexTiles(new HexTile[] { hexTiles[1], hexTiles[4], hexTiles[2], hexTiles[9], hexTiles[10], hexTiles[6] });
                            hexTiles[6].initAdjacentHexTiles(new HexTile[] { hexTiles[2], hexTiles[5], hexTiles[7], hexTiles[10], hexTiles[11], hexTiles[12] });
                            hexTiles[7].initAdjacentHexTiles(new HexTile[] { hexTiles[3], hexTiles[2], hexTiles[8], hexTiles[6], hexTiles[12], hexTiles[13] });
                            hexTiles[8].initAdjacentHexTiles(new HexTile[] { null, hexTiles[3], null, hexTiles[7], hexTiles[13], null });
                            break;

                        case Difficulty.HARD:
                            hexTiles[4].initAdjacentHexTiles(new HexTile[] { null, null, hexTiles[1], hexTiles[9], hexTiles[10], hexTiles[5] });
                            hexTiles[5].initAdjacentHexTiles(new HexTile[] { hexTiles[1], hexTiles[4], hexTiles[2], hexTiles[10], hexTiles[11], hexTiles[6] });
                            hexTiles[6].initAdjacentHexTiles(new HexTile[] { hexTiles[2], hexTiles[5], hexTiles[7], hexTiles[11], hexTiles[12], hexTiles[13] });
                            hexTiles[7].initAdjacentHexTiles(new HexTile[] { hexTiles[3], hexTiles[2], hexTiles[8], hexTiles[6], hexTiles[13], hexTiles[14] });
                            hexTiles[8].initAdjacentHexTiles(new HexTile[] { null, hexTiles[3], null, hexTiles[7], hexTiles[14], hexTiles[15] });
                            break;

                        default:
                            break;
                    }
                    break;

                case 2:// 3 index, Easy is too small for this now, Medium is ending, and Hard is going on
                    switch (difficulty)
                    {
                        case Difficulty.MEDIUM:
                            hexTiles[9].initAdjacentHexTiles(new HexTile[] { hexTiles[4], null, hexTiles[5], null, hexTiles[14], hexTiles[10] });
                            hexTiles[10].initAdjacentHexTiles(new HexTile[] { hexTiles[5], hexTiles[9], hexTiles[6], hexTiles[14], hexTiles[15], hexTiles[11] });
                            hexTiles[11].initAdjacentHexTiles(new HexTile[] { hexTiles[6], hexTiles[10], hexTiles[12], hexTiles[15], hexTiles[16], hexTiles[17] });
                            hexTiles[12].initAdjacentHexTiles(new HexTile[] { hexTiles[7], hexTiles[6], hexTiles[13], hexTiles[11], hexTiles[17], hexTiles[18] });
                            hexTiles[13].initAdjacentHexTiles(new HexTile[] { hexTiles[8], hexTiles[7], null, hexTiles[12], hexTiles[18], null });

                            hexTiles[14].initAdjacentHexTiles(new HexTile[] { hexTiles[9], null, hexTiles[10], null, null, hexTiles[15] });
                            hexTiles[15].initAdjacentHexTiles(new HexTile[] { hexTiles[10], hexTiles[14], hexTiles[11], null, null, hexTiles[16] });
                            hexTiles[16].initAdjacentHexTiles(new HexTile[] { hexTiles[11], hexTiles[15], hexTiles[17], null , null , null });
                            hexTiles[17].initAdjacentHexTiles(new HexTile[] { hexTiles[12], hexTiles[11], hexTiles[18], hexTiles[16] , null , null });
                            hexTiles[18].initAdjacentHexTiles(new HexTile[] { hexTiles[13], hexTiles[12], null, hexTiles[17], null, null });

                            break;

                        case Difficulty.HARD:
                            hexTiles[9].initAdjacentHexTiles(new HexTile[] { null, null, hexTiles[4], null, hexTiles[16], hexTiles[10] });
                            hexTiles[10].initAdjacentHexTiles(new HexTile[] { hexTiles[4], hexTiles[9], hexTiles[5], hexTiles[16], hexTiles[17], hexTiles[11] });
                            hexTiles[11].initAdjacentHexTiles(new HexTile[] { hexTiles[5], hexTiles[10], hexTiles[6], hexTiles[17], hexTiles[18], hexTiles[12] });
                            hexTiles[12].initAdjacentHexTiles(new HexTile[] { hexTiles[6], hexTiles[11], hexTiles[13], hexTiles[18], hexTiles[19], hexTiles[20] });
                            hexTiles[13].initAdjacentHexTiles(new HexTile[] { hexTiles[7], hexTiles[6], hexTiles[14], hexTiles[12], hexTiles[20], hexTiles[21] });
                            hexTiles[14].initAdjacentHexTiles(new HexTile[] { hexTiles[8], hexTiles[7], hexTiles[15], hexTiles[13], hexTiles[21], hexTiles[22] });
                            hexTiles[15].initAdjacentHexTiles(new HexTile[] { null, hexTiles[8], null, hexTiles[14], hexTiles[22], null });

                            for (int i = 0; i < 2; i++)
                            {
                                hexTiles[16 + (7 * i)].initAdjacentHexTiles(new HexTile[] { hexTiles[9 + (7 * i)], null, hexTiles[10 + (7 * i)], null, hexTiles[23 + (7 * i)], hexTiles[17 + (7 * i)] });
                                hexTiles[17 + (7 * i)].initAdjacentHexTiles(new HexTile[] { hexTiles[10 + (7 * i)], hexTiles[16 + (7 * i)], hexTiles[11 + (7 * i)], hexTiles[23 + (7 * i)], hexTiles[24 + (7 * i)], hexTiles[18 + (7 * i)] });
                                hexTiles[18 + (7 * i)].initAdjacentHexTiles(new HexTile[] { hexTiles[11 + (7 * i)], hexTiles[17 + (7 * i)], hexTiles[12 + (7 * i)], hexTiles[24 + (7 * i)], hexTiles[25 + (7 * i)], hexTiles[19 + (7 * i)] });
                                hexTiles[19 + (7 * i)].initAdjacentHexTiles(new HexTile[] { hexTiles[12 + (7 * i)], hexTiles[18 + (7 * i)], hexTiles[20 + (7 * i)], hexTiles[25 + (7 * i)], hexTiles[26 + (7 * i)], hexTiles[27 + (7 * i)] });
                                hexTiles[20 + (7 * i)].initAdjacentHexTiles(new HexTile[] { hexTiles[13 + (7 * i)], hexTiles[12 + (7 * i)], hexTiles[21 + (7 * i)], hexTiles[19 + (7 * i)], hexTiles[27 + (7 * i)], hexTiles[28 + (7 * i)] });
                                hexTiles[21 + (7 * i)].initAdjacentHexTiles(new HexTile[] { hexTiles[14 + (7 * i)], hexTiles[13 + (7 * i)], hexTiles[22 + (7 * i)], hexTiles[20 + (7 * i)], hexTiles[28 + (7 * i)], hexTiles[29 + (7 * i)] });
                                hexTiles[22 + (7 * i)].initAdjacentHexTiles(new HexTile[] { hexTiles[15 + (7 * i)], hexTiles[14 + (7 * i)], null, hexTiles[21 + (7 * i)], hexTiles[29 + (7 * i)], null });
                            }

                            hexTiles[30].initAdjacentHexTiles(new HexTile[] { hexTiles[23], null, hexTiles[24], null, null, hexTiles[31] });
                            hexTiles[31].initAdjacentHexTiles(new HexTile[] { hexTiles[24], hexTiles[30], hexTiles[25], null, null, hexTiles[32] });
                            hexTiles[32].initAdjacentHexTiles(new HexTile[] { hexTiles[25], hexTiles[31], hexTiles[26], null, null, hexTiles[33] });
                            hexTiles[33].initAdjacentHexTiles(new HexTile[] { hexTiles[26], hexTiles[32], hexTiles[34], null, null, null });
                            hexTiles[34].initAdjacentHexTiles(new HexTile[] { hexTiles[27], hexTiles[26], hexTiles[35], hexTiles[33], null, null });
                            hexTiles[35].initAdjacentHexTiles(new HexTile[] { hexTiles[28], hexTiles[27], hexTiles[36], hexTiles[34], null, null });
                            hexTiles[36].initAdjacentHexTiles(new HexTile[] { hexTiles[29], hexTiles[28], null, hexTiles[35], null, null });

                            break;
                        default:
                            break;
                    }
                    break;

                default:
                    break;

            }
        }

        foreach(HexTile ht in hexTiles)
        {
            ht.hexBoardRef = this;
            ht.initProng();
        }

        foreach (HexTile ht in hexTiles)
        {
            int r = Random.Range(1, 5);

            for(int i = 0; i < r; i++)
                ht.rotateTileNoCheck();
        }

    }


}

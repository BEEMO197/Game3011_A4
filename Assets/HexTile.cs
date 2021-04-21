using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    CLOCKWISE,
    COUNTERCLOCKWISE
}

public class HexTile : MonoBehaviour
{
    public GameObject[] hexProngGameobjects;

    public HexBoard hexBoardRef;

    public HexProng[] hexConnections;
    public HexTile[] adjacentHexTiles;

    public int numberOfProngs = 0;
    public int tileIndex = 0;
    public Direction spinDirection;

    public bool tileGood = false;

    public void initAdjacentHexTiles(HexTile[] adjTiles)
    {
        adjacentHexTiles = adjTiles;
    }

    public void initProng()
    {
        for(int i = 0; i < adjacentHexTiles.Length; i++)
        {
            if (adjacentHexTiles[i] == null) ;//continue;
            else
            {
                // 10% chance
                if (!hexProngGameobjects[i].activeSelf)
                {
                    if (Random.Range(0, 10) == 1)
                    {
                        hexProngGameobjects[i].SetActive(true);

                        numberOfProngs++;
                        adjacentHexTiles[i].numberOfProngs++;
                        //adjacentHexTiles[i].hexProngGameobjects[(i + 3 >= hexProngGameobjects.Length ? i - 3 : i + 3)].SetActive(true);

                        // Opposite Prong : 0 - top, 1 - top left, 2 - top right, 3 - bottom left, 4 - bottom, 5 - bottom right

                        switch (i)
                        {
                            case 0:
                                adjacentHexTiles[i].hexProngGameobjects[4].SetActive(true);
                                break;

                            case 1:
                                adjacentHexTiles[i].hexProngGameobjects[5].SetActive(true);
                                break;

                            case 2:
                                adjacentHexTiles[i].hexProngGameobjects[3].SetActive(true);
                                break;

                            case 3:
                                adjacentHexTiles[i].hexProngGameobjects[2].SetActive(true);
                                break;

                            case 4:
                                adjacentHexTiles[i].hexProngGameobjects[0].SetActive(true);
                                break;

                            case 5:
                                adjacentHexTiles[i].hexProngGameobjects[1].SetActive(true);
                                break;

                        }
                    }
                }
            }
        }
    }

    public void clearProngs()
    {
        foreach(GameObject go in hexProngGameobjects)
        {
            go.SetActive(false);
        }
        numberOfProngs = 0;
    }

    public int getNumberOfAdjacentTiles()
    {
        int num = 0;
        foreach(HexTile ht in adjacentHexTiles)
        {
            if (ht != null)
                num++;
        }

        return num;
    }

    public void rotateTile()
    {
        bool temp = false;

        switch (spinDirection)
        {

            // 0 - top, 1 - top left, 2 - top right, 3 - bottom left, 4 - bottom, 5 - bottom right
            case Direction.CLOCKWISE:
                temp = hexProngGameobjects[0].activeSelf;

                hexProngGameobjects[0].SetActive(hexProngGameobjects[2].activeSelf);
                hexProngGameobjects[2].SetActive(hexProngGameobjects[5].activeSelf);
                hexProngGameobjects[5].SetActive(hexProngGameobjects[4].activeSelf);
                hexProngGameobjects[4].SetActive(hexProngGameobjects[3].activeSelf);
                hexProngGameobjects[3].SetActive(hexProngGameobjects[1].activeSelf);
                hexProngGameobjects[1].SetActive(temp);
                break;

            case Direction.COUNTERCLOCKWISE:
                temp = hexProngGameobjects[0].activeSelf;

                hexProngGameobjects[0].SetActive(hexProngGameobjects[1].activeSelf);
                hexProngGameobjects[1].SetActive(hexProngGameobjects[3].activeSelf);
                hexProngGameobjects[3].SetActive(hexProngGameobjects[4].activeSelf);
                hexProngGameobjects[4].SetActive(hexProngGameobjects[5].activeSelf);
                hexProngGameobjects[5].SetActive(hexProngGameobjects[2].activeSelf);
                hexProngGameobjects[2].SetActive(temp);
                break;

            default:
                break;
        }

        checkTile();
        hexBoardRef.PreCheckBoard();

    }

    public void rotateTileNoCheck()
    {
        bool temp = false;
        switch (spinDirection)
        {

            // 0 - top, 1 - top left, 2 - top right, 3 - bottom left, 4 - bottom, 5 - bottom right
            case Direction.CLOCKWISE:
                temp = hexProngGameobjects[0].activeSelf;

                hexProngGameobjects[0].SetActive(hexProngGameobjects[2].activeSelf);
                hexProngGameobjects[2].SetActive(hexProngGameobjects[5].activeSelf);
                hexProngGameobjects[5].SetActive(hexProngGameobjects[4].activeSelf);
                hexProngGameobjects[4].SetActive(hexProngGameobjects[3].activeSelf);
                hexProngGameobjects[3].SetActive(hexProngGameobjects[1].activeSelf);
                hexProngGameobjects[1].SetActive(temp);
                break;

            case Direction.COUNTERCLOCKWISE:
                temp = hexProngGameobjects[0].activeSelf;

                hexProngGameobjects[0].SetActive(hexProngGameobjects[1].activeSelf);
                hexProngGameobjects[1].SetActive(hexProngGameobjects[3].activeSelf);
                hexProngGameobjects[3].SetActive(hexProngGameobjects[4].activeSelf);
                hexProngGameobjects[4].SetActive(hexProngGameobjects[5].activeSelf);
                hexProngGameobjects[5].SetActive(hexProngGameobjects[2].activeSelf);
                hexProngGameobjects[2].SetActive(temp);
                break;

            default:
                break;
        }

    }
    // Returns true if all tiles are valid
    public bool checkTile()
    {
        // 0 - top, 1 - top left, 2 - top right, 3 - bottom left, 4 - bottom, 5 - bottom right
        int numConnects = 0;
        if (hexProngGameobjects[0].activeSelf && adjacentHexTiles[0] != null ? adjacentHexTiles[0].hexProngGameobjects[4].activeSelf : false)
        {
            //Top prong, connects to top tile
            numConnects++;
        }
        if (hexProngGameobjects[1].activeSelf && adjacentHexTiles[1] != null ? adjacentHexTiles[1].hexProngGameobjects[5].activeSelf : false)
        {
            //Top Left prong, connects to Bottom Right tile
            numConnects++;
        }
        if (hexProngGameobjects[2].activeSelf && adjacentHexTiles[2] != null ? adjacentHexTiles[2].hexProngGameobjects[3].activeSelf : false)
        {
            //Top Right prong, connects to Bottom Left Tile
            numConnects++;
        }
        if (hexProngGameobjects[3].activeSelf && adjacentHexTiles[3] != null ? adjacentHexTiles[3].hexProngGameobjects[2].activeSelf : false)
        {
            //Bottom Left prong, connects to Top Right Tile
            numConnects++;
        }
        if (hexProngGameobjects[4].activeSelf && adjacentHexTiles[4] != null ? adjacentHexTiles[4].hexProngGameobjects[0].activeSelf : false)
        {
            //Bottom prong, connects to Top tile
            numConnects++;
        }
        if (hexProngGameobjects[5].activeSelf && adjacentHexTiles[5] != null ? adjacentHexTiles[5].hexProngGameobjects[1].activeSelf : false)
        {
            //Bottom Right prong, connects to top left tile
            numConnects++;
        }

        Debug.Log("Connections Found: " + numConnects + "Number of Prongs on tile: " + numberOfProngs);
        if(numConnects == numberOfProngs)
        {
            Debug.Log(name + " Is Valid.");
            return true;
        }

        Debug.Log(name + " Is not Valid.");
        return false;
    }
}

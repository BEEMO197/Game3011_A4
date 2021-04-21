using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexProng : MonoBehaviour
{
    public HexProng connectedProng;
    public HexTile tileOn;

    public void setConnectedProng(HexProng hp)
    {
        connectedProng = hp;
    }
}

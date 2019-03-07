using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFactory : MonoBehaviour
{
    public enum COLOR
    {
        GREEN,
        RED,
        PURPLE
    }

    public enum AMOUNT
    {
        ONE=1,
        TWO=2,
        THREE=3
    }

    public enum SHADING
    {
        SOLID,
        STRIPED,
        OUTLINED
    }

    public enum SHAPE
    {
        OVAL,
        SQUIGGLE,
        DIAMOND
    }
}

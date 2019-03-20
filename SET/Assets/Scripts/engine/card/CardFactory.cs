using System;

[Serializable]
public class CardFactory
{
    public enum COLOR
    {
        GREEN,
        RED,
        PURPLE
    }

    public enum AMOUNT
    {
        ONE,
        TWO,
        THREE
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

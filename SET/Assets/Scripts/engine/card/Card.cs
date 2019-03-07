using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
    public CardFactory.COLOR color { get; private set; }
    public CardFactory.AMOUNT amount { get; private set; }
    public CardFactory.SHADING shading { get; private set; }
    public CardFactory.SHAPE shape { get; private set; }

    public Card(CardFactory.COLOR color, CardFactory.AMOUNT amount, CardFactory.SHADING shading, CardFactory.SHAPE shape)
    {
        this.color = color;
        this.amount = amount;
        this.shading = shading;
        this.shape = shape;
    }

    public override string ToString()
    {
        return "[" + color + "," + amount + "," + shading + "," + shape + "]";
    }
}

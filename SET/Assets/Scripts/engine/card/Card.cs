using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Card
{
    public CardFactory.COLOR color { get; set; }
    public CardFactory.AMOUNT amount { get; set; }
    public CardFactory.SHADING shading { get; set; }
    public CardFactory.SHAPE shape { get; set; }

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

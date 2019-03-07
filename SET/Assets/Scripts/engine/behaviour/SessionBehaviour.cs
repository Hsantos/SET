using System;
using System.Collections.Generic;
using System.Linq;
using Debug = UnityEngine.Debug;

public class SessionBehaviour
{
    #region card set
    private List<Card> cardSet = new List<Card>()
    {
        new Card(CardFactory.COLOR.RED,CardFactory.AMOUNT.ONE,CardFactory.SHADING.SOLID,CardFactory.SHAPE.DIAMOND),
        new Card(CardFactory.COLOR.GREEN,CardFactory.AMOUNT.ONE,CardFactory.SHADING.SOLID,CardFactory.SHAPE.DIAMOND),
        new Card(CardFactory.COLOR.PURPLE,CardFactory.AMOUNT.ONE,CardFactory.SHADING.SOLID,CardFactory.SHAPE.DIAMOND),
        //--
        new Card(CardFactory.COLOR.RED,CardFactory.AMOUNT.TWO,CardFactory.SHADING.SOLID,CardFactory.SHAPE.DIAMOND),
        new Card(CardFactory.COLOR.GREEN,CardFactory.AMOUNT.TWO,CardFactory.SHADING.SOLID,CardFactory.SHAPE.DIAMOND),
        new Card(CardFactory.COLOR.PURPLE,CardFactory.AMOUNT.TWO,CardFactory.SHADING.SOLID,CardFactory.SHAPE.DIAMOND),
        //--
        new Card(CardFactory.COLOR.RED,CardFactory.AMOUNT.THREE,CardFactory.SHADING.SOLID,CardFactory.SHAPE.DIAMOND),
        new Card(CardFactory.COLOR.GREEN,CardFactory.AMOUNT.THREE,CardFactory.SHADING.SOLID,CardFactory.SHAPE.DIAMOND),
        new Card(CardFactory.COLOR.PURPLE,CardFactory.AMOUNT.THREE,CardFactory.SHADING.SOLID,CardFactory.SHAPE.DIAMOND),
        //--
        //###
        new Card(CardFactory.COLOR.RED,CardFactory.AMOUNT.ONE,CardFactory.SHADING.OUTLINED,CardFactory.SHAPE.DIAMOND),
        new Card(CardFactory.COLOR.GREEN,CardFactory.AMOUNT.ONE,CardFactory.SHADING.OUTLINED,CardFactory.SHAPE.DIAMOND),
        new Card(CardFactory.COLOR.PURPLE,CardFactory.AMOUNT.ONE,CardFactory.SHADING.OUTLINED,CardFactory.SHAPE.DIAMOND),
        //--
        new Card(CardFactory.COLOR.RED,CardFactory.AMOUNT.TWO,CardFactory.SHADING.OUTLINED,CardFactory.SHAPE.DIAMOND),
        new Card(CardFactory.COLOR.GREEN,CardFactory.AMOUNT.TWO,CardFactory.SHADING.OUTLINED,CardFactory.SHAPE.DIAMOND),
        new Card(CardFactory.COLOR.PURPLE,CardFactory.AMOUNT.TWO,CardFactory.SHADING.OUTLINED,CardFactory.SHAPE.DIAMOND),
        //--
        new Card(CardFactory.COLOR.RED,CardFactory.AMOUNT.THREE,CardFactory.SHADING.OUTLINED,CardFactory.SHAPE.DIAMOND),
        new Card(CardFactory.COLOR.GREEN,CardFactory.AMOUNT.THREE,CardFactory.SHADING.OUTLINED,CardFactory.SHAPE.DIAMOND),
        new Card(CardFactory.COLOR.PURPLE,CardFactory.AMOUNT.THREE,CardFactory.SHADING.OUTLINED,CardFactory.SHAPE.DIAMOND),
        //--
        //###
        new Card(CardFactory.COLOR.RED,CardFactory.AMOUNT.ONE,CardFactory.SHADING.STRIPED,CardFactory.SHAPE.DIAMOND),
        new Card(CardFactory.COLOR.GREEN,CardFactory.AMOUNT.ONE,CardFactory.SHADING.STRIPED,CardFactory.SHAPE.DIAMOND),
        new Card(CardFactory.COLOR.PURPLE,CardFactory.AMOUNT.ONE,CardFactory.SHADING.STRIPED,CardFactory.SHAPE.DIAMOND),
        //--
        new Card(CardFactory.COLOR.RED,CardFactory.AMOUNT.TWO,CardFactory.SHADING.STRIPED,CardFactory.SHAPE.DIAMOND),
        new Card(CardFactory.COLOR.GREEN,CardFactory.AMOUNT.TWO,CardFactory.SHADING.STRIPED,CardFactory.SHAPE.DIAMOND),
        new Card(CardFactory.COLOR.PURPLE,CardFactory.AMOUNT.TWO,CardFactory.SHADING.STRIPED,CardFactory.SHAPE.DIAMOND),
        //--
        new Card(CardFactory.COLOR.RED,CardFactory.AMOUNT.THREE,CardFactory.SHADING.STRIPED,CardFactory.SHAPE.DIAMOND),
        new Card(CardFactory.COLOR.GREEN,CardFactory.AMOUNT.THREE,CardFactory.SHADING.STRIPED,CardFactory.SHAPE.DIAMOND),
        new Card(CardFactory.COLOR.PURPLE,CardFactory.AMOUNT.THREE,CardFactory.SHADING.STRIPED,CardFactory.SHAPE.DIAMOND),

        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

        new Card(CardFactory.COLOR.RED,CardFactory.AMOUNT.ONE,CardFactory.SHADING.SOLID,CardFactory.SHAPE.OVAL),
        new Card(CardFactory.COLOR.GREEN,CardFactory.AMOUNT.ONE,CardFactory.SHADING.SOLID,CardFactory.SHAPE.OVAL),
        new Card(CardFactory.COLOR.PURPLE,CardFactory.AMOUNT.ONE,CardFactory.SHADING.SOLID,CardFactory.SHAPE.OVAL),
        //--
        new Card(CardFactory.COLOR.RED,CardFactory.AMOUNT.TWO,CardFactory.SHADING.SOLID,CardFactory.SHAPE.OVAL),
        new Card(CardFactory.COLOR.GREEN,CardFactory.AMOUNT.TWO,CardFactory.SHADING.SOLID,CardFactory.SHAPE.OVAL),
        new Card(CardFactory.COLOR.PURPLE,CardFactory.AMOUNT.TWO,CardFactory.SHADING.SOLID,CardFactory.SHAPE.OVAL),
        //--
        new Card(CardFactory.COLOR.RED,CardFactory.AMOUNT.THREE,CardFactory.SHADING.SOLID,CardFactory.SHAPE.OVAL),
        new Card(CardFactory.COLOR.GREEN,CardFactory.AMOUNT.THREE,CardFactory.SHADING.SOLID,CardFactory.SHAPE.OVAL),
        new Card(CardFactory.COLOR.PURPLE,CardFactory.AMOUNT.THREE,CardFactory.SHADING.SOLID,CardFactory.SHAPE.OVAL),
        //--
        //###
        new Card(CardFactory.COLOR.RED,CardFactory.AMOUNT.ONE,CardFactory.SHADING.OUTLINED,CardFactory.SHAPE.OVAL),
        new Card(CardFactory.COLOR.GREEN,CardFactory.AMOUNT.ONE,CardFactory.SHADING.OUTLINED,CardFactory.SHAPE.OVAL),
        new Card(CardFactory.COLOR.PURPLE,CardFactory.AMOUNT.ONE,CardFactory.SHADING.OUTLINED,CardFactory.SHAPE.OVAL),
        //--
        new Card(CardFactory.COLOR.RED,CardFactory.AMOUNT.TWO,CardFactory.SHADING.OUTLINED,CardFactory.SHAPE.OVAL),
        new Card(CardFactory.COLOR.GREEN,CardFactory.AMOUNT.TWO,CardFactory.SHADING.OUTLINED,CardFactory.SHAPE.OVAL),
        new Card(CardFactory.COLOR.PURPLE,CardFactory.AMOUNT.TWO,CardFactory.SHADING.OUTLINED,CardFactory.SHAPE.OVAL),
        //--
        new Card(CardFactory.COLOR.RED,CardFactory.AMOUNT.THREE,CardFactory.SHADING.OUTLINED,CardFactory.SHAPE.OVAL),
        new Card(CardFactory.COLOR.GREEN,CardFactory.AMOUNT.THREE,CardFactory.SHADING.OUTLINED,CardFactory.SHAPE.OVAL),
        new Card(CardFactory.COLOR.PURPLE,CardFactory.AMOUNT.THREE,CardFactory.SHADING.OUTLINED,CardFactory.SHAPE.OVAL),
        //--
        //###
        new Card(CardFactory.COLOR.RED,CardFactory.AMOUNT.ONE,CardFactory.SHADING.STRIPED,CardFactory.SHAPE.OVAL),
        new Card(CardFactory.COLOR.GREEN,CardFactory.AMOUNT.ONE,CardFactory.SHADING.STRIPED,CardFactory.SHAPE.OVAL),
        new Card(CardFactory.COLOR.PURPLE,CardFactory.AMOUNT.ONE,CardFactory.SHADING.STRIPED,CardFactory.SHAPE.OVAL),
        //--
        new Card(CardFactory.COLOR.RED,CardFactory.AMOUNT.TWO,CardFactory.SHADING.STRIPED,CardFactory.SHAPE.OVAL),
        new Card(CardFactory.COLOR.GREEN,CardFactory.AMOUNT.TWO,CardFactory.SHADING.STRIPED,CardFactory.SHAPE.OVAL),
        new Card(CardFactory.COLOR.PURPLE,CardFactory.AMOUNT.TWO,CardFactory.SHADING.STRIPED,CardFactory.SHAPE.OVAL),
        //--
        new Card(CardFactory.COLOR.RED,CardFactory.AMOUNT.THREE,CardFactory.SHADING.STRIPED,CardFactory.SHAPE.OVAL),
        new Card(CardFactory.COLOR.GREEN,CardFactory.AMOUNT.THREE,CardFactory.SHADING.STRIPED,CardFactory.SHAPE.OVAL),
        new Card(CardFactory.COLOR.PURPLE,CardFactory.AMOUNT.THREE,CardFactory.SHADING.STRIPED,CardFactory.SHAPE.OVAL),

         //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

        new Card(CardFactory.COLOR.RED,CardFactory.AMOUNT.ONE,CardFactory.SHADING.SOLID,CardFactory.SHAPE.SQUIGGLE),
        new Card(CardFactory.COLOR.GREEN,CardFactory.AMOUNT.ONE,CardFactory.SHADING.SOLID,CardFactory.SHAPE.SQUIGGLE),
        new Card(CardFactory.COLOR.PURPLE,CardFactory.AMOUNT.ONE,CardFactory.SHADING.SOLID,CardFactory.SHAPE.SQUIGGLE),
        //--
        new Card(CardFactory.COLOR.RED,CardFactory.AMOUNT.TWO,CardFactory.SHADING.SOLID,CardFactory.SHAPE.SQUIGGLE),
        new Card(CardFactory.COLOR.GREEN,CardFactory.AMOUNT.TWO,CardFactory.SHADING.SOLID,CardFactory.SHAPE.SQUIGGLE),
        new Card(CardFactory.COLOR.PURPLE,CardFactory.AMOUNT.TWO,CardFactory.SHADING.SOLID,CardFactory.SHAPE.SQUIGGLE),
        //--
        new Card(CardFactory.COLOR.RED,CardFactory.AMOUNT.THREE,CardFactory.SHADING.SOLID,CardFactory.SHAPE.SQUIGGLE),
        new Card(CardFactory.COLOR.GREEN,CardFactory.AMOUNT.THREE,CardFactory.SHADING.SOLID,CardFactory.SHAPE.SQUIGGLE),
        new Card(CardFactory.COLOR.PURPLE,CardFactory.AMOUNT.THREE,CardFactory.SHADING.SOLID,CardFactory.SHAPE.SQUIGGLE),
        //--
        //###
        new Card(CardFactory.COLOR.RED,CardFactory.AMOUNT.ONE,CardFactory.SHADING.OUTLINED,CardFactory.SHAPE.SQUIGGLE),
        new Card(CardFactory.COLOR.GREEN,CardFactory.AMOUNT.ONE,CardFactory.SHADING.OUTLINED,CardFactory.SHAPE.SQUIGGLE),
        new Card(CardFactory.COLOR.PURPLE,CardFactory.AMOUNT.ONE,CardFactory.SHADING.OUTLINED,CardFactory.SHAPE.SQUIGGLE),
        //--
        new Card(CardFactory.COLOR.RED,CardFactory.AMOUNT.TWO,CardFactory.SHADING.OUTLINED,CardFactory.SHAPE.SQUIGGLE),
        new Card(CardFactory.COLOR.GREEN,CardFactory.AMOUNT.TWO,CardFactory.SHADING.OUTLINED,CardFactory.SHAPE.SQUIGGLE),
        new Card(CardFactory.COLOR.PURPLE,CardFactory.AMOUNT.TWO,CardFactory.SHADING.OUTLINED,CardFactory.SHAPE.SQUIGGLE),
        //--
        new Card(CardFactory.COLOR.RED,CardFactory.AMOUNT.THREE,CardFactory.SHADING.OUTLINED,CardFactory.SHAPE.SQUIGGLE),
        new Card(CardFactory.COLOR.GREEN,CardFactory.AMOUNT.THREE,CardFactory.SHADING.OUTLINED,CardFactory.SHAPE.SQUIGGLE),
        new Card(CardFactory.COLOR.PURPLE,CardFactory.AMOUNT.THREE,CardFactory.SHADING.OUTLINED,CardFactory.SHAPE.SQUIGGLE),
        //--
        //###
        new Card(CardFactory.COLOR.RED,CardFactory.AMOUNT.ONE,CardFactory.SHADING.STRIPED,CardFactory.SHAPE.SQUIGGLE),
        new Card(CardFactory.COLOR.GREEN,CardFactory.AMOUNT.ONE,CardFactory.SHADING.STRIPED,CardFactory.SHAPE.SQUIGGLE),
        new Card(CardFactory.COLOR.PURPLE,CardFactory.AMOUNT.ONE,CardFactory.SHADING.STRIPED,CardFactory.SHAPE.SQUIGGLE),
        //--
        new Card(CardFactory.COLOR.RED,CardFactory.AMOUNT.TWO,CardFactory.SHADING.STRIPED,CardFactory.SHAPE.SQUIGGLE),
        new Card(CardFactory.COLOR.GREEN,CardFactory.AMOUNT.TWO,CardFactory.SHADING.STRIPED,CardFactory.SHAPE.SQUIGGLE),
        new Card(CardFactory.COLOR.PURPLE,CardFactory.AMOUNT.TWO,CardFactory.SHADING.STRIPED,CardFactory.SHAPE.SQUIGGLE),
        //--
        new Card(CardFactory.COLOR.RED,CardFactory.AMOUNT.THREE,CardFactory.SHADING.STRIPED,CardFactory.SHAPE.SQUIGGLE),
        new Card(CardFactory.COLOR.GREEN,CardFactory.AMOUNT.THREE,CardFactory.SHADING.STRIPED,CardFactory.SHAPE.SQUIGGLE),
        new Card(CardFactory.COLOR.PURPLE,CardFactory.AMOUNT.THREE,CardFactory.SHADING.STRIPED,CardFactory.SHAPE.SQUIGGLE)
    };
    #endregion

    public Card[] GenerateShuffleCard()
    {
        Random rnd = new Random();
        Card[] newSet = cardSet.ToArray().Clone() as Card[];
;       return newSet.OrderBy(x => rnd.Next()).ToArray();
    }

    public bool IsMatch(List<Card> matchList)
    {
        bool check = false;

        int equalShapes = matchList.Select(x => x.shape).Distinct().Count();
        int equalAmount = matchList.Select(x => x.amount).Distinct().Count();
        int equalColor = matchList.Select(x => x.color).Distinct().Count();
        int equalShading = matchList.Select(x => x.shading).Distinct().Count();

        check =  (equalShapes == GameSession.TOTAL_CARDS_TO_MATCH || equalShapes== 1) &&
                 (equalAmount == GameSession.TOTAL_CARDS_TO_MATCH || equalAmount == 1) &&
                 (equalColor == GameSession.TOTAL_CARDS_TO_MATCH || equalColor== 1) &&
                 (equalShading == GameSession.TOTAL_CARDS_TO_MATCH || equalShading == 1);

        Debug.LogWarning(check +  " | "+ equalShapes + " | " + equalAmount + " | " + equalColor + " | " + equalShading);

        return check;
    }
}

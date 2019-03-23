using System;
using System.Collections.Generic;
using System.Linq;
using Debug = UnityEngine.Debug;

public class SessionBehaviour
{
    #region card set
    private List<Card> cardSet = new List<Card>()
    {
        new Card(1,CardFactory.COLOR.RED,CardFactory.AMOUNT.ONE,CardFactory.SHADING.SOLID,CardFactory.SHAPE.DIAMOND),
        new Card(2,CardFactory.COLOR.GREEN,CardFactory.AMOUNT.ONE,CardFactory.SHADING.SOLID,CardFactory.SHAPE.DIAMOND),
        new Card(3,CardFactory.COLOR.PURPLE,CardFactory.AMOUNT.ONE,CardFactory.SHADING.SOLID,CardFactory.SHAPE.DIAMOND),
        //--
        new Card(4,CardFactory.COLOR.RED,CardFactory.AMOUNT.TWO,CardFactory.SHADING.SOLID,CardFactory.SHAPE.DIAMOND),
        new Card(5,CardFactory.COLOR.GREEN,CardFactory.AMOUNT.TWO,CardFactory.SHADING.SOLID,CardFactory.SHAPE.DIAMOND),
        new Card(6,CardFactory.COLOR.PURPLE,CardFactory.AMOUNT.TWO,CardFactory.SHADING.SOLID,CardFactory.SHAPE.DIAMOND),
        //--
        new Card(7,CardFactory.COLOR.RED,CardFactory.AMOUNT.THREE,CardFactory.SHADING.SOLID,CardFactory.SHAPE.DIAMOND),
        new Card(8,CardFactory.COLOR.GREEN,CardFactory.AMOUNT.THREE,CardFactory.SHADING.SOLID,CardFactory.SHAPE.DIAMOND),
        new Card(9,CardFactory.COLOR.PURPLE,CardFactory.AMOUNT.THREE,CardFactory.SHADING.SOLID,CardFactory.SHAPE.DIAMOND),
        //--
        //###
        new Card(10,CardFactory.COLOR.RED,CardFactory.AMOUNT.ONE,CardFactory.SHADING.OUTLINED,CardFactory.SHAPE.DIAMOND),
        new Card(11,CardFactory.COLOR.GREEN,CardFactory.AMOUNT.ONE,CardFactory.SHADING.OUTLINED,CardFactory.SHAPE.DIAMOND),
        new Card(12,CardFactory.COLOR.PURPLE,CardFactory.AMOUNT.ONE,CardFactory.SHADING.OUTLINED,CardFactory.SHAPE.DIAMOND),
        //--
        new Card(13,CardFactory.COLOR.RED,CardFactory.AMOUNT.TWO,CardFactory.SHADING.OUTLINED,CardFactory.SHAPE.DIAMOND),
        new Card(14,CardFactory.COLOR.GREEN,CardFactory.AMOUNT.TWO,CardFactory.SHADING.OUTLINED,CardFactory.SHAPE.DIAMOND),
        new Card(15,CardFactory.COLOR.PURPLE,CardFactory.AMOUNT.TWO,CardFactory.SHADING.OUTLINED,CardFactory.SHAPE.DIAMOND),
        //--
        new Card(16,CardFactory.COLOR.RED,CardFactory.AMOUNT.THREE,CardFactory.SHADING.OUTLINED,CardFactory.SHAPE.DIAMOND),
        new Card(17,CardFactory.COLOR.GREEN,CardFactory.AMOUNT.THREE,CardFactory.SHADING.OUTLINED,CardFactory.SHAPE.DIAMOND),
        new Card(18,CardFactory.COLOR.PURPLE,CardFactory.AMOUNT.THREE,CardFactory.SHADING.OUTLINED,CardFactory.SHAPE.DIAMOND),
        //--
        //###
        new Card(19,CardFactory.COLOR.RED,CardFactory.AMOUNT.ONE,CardFactory.SHADING.STRIPED,CardFactory.SHAPE.DIAMOND),
        new Card(20,CardFactory.COLOR.GREEN,CardFactory.AMOUNT.ONE,CardFactory.SHADING.STRIPED,CardFactory.SHAPE.DIAMOND),
        new Card(21,CardFactory.COLOR.PURPLE,CardFactory.AMOUNT.ONE,CardFactory.SHADING.STRIPED,CardFactory.SHAPE.DIAMOND),
        //--
        new Card(22,CardFactory.COLOR.RED,CardFactory.AMOUNT.TWO,CardFactory.SHADING.STRIPED,CardFactory.SHAPE.DIAMOND),
        new Card(23,CardFactory.COLOR.GREEN,CardFactory.AMOUNT.TWO,CardFactory.SHADING.STRIPED,CardFactory.SHAPE.DIAMOND),
        new Card(24,CardFactory.COLOR.PURPLE,CardFactory.AMOUNT.TWO,CardFactory.SHADING.STRIPED,CardFactory.SHAPE.DIAMOND),
        //--
        new Card(25,CardFactory.COLOR.RED,CardFactory.AMOUNT.THREE,CardFactory.SHADING.STRIPED,CardFactory.SHAPE.DIAMOND),
        new Card(26,CardFactory.COLOR.GREEN,CardFactory.AMOUNT.THREE,CardFactory.SHADING.STRIPED,CardFactory.SHAPE.DIAMOND),
        new Card(27,CardFactory.COLOR.PURPLE,CardFactory.AMOUNT.THREE,CardFactory.SHADING.STRIPED,CardFactory.SHAPE.DIAMOND),

        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

        new Card(28,CardFactory.COLOR.RED,CardFactory.AMOUNT.ONE,CardFactory.SHADING.SOLID,CardFactory.SHAPE.OVAL),
        new Card(29,CardFactory.COLOR.GREEN,CardFactory.AMOUNT.ONE,CardFactory.SHADING.SOLID,CardFactory.SHAPE.OVAL),
        new Card(30,CardFactory.COLOR.PURPLE,CardFactory.AMOUNT.ONE,CardFactory.SHADING.SOLID,CardFactory.SHAPE.OVAL),
        //--
        new Card(31,CardFactory.COLOR.RED,CardFactory.AMOUNT.TWO,CardFactory.SHADING.SOLID,CardFactory.SHAPE.OVAL),
        new Card(32,CardFactory.COLOR.GREEN,CardFactory.AMOUNT.TWO,CardFactory.SHADING.SOLID,CardFactory.SHAPE.OVAL),
        new Card(33,CardFactory.COLOR.PURPLE,CardFactory.AMOUNT.TWO,CardFactory.SHADING.SOLID,CardFactory.SHAPE.OVAL),
        //--
        new Card(34,CardFactory.COLOR.RED,CardFactory.AMOUNT.THREE,CardFactory.SHADING.SOLID,CardFactory.SHAPE.OVAL),
        new Card(35,CardFactory.COLOR.GREEN,CardFactory.AMOUNT.THREE,CardFactory.SHADING.SOLID,CardFactory.SHAPE.OVAL),
        new Card(36,CardFactory.COLOR.PURPLE,CardFactory.AMOUNT.THREE,CardFactory.SHADING.SOLID,CardFactory.SHAPE.OVAL),
        //--
        //###
        new Card(37,CardFactory.COLOR.RED,CardFactory.AMOUNT.ONE,CardFactory.SHADING.OUTLINED,CardFactory.SHAPE.OVAL),
        new Card(38,CardFactory.COLOR.GREEN,CardFactory.AMOUNT.ONE,CardFactory.SHADING.OUTLINED,CardFactory.SHAPE.OVAL),
        new Card(39,CardFactory.COLOR.PURPLE,CardFactory.AMOUNT.ONE,CardFactory.SHADING.OUTLINED,CardFactory.SHAPE.OVAL),
        //--
        new Card(40,CardFactory.COLOR.RED,CardFactory.AMOUNT.TWO,CardFactory.SHADING.OUTLINED,CardFactory.SHAPE.OVAL),
        new Card(41,CardFactory.COLOR.GREEN,CardFactory.AMOUNT.TWO,CardFactory.SHADING.OUTLINED,CardFactory.SHAPE.OVAL),
        new Card(42,CardFactory.COLOR.PURPLE,CardFactory.AMOUNT.TWO,CardFactory.SHADING.OUTLINED,CardFactory.SHAPE.OVAL),
        //--
        new Card(43,CardFactory.COLOR.RED,CardFactory.AMOUNT.THREE,CardFactory.SHADING.OUTLINED,CardFactory.SHAPE.OVAL),
        new Card(44,CardFactory.COLOR.GREEN,CardFactory.AMOUNT.THREE,CardFactory.SHADING.OUTLINED,CardFactory.SHAPE.OVAL),
        new Card(45,CardFactory.COLOR.PURPLE,CardFactory.AMOUNT.THREE,CardFactory.SHADING.OUTLINED,CardFactory.SHAPE.OVAL),
        //--
        //###
        new Card(46,CardFactory.COLOR.RED,CardFactory.AMOUNT.ONE,CardFactory.SHADING.STRIPED,CardFactory.SHAPE.OVAL),
        new Card(47,CardFactory.COLOR.GREEN,CardFactory.AMOUNT.ONE,CardFactory.SHADING.STRIPED,CardFactory.SHAPE.OVAL),
        new Card(48,CardFactory.COLOR.PURPLE,CardFactory.AMOUNT.ONE,CardFactory.SHADING.STRIPED,CardFactory.SHAPE.OVAL),
        //--
        new Card(49,CardFactory.COLOR.RED,CardFactory.AMOUNT.TWO,CardFactory.SHADING.STRIPED,CardFactory.SHAPE.OVAL),
        new Card(50,CardFactory.COLOR.GREEN,CardFactory.AMOUNT.TWO,CardFactory.SHADING.STRIPED,CardFactory.SHAPE.OVAL),
        new Card(51,CardFactory.COLOR.PURPLE,CardFactory.AMOUNT.TWO,CardFactory.SHADING.STRIPED,CardFactory.SHAPE.OVAL),
        //--
        new Card(52,CardFactory.COLOR.RED,CardFactory.AMOUNT.THREE,CardFactory.SHADING.STRIPED,CardFactory.SHAPE.OVAL),
        new Card(53,CardFactory.COLOR.GREEN,CardFactory.AMOUNT.THREE,CardFactory.SHADING.STRIPED,CardFactory.SHAPE.OVAL),
        new Card(54,CardFactory.COLOR.PURPLE,CardFactory.AMOUNT.THREE,CardFactory.SHADING.STRIPED,CardFactory.SHAPE.OVAL),

         //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

        new Card(55,CardFactory.COLOR.RED,CardFactory.AMOUNT.ONE,CardFactory.SHADING.SOLID,CardFactory.SHAPE.SQUIGGLE),
        new Card(56,CardFactory.COLOR.GREEN,CardFactory.AMOUNT.ONE,CardFactory.SHADING.SOLID,CardFactory.SHAPE.SQUIGGLE),
        new Card(57,CardFactory.COLOR.PURPLE,CardFactory.AMOUNT.ONE,CardFactory.SHADING.SOLID,CardFactory.SHAPE.SQUIGGLE),
        //--
        new Card(58,CardFactory.COLOR.RED,CardFactory.AMOUNT.TWO,CardFactory.SHADING.SOLID,CardFactory.SHAPE.SQUIGGLE),
        new Card(59,CardFactory.COLOR.GREEN,CardFactory.AMOUNT.TWO,CardFactory.SHADING.SOLID,CardFactory.SHAPE.SQUIGGLE),
        new Card(60,CardFactory.COLOR.PURPLE,CardFactory.AMOUNT.TWO,CardFactory.SHADING.SOLID,CardFactory.SHAPE.SQUIGGLE),
        //--
        new Card(61,CardFactory.COLOR.RED,CardFactory.AMOUNT.THREE,CardFactory.SHADING.SOLID,CardFactory.SHAPE.SQUIGGLE),
        new Card(62,CardFactory.COLOR.GREEN,CardFactory.AMOUNT.THREE,CardFactory.SHADING.SOLID,CardFactory.SHAPE.SQUIGGLE),
        new Card(63,CardFactory.COLOR.PURPLE,CardFactory.AMOUNT.THREE,CardFactory.SHADING.SOLID,CardFactory.SHAPE.SQUIGGLE),
        //--
        //###
        new Card(64,CardFactory.COLOR.RED,CardFactory.AMOUNT.ONE,CardFactory.SHADING.OUTLINED,CardFactory.SHAPE.SQUIGGLE),
        new Card(65,CardFactory.COLOR.GREEN,CardFactory.AMOUNT.ONE,CardFactory.SHADING.OUTLINED,CardFactory.SHAPE.SQUIGGLE),
        new Card(66,CardFactory.COLOR.PURPLE,CardFactory.AMOUNT.ONE,CardFactory.SHADING.OUTLINED,CardFactory.SHAPE.SQUIGGLE),
        //--
        new Card(67,CardFactory.COLOR.RED,CardFactory.AMOUNT.TWO,CardFactory.SHADING.OUTLINED,CardFactory.SHAPE.SQUIGGLE),
        new Card(68,CardFactory.COLOR.GREEN,CardFactory.AMOUNT.TWO,CardFactory.SHADING.OUTLINED,CardFactory.SHAPE.SQUIGGLE),
        new Card(69,CardFactory.COLOR.PURPLE,CardFactory.AMOUNT.TWO,CardFactory.SHADING.OUTLINED,CardFactory.SHAPE.SQUIGGLE),
        //--
        new Card(70,CardFactory.COLOR.RED,CardFactory.AMOUNT.THREE,CardFactory.SHADING.OUTLINED,CardFactory.SHAPE.SQUIGGLE),
        new Card(71,CardFactory.COLOR.GREEN,CardFactory.AMOUNT.THREE,CardFactory.SHADING.OUTLINED,CardFactory.SHAPE.SQUIGGLE),
        new Card(72,CardFactory.COLOR.PURPLE,CardFactory.AMOUNT.THREE,CardFactory.SHADING.OUTLINED,CardFactory.SHAPE.SQUIGGLE),
        //--
        //###
        new Card(73,CardFactory.COLOR.RED,CardFactory.AMOUNT.ONE,CardFactory.SHADING.STRIPED,CardFactory.SHAPE.SQUIGGLE),
        new Card(74,CardFactory.COLOR.GREEN,CardFactory.AMOUNT.ONE,CardFactory.SHADING.STRIPED,CardFactory.SHAPE.SQUIGGLE),
        new Card(75,CardFactory.COLOR.PURPLE,CardFactory.AMOUNT.ONE,CardFactory.SHADING.STRIPED,CardFactory.SHAPE.SQUIGGLE),
        //--
        new Card(76,CardFactory.COLOR.RED,CardFactory.AMOUNT.TWO,CardFactory.SHADING.STRIPED,CardFactory.SHAPE.SQUIGGLE),
        new Card(77,CardFactory.COLOR.GREEN,CardFactory.AMOUNT.TWO,CardFactory.SHADING.STRIPED,CardFactory.SHAPE.SQUIGGLE),
        new Card(78,CardFactory.COLOR.PURPLE,CardFactory.AMOUNT.TWO,CardFactory.SHADING.STRIPED,CardFactory.SHAPE.SQUIGGLE),
        //--
        new Card(79,CardFactory.COLOR.RED,CardFactory.AMOUNT.THREE,CardFactory.SHADING.STRIPED,CardFactory.SHAPE.SQUIGGLE),
        new Card(80,CardFactory.COLOR.GREEN,CardFactory.AMOUNT.THREE,CardFactory.SHADING.STRIPED,CardFactory.SHAPE.SQUIGGLE),
        new Card(81,CardFactory.COLOR.PURPLE,CardFactory.AMOUNT.THREE,CardFactory.SHADING.STRIPED,CardFactory.SHAPE.SQUIGGLE)
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
                 (equalColor == GameSession.TOTAL_CARDS_TO_MATCH || equalColor == 1) &&
                 (equalShading == GameSession.TOTAL_CARDS_TO_MATCH || equalShading == 1);

        //Debug.LogWarning(check +  " | "+ equalShapes + " | " + equalAmount + " | " + equalColor + " | " + equalShading);

        return check;
    }
}

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.view.card
{
    public class CardView:Button
    {
        private GameObject iconPrefab;
        public Card card { get; private set; }
        private List<Image> icons;
        private Transform front;
        private GameObject selected;
        void Awake()
        {
            icons = new List<Image>();
            selected = transform.Find("select").gameObject;
            front = transform.Find("front").transform;
            iconPrefab = Resources.Load<GameObject>("Prefab/card/Icon");
            selected.gameObject.SetActive(false);
        }

        public CardView Initiate(Card card)
        {
            this.card = card;
            
            #region Draw info

            string spriteName = "";
            Sprite spriteImage = null;

            switch (card.shape)
            {
                case CardFactory.SHAPE.OVAL:
                    spriteName += "oval";
                    break;
                case CardFactory.SHAPE.DIAMOND:
                    spriteName += "diamond";
                    break;
                case CardFactory.SHAPE.SQUIGGLE:
                    spriteName += "squiggle";
                    break;
                default:
                    throw new Exception();
                    break;
            }

            switch (card.shading)
            {
                case CardFactory.SHADING.OUTLINED:
                   
                    spriteName += "_outlined";
                    break;
                case CardFactory.SHADING.SOLID:
                    spriteName += "_solid";
                    break;
                case CardFactory.SHADING.STRIPED:
                    spriteName += "_striped";
                    break;
                default:
                    throw new Exception();
                    break;
            }

            spriteImage = Resources.Load<Sprite>("Sprites/" + spriteName);
            Image current = null;
            switch (card.amount)
            {
                case CardFactory.AMOUNT.ONE:

                    current = Instantiate(iconPrefab,front).gameObject.GetComponent<Image>();
                    current.sprite = spriteImage;
                    icons.Add(current);

                    break;
                case CardFactory.AMOUNT.TWO:
                    for (int i = 0; i < 2; i++)
                    {
                        current = Instantiate(iconPrefab, front).gameObject.GetComponent<Image>();
                        current.sprite = spriteImage;
                        icons.Add(current);
                    }
                    break;
                case CardFactory.AMOUNT.THREE:
                    for (int i = 0; i < 3; i++)
                    {
                        current = Instantiate(iconPrefab, front).gameObject.GetComponent<Image>();
                        current.sprite = spriteImage;
                        icons.Add(current);
                    }
                    break;
            }

            switch (card.color)
            {
                case CardFactory.COLOR.RED:

                    for (int i = 0; i < icons.Count; i++)
                    {
                        icons[i].color = Color.red;
                    }

                    break;
                case CardFactory.COLOR.PURPLE:
                    for (int i = 0; i < icons.Count; i++)
                    {
                        icons[i].color = Color.blue;
                    }
                    break;
                case CardFactory.COLOR.GREEN:
                    for (int i = 0; i < icons.Count; i++)
                    {
                        icons[i].color = Color.green;
                    }
                    break;
            }

            #endregion


            return this;
        }

        public void OnClicked(bool isActive)
        {
            selected.gameObject.SetActive(isActive);
        }
    } 
}

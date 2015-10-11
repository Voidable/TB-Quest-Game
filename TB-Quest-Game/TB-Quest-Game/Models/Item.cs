﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_Quest_Game
{
    class Item
    {
        #region [ ENUMERATIONS ]

        public enum ItemTypes
        {
            Flashlight,
            Handgun,
            Bandage,
            Bullet,
            GenericItem
        }

        #endregion

        #region [ FIELDS ]

        private string _name;
        private string _description;
        private ItemTypes _itemType;
        private int _quantity;
        private bool _visibleInsideInventory;

        #endregion


        #region [ PROPERTIES ]

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public ItemTypes ItemType
        {
            get { return _itemType; }
            set { _itemType = value; }
        }

        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        public bool VisibleInsideInventory
        {
            get { return _visibleInsideInventory; }
        }

        #endregion

        #region [ CONSTRUCTORS ]

        /// <summary>
        /// Default constructor, sets values based on type of item
        /// </summary>
        /// <param name="type">Type of item</param>
        /// <param name="quanity"></param>
        public Item(ItemTypes type, int quanity)
        {
            switch (type)
            {
                case ItemTypes.Flashlight:
                    _name = "Flashlight";
                    _description = "It shines a light on things";
                    _itemType = type;
                    _visibleInsideInventory = true;
                    _quantity = quanity;
                    break;

                case ItemTypes.Handgun:
                    _name = "Handgun";
                    _description = "Classic Handgun, very reliable";
                    _itemType = type;
                    _visibleInsideInventory = true;
                    _quantity = quanity;
                    break;

                case ItemTypes.Bandage:
                    _name = "Bandage";
                    _description = "Helps Patch you up";
                    _itemType = type;
                    _visibleInsideInventory = false;
                    _quantity = quanity;
                    break;

                case ItemTypes.Bullet:
                    _name = "Bullet";
                    _description = "Guns shoot these";
                    _itemType = type;
                    _visibleInsideInventory = false;
                    _quantity = quanity;
                    break;

                default:
                    _name = "Generic Cube";
                    _description = "Its generic, almost too generic. How did you get this?";
                    _itemType = type;
                    _visibleInsideInventory = true;
                    _quantity = quanity;
                    break;

            }
        }

        #endregion
    }
}

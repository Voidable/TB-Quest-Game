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
            Bullet
        }

        #endregion

        #region [ FIELDS ]

        private string _name;
        private string _description;
        private ItemTypes _itemType;
        private int _quantity;

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

        #endregion
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kepler_22_B.API.Characteres;
using Kepler_22_B.API.Map;

namespace Kepler_22_B.API
{
    public class World
    {

        List<CTPlayer> _listOfPlayer;
        List<CTNPC> _listOfNPC;
        Level _level;

        /// <summary>
        /// Initializes a new instance of the <see cref="World"/> class.
        /// </summary>
        public World()
        {
            _level = new Level(this);
        }


    }
}


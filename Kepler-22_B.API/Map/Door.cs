﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kepler_22_B.API.Map
{
    public class Door
    {
        Door _nextDoor;
        Vector2 _moreThan, _lowerThan;
        string _doorPosition;

        /// <summary>
        /// Initializes a new instance of the <see cref="Door"/> class.
        /// </summary>
        /// <param name="moreThan">The more than.</param>
        /// <param name="lowerThan">The lower than.</param>
        /// <param name="doorPosition">The door position.</param>
        public Door(Vector2 moreThan, Vector2 lowerThan, string doorPosition)
        {
            _moreThan = moreThan;
            _lowerThan = lowerThan;
            _doorPosition = doorPosition;
        }

        /// <summary>
        /// Gets or sets the next door.
        /// </summary>
        /// <value>
        /// The next door.
        /// </value>
        public Door NextDoor { get { return _nextDoor; } set { _nextDoor = value; } }

        /// <summary>
        /// Gets the more than.
        /// </summary>
        /// <value>
        /// The more than.
        /// </value>
        public Vector2 MoreThan { get { return _moreThan; } }

        /// <summary>
        /// Gets or sets the lower than.
        /// </summary>
        /// <value>
        /// The lower than.
        /// </value>
        public Vector2 LowerThan { get { return _lowerThan; } }

        /// <summary>
        /// Gets the door position.
        /// </summary>
        /// <value>
        /// The door position.
        /// </value>
        public string DoorPosition { get { return _doorPosition; } }
    }
}

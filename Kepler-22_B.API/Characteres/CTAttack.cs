﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kepler_22_B.API.Characteres
{
    public class CTAttack
    {
        CTCharacterType _context;
        Random r;

        /// <summary>
        /// Initializes a new instance of the <see cref="CTAttack"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public CTAttack(CTCharacterType context)
        {
            r = new Random();
            _context = context;
        }


        /// <summary>
        /// Attack function
        /// First if: Critical attack
        /// Second if : Normal attack
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="receiver"></param>
        /// <param name="damageSender"></param>
        /// <param name="armorReceiver"></param>
        /// <returns></returns>
        public int Attack(CTCharacter sender, CTCharacter receiver, int damageSender, double armorReceiver)
        {
            int random = r.Next(1, 6);
            if (random > 3) return receiver.LifePoint -= (sender.GetCharacterType.GetContext.GetDamage * receiver.GetCharacterType.GetContext.GetArmor) * random;
            else if (random <= 3 && random >= 1) return receiver.LifePoint -= (sender.GetCharacterType.GetContext.GetDamage * receiver.GetCharacterType.GetContext.GetArmor) * random;
            else return 0;
        }


    }
}
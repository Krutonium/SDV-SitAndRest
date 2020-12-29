using StardewModdingAPI;
using System;
using StardewModdingAPI.Events;
using StardewValley;

namespace SitAndRest
{
    public class ModEntry : Mod
    {
        public override void Entry(IModHelper helper)
        {
            helper.Events.GameLoop.UpdateTicked += GameLoopOnUpdateTicked;
        }
        private void GameLoopOnUpdateTicked(object sender, UpdateTickedEventArgs e)
        {
            if (Context.IsWorldReady)
            {
                if (Game1.player.isSitting)
                {
                    if (e.IsOneSecond)
                    {
                        if (Game1.player.health != Game1.player.maxHealth)
                        {
                            Game1.player.health += 1;
                        }
                        int roundedUp = (int)Math.Ceiling(Game1.player.stamina);
                        Game1.player.stamina = roundedUp;
                        if (roundedUp != Game1.player.MaxStamina)
                        {
                            Game1.player.stamina += 1;
                        }
                    }
                }
            }
        }
    }
}

using StardewModdingAPI;
using System;
using Microsoft.Xna.Framework;
using StardewModdingAPI.Events;
using StardewValley;

namespace SitAndRest
{
    public class ModEntry : Mod
    {
        private ModConfig Config;
        public override void Entry(IModHelper helper)
        {
            helper.Events.GameLoop.UpdateTicked += GameLoopOnUpdateTicked;
            this.Config = this.Helper.ReadConfig<ModConfig>();
        }
        private void GameLoopOnUpdateTicked(object sender, UpdateTickedEventArgs e)
        {
            if (Context.IsWorldReady)
            {
                if (Game1.player.isSitting)
                {
                    if (e.IsOneSecond)
                    {
                        if (Game1.player.health < Game1.player.maxHealth)
                        {
                            if (Game1.player.health + Config.HealthPerSecond > Game1.player.maxHealth)
                            {
                                Game1.player.health = Game1.player.maxHealth;
                            }
                            else
                            {
                                Game1.player.health += Config.HealthPerSecond;
                            }
                        }
                        int roundedUp = (int)Math.Ceiling(Game1.player.stamina);
                        Game1.player.stamina = roundedUp; //normalize it a bit.
                        
                        if (roundedUp < Game1.player.MaxStamina)
                        {
                            if (roundedUp + Config.EnergyPerSecond > Game1.player.maxStamina)
                            {
                                Game1.player.stamina = Game1.player.maxStamina;
                            }
                            else
                            {
                                Game1.player.stamina += Config.EnergyPerSecond;
                            }
                            
                        }
                    }
                }
            }
        }
        class ModConfig
        {
            public int HealthPerSecond = 1;
            public int EnergyPerSecond = 1;
        }
    }
}

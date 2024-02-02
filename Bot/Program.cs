using System;
using SC2APIProtocol;

namespace Bot
{
    internal class Program
    {
        private static readonly Bot bot = new ReejBot();
        private const Race race = Race.Terran;

        private static readonly string mapName = "TritonLE.SC2Map";

        private static readonly Race opponentRace = Race.Random;
        private static readonly Difficulty opponentDifficulty = Difficulty.Hard;

        public static GameConnection gc;

        private static void Main(string[] args)
        {
            try
            {
                gc = new GameConnection();
                if (args.Length == 0)
                {
                    gc.readSettings();
                    gc.RunSinglePlayer(bot, mapName, race, opponentRace, opponentDifficulty).Wait();
                }
                else
                    gc.RunLadder(bot, race, args).Wait();
            }
            catch (Exception ex)
            {
                Logger.Info(ex.ToString());
            }

            Logger.Info("Terminated");
        }
    }
}
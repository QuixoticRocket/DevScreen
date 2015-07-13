using System;

namespace DevScreen
{
    public class RandomTextGetter : ITextGetter
    {
        Random r = new Random(DateTime.UtcNow.Millisecond + DateTime.UtcNow.Second);

        private string[] randomText = new string[] {"Testing firewall...", 
                                                    "Dividing by zero",
                                                    "Reticulating Splines",
                                                    " - - - - H a c k i n g - - - ",
                                                    "downloading ALL the pr0ns",
                                                    "<inserting> highly important //looking text",
                                                    "moar code here!!!",
                                                    "<< Summoning Daemons >>",
                                                    "applying arcane warding",
                                                    "Glitching out %$-!",
                                                    "_loading_Stuff.dll_",
                                                    "@@ more coffee required",};

        public string GetText()
        {
            return randomText[r.Next(0, randomText.Length)];
        }
    }
}

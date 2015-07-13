using System;

namespace DevScreen
{
    public class RandomTextGetter : ITextGetter
    {
        Random r = new Random(DateTime.UtcNow.Millisecond + DateTime.UtcNow.Second);

        private string[] randomText = new string[] 
        {"Testing firewall...", 
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
        "@@ more coffee required",
        "... contemplating life ...",
        "ACCESSING SECTOR 1020 16 63",
        "Daktaklakpak 5576 squared!",
        "[Receiving commands from Skynet]",
        "/// polishing the code",
        "doing the NO-OP sliiiiide",
        "^ repeating previous statement ^",
        "Email, Email, wa wa, the Email",
        "Evaluating Biorythmic Flow",
        "#90210",
        "$$ Rebooting the internet",
        "User.Following(WhiteRabbit)",
        "I can carry nearly eighty gigs of data in my head.",
        "My codename is project two-five-zero-one. ",
        "+++ COMPILING +++",
        "--- DECOMPILING ---",
        ":: Dance ::",
        "~@!zzt",};

        public string GetText()
        {
            return randomText[r.Next(0, randomText.Length)];
        }
    }
}

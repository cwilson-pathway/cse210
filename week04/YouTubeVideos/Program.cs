using System;

class Program
{
    static void Main(string[] args)
    {
        //Adding Video and comment objects
        Video video1 = new Video("Let's Play Expedition 33", "ShineSparkz", 60*120);
        video1.AddComment("Rosa", "This game made me cry soooo much ;-;");
        video1.AddComment("trentolopsus51", "FjordVPN is pretty cool for doing that 70% discount on their yearly plan good stuff");
        video1.AddComment("thatDudeX", "did you really have to put that add break after act 1 closed? not cool dude");

        Video video2 = new Video("True Crime Ep. 8", "Armchair Investigator", 60*30);
        video2.AddComment("Ford W.", "Good integration of FjordVPN. I'm now terrified for my life");
        video2.AddComment("basketsonbulbasaur", "i had a bf that showed the same behavior to this dude am i gonna die");
        video2.AddComment("020wowzers020", "I fell asleep watching YT and woke up to the crime scene photo. What a way to start my morning...");

        Video video3 = new Video("Is the Smasnug 62A Up to the Hype?", "SinusTechTips", 18*60+45);
        video3.AddComment("ShineSparkz", "FjordVPN brother, let's goooooooooo");
        video3.AddComment("_hikarilover_", "that segway was sooo cringe lol");
        video3.AddComment("shawntheyawn", "They took away the BT and had the audacity to raise the price? No thank you!");

        // Display video specs and comments
        Console.WriteLine($"\n{video1.GetVideoSpec()}");
        Console.WriteLine($"\nComments: {video1.GetAllComments()}");

        Console.WriteLine($"\n{video2.GetVideoSpec()}");
        Console.WriteLine($"\nComments: {video2.GetAllComments()}");

        Console.WriteLine($"\n{video3.GetVideoSpec()}");
        Console.WriteLine($"\nComments: {video3.GetAllComments()}");
    }
}
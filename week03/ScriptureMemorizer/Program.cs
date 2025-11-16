/*
Author: Christian Monroe Wilson

Purpose: To select a random scripture and hide words progressively so that the user can memorize them. Exceeded requirements by
Adding the ability to show previously hidden words and show all hidden words to assist in the memorization process.
*/


using System;

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> _scriptures = new List<Scripture>();
        Random random = new Random();

        // Create new Scripture objects.
        Scripture _scripture1 = new Scripture(new Reference("John", 3, 16), 
        "16 For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.");

        Scripture _scripture2 = new Scripture(new Reference("2 Nephi", 32, 8, 9),
        "8 And now, my beloved brethren, I perceive that ye ponder still in your hearts; and it grieveth me that I must speak concerning this thing. For if \nye would hearken unto the Spirit which teacheth a man to pray, ye would know that ye must pray; for the evil spirit teacheth not a man to pray, but \nteacheth him that he must not pray." +
        "\n9 But behold, I say unto you that ye must pray always, and not faint; that ye must not perform any thing unto the Lord save in the first place ye \nshall pray unto the Father in the name of Christ, that he will consecrate thy performance unto thee, that thy performance may be for the welfare of \nthy soul.");

        Scripture _scripture3 = new Scripture(new Reference("D&C", 58, 42, 43),
        "42 Behold, he who has repented of his sins, the same is forgiven, and I, the Lord, remember them no more." +
        "\n43 By this ye may know if a man repenteth of his sins—behold, he will confess them and forsake them.");

        _scriptures.Add(_scripture1);
        _scriptures.Add(_scripture2);
        _scriptures.Add(_scripture3);

        // Display a random Scripture from a list of Scriptures.
        Scripture _chosenScripture = _scriptures[random.Next(0,_scriptures.Count - 1)];

        do
        {
            
            // On enter, hide a random set of Words. If 'quit' is entered, break the loop. Else, it's an invalid entry.
            Console.Write(_chosenScripture.GetDisplayText() +
            "\n\nPlease press enter to continue, 'show previous' to show the most recent hidden words, 'show all' to show the scripture, or type 'quit' to finish: ");
            string userInput = Console.ReadLine();
            Console.Clear();

            if (userInput == "")
            {
                _chosenScripture.HideRandomWords(random.Next(3,5));
            }
            else if (userInput.ToLower() == "quit")
            {
                break;
            }
            else if (userInput.ToLower() == "show previous")
            {
                _chosenScripture.ShowPrevious();
            }
            else if (userInput.ToLower() == "show all")
            {
                _chosenScripture.ShowAll();
            }
            else
            {
                Console.WriteLine("!!! The input was invalid. Please try again. !!!\n");
            }        

        } while (!_chosenScripture.IsCompletelyHidden());

        // I couldn't figure out how to delay the program from closing like in the video, so I made sure to display the empty verse
        // before the program closed.
        Console.WriteLine("The scripture is completely hidden. Can you recite it by memory?");
        Console.WriteLine(_chosenScripture.GetDisplayText());

        Console.WriteLine("\nThe program will now close. Run again to try another scripture!");

    }
}
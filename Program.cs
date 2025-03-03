// the ourAnimals array will store the following: 
string animalSpecies = "";
string animalID = "";
string animalAge = "";
string animalPhysicalDescription = "";
string animalPersonalityDescription = "";
string animalNickname = "";
string suggestedDonation = "";

// variables that support data entry
int maxPets = 8;
string? readResult;
string menuSelection = "";
decimal decimalDonation = 0.00m;

// array used to store runtime data, there is no persisted data
string[,] ourAnimals = new string[maxPets, 7];

// TODO: Convert the if-elseif-else construct to a switch statement

// create some initial ourAnimals array entries
for (int i = 0; i < maxPets; i++)
{
    switch (i)
    {
        case 0:
            animalSpecies = "dog";
            animalID = "d1";
            animalAge = "2";
            animalPhysicalDescription = "medium sized cream colored female golden retriever weighing about 65 pounds. housebroken.";
            animalPersonalityDescription = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
            animalNickname = "lola";
            suggestedDonation = "85.00";
            break;
        case 1:
            animalSpecies = "dog";
            animalID = "d2";
            animalAge = "9";
            animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
            animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
            animalNickname = "loki";
            suggestedDonation = "49.99";
            break;
        case 2:
            animalSpecies = "cat";
            animalID = "c3";
            animalAge = "1";
            animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
            animalPersonalityDescription = "friendly";
            animalNickname = "Puss";
            suggestedDonation = "40.00";
            break;
        case 3:
            animalSpecies = "cat";
            animalID = "c4";
            animalAge = "?";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            suggestedDonation = "";
            break;
        default:
            animalSpecies = "";
            animalID = "";
            animalAge = "";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            suggestedDonation = "";
            break;
    }

    ourAnimals[i, 0] = "ID #: " + animalID;
    ourAnimals[i, 1] = "Species: " + animalSpecies;
    ourAnimals[i, 2] = "Age: " + animalAge;
    ourAnimals[i, 3] = "Nickname: " + animalNickname;
    ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
    ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;
    //ourAnimals[i, 6] = "Suggested Donation: " + suggestedDonation;
    if (!decimal.TryParse(suggestedDonation, out decimalDonation))
    {
        decimalDonation = 45.00m; // if suggestedDonation NOT a number, default to 45.00

    }
    ourAnimals[i, 6] = $"Suggested Donation: {decimalDonation:C2}";
}

do
{

    // display the top-level menu options

    Console.Clear();

    Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
    Console.WriteLine(" 1. List all of our current pet information");
    Console.WriteLine(" 2. Add a new animal friend to the ourAnimals array");
    Console.WriteLine(" 3. Ensure animal ages and physical descriptions are complete");
    Console.WriteLine(" 4. Ensure animal nicknames and personality descriptions are complete");
    Console.WriteLine(" 5. Edit an animal’s age");
    Console.WriteLine(" 6. Edit an animal’s personality description");
    Console.WriteLine(" 7. Display all cats with a specified characteristic");
    Console.WriteLine(" 8. Display all dogs with specified characteristic's");
    Console.WriteLine();
    Console.WriteLine("Enter your selection number (or type Exit to exit the program)");

    readResult = Console.ReadLine();
    if (readResult != null)
    {
        menuSelection = readResult.ToLower();
    }

    //Console.WriteLine($"You selected menu option {menuSelection}.");
    //Console.WriteLine("Press the Enter key to continue");

    // pause code execution
    //readResult = Console.ReadLine();

    switch (menuSelection)
    {
        case "1":
            // List all of our current pet information
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    Console.WriteLine();
                    for (int j = 0; j < 7; j++)
                    {
                        Console.WriteLine(ourAnimals[i, j]);
                    }
                }
            }
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        case "2":
            // Add a new animal friend to the ourAnimals array
            string anotherPet = "y";
            int petCount = 0;
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    petCount += 1;
                }

            }

            if (petCount < maxPets)
            {
                Console.WriteLine($"We currently have {petCount} pets that need homes. We can manage {(maxPets - petCount)} more.");
            }

            while (anotherPet == "y" && petCount < maxPets)
            {
                bool validEntry = false;
                // get species (cat or dog) - string animalSpecies is a required field 
                do
                {
                    Console.WriteLine("\n\rEnter 'dog' or 'cat' to begin a new entry");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalSpecies = readResult.ToLower();
                        if (animalSpecies != "dog" && animalSpecies != "cat")
                        {
                            validEntry = false;
                        }
                        else
                        {
                            validEntry = true;
                        }

                    }
                } while (validEntry == false);

                // build the animal the ID number - for example C1, C2, D3 (for Cat 1, Cat 2, Dog 3)
                animalID = animalSpecies.Substring(0, 1) + (petCount + 1).ToString();

                // get the pet's age. can be ? at initial entry. 
                do
                {
                    int petAge;
                    Console.WriteLine("Enter the pet's age or enter ? if unknown");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalAge = readResult;
                        if (animalAge != "?")
                        {
                            validEntry = int.TryParse(animalAge, out petAge);
                        }
                        else
                        {
                            validEntry = true;
                        }
                    }
                } while (validEntry == false);

                do
                {
                    Console.WriteLine("Enter a physical description of the pet (size, color, gender, weight, housebroken)");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalPhysicalDescription = readResult.ToLower();
                        if (animalPhysicalDescription == "")
                        {
                            animalPhysicalDescription = "tbd";
                        }
                    }
                } while (animalPhysicalDescription == "");

                // get a description of the pet's personality - animalPersonalityDescription can be blank.
                do
                {
                    Console.WriteLine("Enter a description of the pet's personality (likes or dislikes, tricks, energy level)");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalPersonalityDescription = readResult.ToLower();
                        if (animalPersonalityDescription == "")
                        {
                            animalPersonalityDescription = "tbd";
                        }
                    }
                } while (animalPersonalityDescription == "");

                // get the pet's nickname. animalNickname can be blank.
                do
                {
                    Console.WriteLine("Enter a nickname for the pet");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalNickname = readResult.ToLower();
                        if (animalNickname == "")
                        {
                            animalNickname = "tbd";
                        }
                    }
                } while (animalNickname == "");

                // store the pet information in the ourAnimals array (zero based)
                ourAnimals[petCount, 0] = "ID #: " + animalID;
                ourAnimals[petCount, 1] = "Species: " + animalSpecies;
                ourAnimals[petCount, 2] = "Age: " + animalAge;
                ourAnimals[petCount, 3] = "Nickname: " + animalNickname;
                ourAnimals[petCount, 4] = "Physical description: " + animalPhysicalDescription;
                ourAnimals[petCount, 5] = "Personality: " + animalPersonalityDescription;

                petCount = petCount + 1;
                if (petCount < maxPets)
                {
                    // another pet?
                    Console.WriteLine("Do you want to enter info for another pet (y/n)");
                    do
                    {
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            anotherPet = readResult.ToLower();
                        }

                    } while (anotherPet != "y" && anotherPet != "n");
                }
            }

            if (petCount >= maxPets)
            {
                Console.WriteLine("We have reached our limit on the number of pets that we can manage.");
                Console.WriteLine("Press the Enter key to continue.");
                readResult = Console.ReadLine();
            }

            break;

        case "3":
            // Ensure animal ages and physical descriptions are complete
            for (int i = 0; i < maxPets; i++)
            {
                bool validAge = false;
                bool validPhysicalDescription = true;

                if (ourAnimals[i, 0] != "ID #: ")
                {
                    if (ourAnimals[i, 2] == "Age: ?")
                    {
                        validAge = false;
                    }
                    else
                    {
                        validAge = true;
                    }

                    if (ourAnimals[i, 4] == "Physical description: ")
                    {
                        validPhysicalDescription = false;
                    }
                    else
                    {
                        validPhysicalDescription = true;
                    }

                    // Ensure valid animal age
                    while (!validAge)
                    {
                        Console.WriteLine($"Current age for {ourAnimals[i, 0]} is {ourAnimals[i, 2]}. Please enter a valid age:");
                        readResult = Console.ReadLine();
                        if (readResult != null && readResult != "?")
                        {
                            if (int.TryParse(readResult, out _))
                            {
                                ourAnimals[i, 2] = readResult;
                                validAge = true;
                            }
                            else
                            {
                                Console.WriteLine("Invalid age. Please enter a numeric value.");
                            }
                        }
                        else
                        {
                            validAge = true; // allow '?' as a valid input
                        }
                    }

                    // Ensure valid physical description
                    while (!validPhysicalDescription)
                    {
                        Console.WriteLine("Enter a physical description for ID #: c4 (size, color, gender, weight, housebroken)");
                        readResult = Console.ReadLine();
                        if (readResult != null && readResult.Trim().Length > 0)
                        {
                            ourAnimals[i, 4] = readResult;
                            validPhysicalDescription = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid physical description. Please enter a non-empty description.");
                        }
                    }
                }
            }
            Console.WriteLine("Age and physical description fields are complete for all of our friends. Press the Enter key to continue");
            readResult = Console.ReadLine();

            break;

        case "4":
            // Ensure animal nicknames and personality descriptions are complete
            for (int i = 0; i < maxPets; i++)
            {
                //bool validAnimalNickname = false;
                //bool validPersonalityDescription = false;

                if (ourAnimals[i, 0] != "ID #: ")
                {
                    bool validAnimalNickname = false;
                    bool validPersonalityDescription = false;

                    if (ourAnimals[i, 3] == "Nickname: ")
                    {
                        validAnimalNickname = false;
                    }
                    else
                    {
                        validAnimalNickname = true;
                    }

                    if (ourAnimals[i, 5] == "Personality: ")
                    {
                        validPersonalityDescription = false;
                    }
                    else
                    {
                        validPersonalityDescription = true;
                    }

                    // Ensure valid animal age
                    while (!validAnimalNickname)
                    {
                        Console.WriteLine("Enter a nickname: ");
                        readResult = Console.ReadLine();
                        if (readResult != null && readResult.Trim().Length > 0)
                        {
                            ourAnimals[i, 3] = "Nickname: " + readResult;
                            validAnimalNickname = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid nickname. Please enter a non-empty nickname.");
                        }
                    }

                    // Ensure valid personality description
                    while (!validPersonalityDescription)
                    {
                        Console.WriteLine("Enter a personality description: ");
                        readResult = Console.ReadLine();
                        if (readResult != null && readResult.Trim().Length > 0)
                        {
                            ourAnimals[i, 5] = "Personality: " + readResult;
                            validPersonalityDescription = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid personality description. Please enter a non-empty description.");
                        }
                    }
                }
            }
            Console.WriteLine("Nickname and personality description fields are complete for all of our friends. Press the Enter key to continue");
            readResult = Console.ReadLine();

            break;

        case "5":
            //
            Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        case "6":
            // #1 Display all dogs with a multiple search characteristics
            Console.WriteLine("\n\rPress the Enter key to continue");
            readResult = Console.ReadLine();

            break;

        case "7":
            // Display all cats with a specified characteristic
            string catCharacteristic = "";

            while (catCharacteristic == "")
            {
                // have the user enter physical characteristics to search for
                Console.WriteLine($"\nEnter one desired cat characteristics to search for");
                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    catCharacteristic = readResult.ToLower().Trim();
                }

            }

            string catDescription = "";

            bool noMatchesCat = true;

            // #6 loop through the ourAnimals array to search for matching animals
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 1].Contains("cat"))
                {
                    // #7 Search combined descriptions and report results
                    catDescription = ourAnimals[i, 4] + "\n" + ourAnimals[i, 5];
                    if (catDescription.Contains(catDescription))
                    {
                        Console.WriteLine($"\nOur cat {ourAnimals[i, 3]} is a match!");
                        Console.WriteLine(catDescription);

                        noMatchesCat = false;
                    }
                }
            }

            if (noMatchesCat)
            {
                Console.WriteLine("None of our cats are a match found for: " + catCharacteristic);
            }

            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        case "8":
            // #1 Display all dogs with a multiple search characteristics

            string dogCharacteristic = "";

            while (dogCharacteristic == "")
            {
                // #2 have user enter multiple comma separated characteristics to search for
                Console.WriteLine($"\r\nEnter desired dog characteristic's seperated by a comma to search for");
                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    dogCharacteristic = readResult.ToLower().Trim();
                    Console.WriteLine();
                }
            }

            string[] characteristicsArray = dogCharacteristic.Split(',');

            bool noMatchesDog = true;
            string dogDescription = "";

            // #4 update to "rotating" animation with countdown
            string[] searchingIcons = { "2.. ", "1.. ", "0!" };
            char[] wheel = { '|', '/', '-', '\\' };

            // loop ourAnimals array to search for matching animals
            for (int i = 0; i < maxPets; i++)
            {

                if (ourAnimals[i, 1].Contains("dog"))
                {

                    // Search combined descriptions and report results
                    dogDescription = ourAnimals[i, 4] + "\r\n" + ourAnimals[i, 5];
                    bool isMatch = true;

                    for (int j = 2; j >= 0; j--)
                    {
                        foreach (char icon in wheel)
                        {
                            Console.Write($"\rSearching our dog {ourAnimals[i, 3]} for characteristics {icon} {j}..");
                            Thread.Sleep(250); // Adjusted to fit the total of 3 seconds (125 ms * 4 * 6 = 3000 ms = 3 seconds)
                        }
                        // #5 update "searching" message to show countdown 
                        // foreach (string icon in searchingIcons)
                        // {
                        //     Console.Write($"\rsearching our dog {ourAnimals[i, 3]} for {dogCharacteristic} {icon}");
                        //     Thread.Sleep(250);
                        // }

                        Console.Write($"\r{new String(' ', Console.BufferWidth)}");
                    }

                    foreach (string characteristic in characteristicsArray)
                    {
                        string trimmedCharacteristic = characteristic.Trim();
                        if (!dogDescription.Contains(trimmedCharacteristic))
                        {
                            isMatch = false;
                            break;
                        }
                    }

                    if (isMatch)
                    {
                        Console.WriteLine($"\nOur dog {ourAnimals[i, 3]} is a match!");
                        Console.WriteLine($"Description: {dogDescription}");
                        noMatchesDog = false;
                    }


                    // #3d if "this dog" is match write match message + dog description
                }
            }

            if (noMatchesDog)
            {
                Console.WriteLine("None of our dogs are a match found for: " + dogCharacteristic);
            }

            Console.WriteLine("\n\rPress the Enter key to continue");
            readResult = Console.ReadLine();

            break;

        default:
            break;

    }

} while (menuSelection != "exit");
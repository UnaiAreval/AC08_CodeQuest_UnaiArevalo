using System;

class Program
{
    static void Main()
    {
        const string MenuTitle = "===== MAIN MENU - CODEQUEST =====";
        const string MenuOption1 = "1. Train your wizard";
        const string MenuOption2 = "2. Check the dungeon";
        const string MenuOption3 = "3. Loot the mine";
        const string MenuOptionExit = "0. Exit game";
        const string MenuPrompt = "Choose an option (1-3) - (0) to exit: ";
        const string InputErrorMessage = "Invalid input. Please enter a number between 0 and 3.";
        const string MsgGoodBye = """
            
            See you, have a nice day

            """;
        const string ShowOptionChosen = "Option {0} \n";
        const string PresToContinue = "\nPrem qualsevol tecla per continuar...";

        //chapter one consts
        const string AskWizardName = """
            What's your wizard name?
            -> 
            """;
        const string DiariMessage = """

            Dia {0} : {1}
            Hores de meditació: {2}
            Poder: {3} pts
            """;
        const string WizardLevelInfo = "El mac {0} té el nivell de {1}";
        //used when points < 20
        const string MsgLessThanTwentee = "Repeteix a 2a convocatòria";
        const string LevelLessThanTwentee = "Raoden el Elantri";
        //used when points >= 20
        const string MsgBiggerThanTwentee = "Encara confons la vareta amb una cullera";
        const string LevelBiggerThanTwentee = "Zyn el Buguejat";
        //used when points >= 30 && points < 35
        const string MsgRangeTherteeAndTherteefive = "Ets un Invocador de Brises Màgiques";
        const string LevelRangeTherteeAndTherteefive = "Arka Nullpointer";
        //used when points >= 35 && points < 40
        const string MsgRangeTherteefiveAndFourtee = "Uau!  Pots invocar dracs sense cremar el laboratori!";
        const string LevelRangeTherteefiveAndFourtee = "Elarion de les Brases";
        //used when points >= 40
        const string MsgBiggerThanFourtee = " Has assolit el rang de Mestre dels Arcans";
        const string LevelBiggerThanFourtee = "ITB-Wizard el Gris";
        const int DaysOfTraining = 5;
        const int MaxPointsPerDay = 10;
        const int MinPointsPerDay = 1;
        const int MaxHouersOfTrainingPerDay = 24;

        Random random = new Random();
        string wizardName;
        string wizardLevel;
        int op = 0;
        int wizardPoints;
        int trainedHouers;
        bool validInput;

        do
        {
            Console.Clear();
            Console.WriteLine(MenuTitle);
            Console.WriteLine(MenuOption1);
            Console.WriteLine(MenuOption2);
            Console.WriteLine(MenuOption3);
            Console.WriteLine(MenuOptionExit);
            Console.Write(MenuPrompt);

            validInput = true;

            try
            {
                op = Convert.ToInt32(Console.ReadLine());

            }
            catch (FormatException)
            {
                Console.WriteLine(InputErrorMessage);
                validInput = false;
            }
            catch (Exception)
            {
                Console.WriteLine(InputErrorMessage);
                validInput = false;
            }

            if (validInput)
            {
                Console.Clear();
                Console.WriteLine(ShowOptionChosen, op);
            }

            switch (op)
            {
                case 1:
                    Console.Write(AskWizardName);
                    wizardName = Console.ReadLine();
                    wizardPoints = 1;

                    for (int i = 0; i < DaysOfTraining; i++)
                    {
                        trainedHouers = random.Next(1, MaxHouersOfTrainingPerDay + 1);
                        if (trainedHouers > 0)
                        {
                            wizardPoints = wizardPoints + random.Next(MinPointsPerDay, MaxPointsPerDay + 1);
                        }
                        Console.WriteLine(DiariMessage, i + 1, wizardName, trainedHouers, wizardPoints);
                        Thread.Sleep(1000);
                    }

                    if (wizardPoints >= 40)
                    {
                        wizardLevel = LevelBiggerThanFourtee;
                        Console.WriteLine(MsgBiggerThanFourtee);
                    }
                    else if (wizardPoints >= 35)
                    {
                        wizardLevel = LevelRangeTherteefiveAndFourtee;
                        Console.WriteLine(MsgRangeTherteefiveAndFourtee);
                    }
                    else if (wizardPoints >= 30)
                    {
                        wizardLevel = LevelRangeTherteeAndTherteefive;
                        Console.WriteLine(MsgRangeTherteeAndTherteefive);
                    }
                    else if (wizardPoints >= 20)
                    {
                        wizardLevel = LevelBiggerThanTwentee;
                        Console.WriteLine(MsgBiggerThanTwentee);
                    }
                    else
                    {
                        wizardLevel = LevelLessThanTwentee;
                        Console.WriteLine(MsgLessThanTwentee);
                    }
                    Console.WriteLine(WizardLevelInfo, wizardName, wizardLevel);
                    Console.WriteLine(PresToContinue);
                    Console.ReadKey();
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 0:
                    Console.WriteLine(MsgGoodBye);
                    break;
            }


        } while (op != 0);
    }
}
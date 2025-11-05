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
        const string MsgBiggerThanFourtee = "Has assolit el rang de Mestre dels Arcans";
        const string LevelBiggerThanFourtee = "ITB-Wizard el Gris";
        const int DaysOfTraining = 5;
        const int MaxPointsPerDay = 10;
        const int MinPointsPerDay = 1;
        const int MaxHouersOfTrainingPerDay = 24;

        //chapter two consts
        const string MsgDragonDors = """
            Per entrar al Calabós del Drac RAMón el Poderós hauras de passar per {0} portes.
            Cada porta té un codi numeric entre 1 i 5. Tens {1} intents per obrir cada porta.
            """;
        const string DorAndTrie = """

            Porta {0} : Intent {1}
            Enter the code: 
            """;
        const string FailOpeningDor = "El drac ha detectat la teva presència i t’ha expulsat del servidor!";
        const string SuccedOpeningDor = "El drac et respecta. Has desbloquejat el següent nivell!";
        const string AllDorsPassed = "Has desbloquejat el nivell final. Prepara’t per la batalla!";

        //chapter three consts
        const string MsgEnterMine = """
            Despres de derrotar al drac has trobat una mina de bitcoins.
            Podras dur a terme {0} excavasions per tal d'aconseguir riqueses, però potser que no trobis res.
            """;
        const string NoBitsFound = "EXCAVACIO {0} - No has tingut sort, has trobat 0 bits.";
        const string BitsFound = "EXCAVACIO {0} - Has aconseguit {1} bits";
        const string SmollTotalBits = """

            Havent acabat les excavasions el teu total de bits és de {0}.
            La teva targeta màgia encara és integrada. Toca derrotar a un altre drac!
            """; //if you have less than the minimum bits
        const string CorrectTotalBits = """
            
            Havent acabat les excavasions el teu total de bits és de {0}.
            Has desbloquejat la GPU d’or! Els teus encanteris van ara a 120 FPS!
            """;
        const int ExcavationsNum = 5;
        const int MinBitsFound = 5;
        const int MaxBitsFound = 50;//the min and the max value of bits you can find in an excavation
        const int MinCorrectBits = 200; //you should have this amount of total bits at the end of the chapter

        Random random = new Random();
        string wizardName;
        string wizardLevel;
        int op = 0;
        int wizardPoints;
        int trainedHouers;
        int dorsNumber = 3;
        int triesPerDor = 3;
        int dorCode; //the dor code
        int readDorCode; //the code that the user introduce
        int totalBits;
        int bitsFound;
        int foundBits; //if 0 then you don't find bits, if =1 then you find bits. Used with a random to change its value in each excavation.
        bool validInput;
        bool validDorCode = true; //initialized to solve an error

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
                    break;
                case 2:
                    Console.WriteLine(MsgDragonDors, dorsNumber, triesPerDor);

                    for (int i = 0; i < dorsNumber; i++)
                    {
                        dorCode = random.Next(1, 6);
                        for (int j = 0; j < triesPerDor; j++)
                        {
                            do
                            {
                                Console.WriteLine(DorAndTrie, i + 1, j + 1);
                                validInput = Int32.TryParse(Console.ReadLine(), out readDorCode);
                            } while (!validInput);

                            if (dorCode == readDorCode)
                            {
                                j = triesPerDor;
                                validDorCode = true;
                            }
                            else
                            {
                                validDorCode = false;
                            }
                        }
                        if (validDorCode)
                        {
                            Console.WriteLine(SuccedOpeningDor);
                        }
                        else
                        {
                            i = dorsNumber;
                            Console.WriteLine(FailOpeningDor);
                        }
                    }
                    if (validDorCode) Console.WriteLine(AllDorsPassed);

                    break;
                case 3:
                    Console.WriteLine(MsgEnterMine, ExcavationsNum);
                    totalBits = 0;
                    Thread.Sleep(1000);

                    for (int i = 0; i < ExcavationsNum; i++)
                    {
                        foundBits = random.Next(0, 2); //0 or 1
                        if (foundBits == 1)
                        {
                            bitsFound = random.Next(MinBitsFound, MaxBitsFound + 1);
                            Console.WriteLine(BitsFound, i + 1, bitsFound);
                            totalBits += bitsFound;
                        }
                        else
                        {
                            Console.WriteLine(NoBitsFound, i + 1);
                        }
                        Thread.Sleep(1000);
                    }
                    if (totalBits >= MinCorrectBits)
                    {
                        Console.WriteLine(CorrectTotalBits, totalBits);
                    }
                    else
                    {
                        Console.WriteLine(SmollTotalBits, totalBits);
                    }
                    break;
                case 0:
                    Console.WriteLine(MsgGoodBye);
                    break;
            }
            Console.WriteLine(PresToContinue);
            Console.ReadKey();


        } while (op != 0);
    }
}
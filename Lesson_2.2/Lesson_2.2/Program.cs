using System;

namespace Lesson_2._2
{
    internal class Program
    {
        public static (Bank, (string, string)) bankAccountCreation(Bank bankAccounts, (string bankAccountValueType, string bankAccountType) bankAccountValueAndType, int FirstBankAccountNum, int i)
        {
            Console.WriteLine("Создание счета.");

            Console.WriteLine("Каким образом вы хотите создать счет?");

            Console.WriteLine("1 - Счет по умолчанию.");

            Console.WriteLine("2 - Создать счет и выбрать его тип.");

            Console.WriteLine("3 - Создать счет и внести сумму в рублях на баланс.");

            Console.WriteLine("4 - Создать счет, выбрать его тип и внести сумму в выбранной валюте на баланс.");

            string UserChoice = string.Empty;

            int checkCode = 0;

            bankAccounts = new Bank();

            do
            {
                UserChoice = Console.ReadLine();

                switch (UserChoice)
                {
                    case "1":

                        bankAccounts.BankAccountNumber = FirstBankAccountNum + i;

                        bankAccounts.Balance = 0;

                        bankAccounts.BankAccountType = 1;

                        bankAccountValueAndType.bankAccountType = "Рублевый";

                        bankAccountValueAndType.bankAccountValueType = "RUB"; checkCode = 1;
                        break;
                    case "2":
                        (int bankAccountType, string bankTypeOfAccount, string bankAccountValueType) cortage = bankTypeBankAccountCreate(bankAccountValueAndType);

                        bankAccountValueAndType.bankAccountType = cortage.bankTypeOfAccount;

                        bankAccountValueAndType.bankAccountValueType = cortage.bankAccountValueType;

                        bankAccounts.BankAccountNumber = FirstBankAccountNum + i;

                        bankAccounts.Balance = 0;

                        bankAccounts.BankAccountType = cortage.bankAccountType;

                        Console.WriteLine("Счет успешно создан.");

                        checkCode = 1;

                        break;
                    case "3":

                        (int balance, string bankTypeOfAccount, string bankAccountValueType) cortage1 = bankBalanceAccountCreate(bankAccountValueAndType);

                        bankAccountValueAndType.bankAccountType = cortage1.bankTypeOfAccount;

                        bankAccountValueAndType.bankAccountValueType = cortage1.bankAccountValueType;

                        bankAccounts.BankAccountNumber = FirstBankAccountNum + i;

                        bankAccounts.Balance = cortage1.balance;

                        bankAccounts.BankAccountType = 1;

                        Console.WriteLine("Счет успешно создан.");

                        checkCode = 1;

                        break;
                    case "4":
                        (int bankAccountType, string bankTypeOfAccount, string bankAccountValueType) cortage2 = bankTypeBankAccountCreate(bankAccountValueAndType);

                        bankAccountValueAndType.bankAccountType = cortage2.bankTypeOfAccount;

                        bankAccountValueAndType.bankAccountValueType = cortage2.bankAccountValueType;

                        (int balance, string bankTypeOfAccount, string bankAccountValueType) cortage3 = bankBalanceAccountCreate(bankAccountValueAndType);

                        bankAccounts.BankAccountNumber = FirstBankAccountNum + i;

                        bankAccounts.Balance = cortage3.balance;

                        bankAccounts.BankAccountType = cortage2.bankAccountType;

                        Console.WriteLine("Счет успешно создан.");

                        checkCode = 1;

                        break;
                    default:
                        Console.WriteLine("Введите команду корректно.");
                        break;
                }

            } while (checkCode == 0);


            return (bankAccounts, bankAccountValueAndType);

        }
        static (int, string, string) bankTypeBankAccountCreate((string bankAccountValueType, string bankAccountType) bankAccountValueAndType)
        {
            Console.WriteLine("Введите тип счета, который вы хотели бы открыть.");

            Console.WriteLine("1 - Рублевый счет");

            Console.WriteLine("2 - Бюджетный счет.");

            Console.WriteLine("3 - Валютный счет.");

            string NewUserChoice = string.Empty;

            int bankAccountType = 0;

            int checkCode = 0;

            do
            {
                NewUserChoice = Console.ReadLine();

                if (NewUserChoice == "1" || NewUserChoice == "2" || NewUserChoice == "3")
                {
                    bankAccountType = Convert.ToInt32(NewUserChoice);

                    if (bankAccountType == 1)
                    {
                        bankAccountValueAndType.bankAccountType = "Рублевый"; bankAccountValueAndType.bankAccountValueType = "RUB";
                    }
                    else if (bankAccountType == 2)
                    {
                        bankAccountValueAndType.bankAccountType = "Бюджетный"; bankAccountValueAndType.bankAccountValueType = "RUB";
                    }
                    else
                    {
                        bankAccountValueAndType.bankAccountType = "Валютный"; bankAccountValueAndType.bankAccountValueType = "USD";
                    }

                    checkCode = 1;
                }
                else
                {
                    continue;
                }

            } while (checkCode == 0);

            return (bankAccountType, bankAccountValueAndType.bankAccountType, bankAccountValueAndType.bankAccountValueType);
        }
        static (int, string, string) bankBalanceAccountCreate((string bankAccountValueType, string bankAccountType) bankAccountValueAndType)
        {
            Console.WriteLine("Введите сумму, которую вы хотите внести на счет.");

            string NewUserChoice = string.Empty;

            int CheckCode = 0;

            int Sum = 0;

            do
            {
                try
                {
                    int SumOfRubles = Convert.ToInt32(Console.ReadLine());

                    if (SumOfRubles < 0)
                    {
                        Console.WriteLine("Вы не можете положить на счет отрицательную сумму.");

                        continue;
                    }
                    else
                    {
                        bankAccountValueAndType.bankAccountType = "Рублевый"; bankAccountValueAndType.bankAccountValueType = "RUB";

                        Console.WriteLine($"На счет внесена сумма в {SumOfRubles} {bankAccountValueAndType.bankAccountValueType}");

                        Sum = SumOfRubles;

                        CheckCode = 1;
                    }
                }
                catch
                {
                    Console.WriteLine("Введите сумму в корректном формате.");
                }
            } while (CheckCode == 0);

            return (Sum, bankAccountValueAndType.bankAccountType, bankAccountValueAndType.bankAccountValueType);
        }

        static void Main()
        {
            int numberOfAccounts = 0;

            Console.WriteLine("Введите число банковских счетов.");

            do
            {
                try
                {
                    numberOfAccounts = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Введите число банковских счетов в корректном формате.");
                }
                if (numberOfAccounts < 0 || numberOfAccounts == 0)
                {
                    Console.WriteLine("Введите число банковских счетов в корректном формате.");
                }

            } while (numberOfAccounts == 0 || numberOfAccounts < 0);

            Bank[] bankAccounts = new Bank[numberOfAccounts];

            (string bankAccountValueType, string bankAccountType)[] bankAccountsValuesAndTypes = new (string, string)[numberOfAccounts];

            Random random = new Random();

            int FirstBankAccountNum = random.Next(40000000, 50000000);

            for (int i = 0; i < bankAccounts.Length; i++)
            {

                (bankAccounts[i], bankAccountsValuesAndTypes[i]) = bankAccountCreation(bankAccounts[i], bankAccountsValuesAndTypes[i], FirstBankAccountNum, i);

                Console.Clear();

            }

            string UserChoice = string.Empty;

            do
            {
                UserChoice = Console.ReadLine();

                switch (UserChoice)
                {
                    case "Информация":
                        Console.WriteLine("Введите номер аккаунта.");

                        try
                        {
                            int accountNumber = Convert.ToInt32(Console.ReadLine());

                            if (accountNumber <= 0 || accountNumber > bankAccounts.Length)
                            {
                                Console.WriteLine("Введите существующий номер счета.");

                                break;
                            }


                            bankAccountGetInfo(bankAccounts, bankAccountsValuesAndTypes, --accountNumber);
                        }
                        catch
                        {
                            Console.WriteLine("Введите номер аккаунта в корректном формате.");

                            Console.Clear();
                        }
                        break;

                    case "Выход":
                        break;
                    default:
                        Console.WriteLine("Введите запрос корректно.");
                        break;
                }
            } while (UserChoice != "Выход");

        }
        static void bankAccountGetInfo(Bank[] bank, (string bankAccountValueType, string bankAccountType)[] bankAccountsValuesAndTypes, int bankAccountNumber)
        {
            Console.WriteLine($"Номер счета: {bank[bankAccountNumber].BankAccountNumber}");

            Console.WriteLine($"Баланс: {bank[bankAccountNumber].Balance} {bankAccountsValuesAndTypes[bankAccountNumber].bankAccountValueType}");

            Console.WriteLine($"Тип счета: {bankAccountsValuesAndTypes[bankAccountNumber].bankAccountType}");
        }


    }
    public class Bank
    {
        

        private enum BankAccountInfo
        {
            bankAccountNumber = 0,

            balance = 0,

            bankAccountType = 1 // 1 Означает то, что это рублевый счет(по умолчанию). 2 Бюджетный счет. 3 Валютный.
        }

        public int BankAccountNumber { get; set; }

        public int Balance { get; set; } = (int)BankAccountInfo.balance;

        public int BankAccountType { get; set; } = (int)BankAccountInfo.bankAccountType;

    }
}

using System;

namespace Lesson_2._2
{
    internal class Program
    {
        public static (Bank, (string, string)) bankAccountCreation(Bank bankAccounts, (string bankAccountValueType, string bankAccountType) bankAccountValueAndType, int bankAccountNum)
        {
            Console.WriteLine("Введите тип счета, который вы хотели бы открыть.");

            Console.WriteLine("1 - Рублевый счет");

            Console.WriteLine("2 - Бюджетный счет.");

            Console.WriteLine("3 - Валютный счет.");
            do
            {


                bankAccountValueAndType.bankAccountType = Console.ReadLine();

                switch (bankAccountValueAndType.bankAccountType)
                {
                    case "1":

                        bankAccounts.BankAccountType = Convert.ToInt32(bankAccountValueAndType.bankAccountType);

                        bankAccounts.BankAccountNumber = bankAccounts.BankAccountNumber + bankAccountNum;

                        bankAccountValueAndType.bankAccountValueType = "RUB";

                        bankAccountValueAndType.bankAccountType = "Рублевый";

                        Console.WriteLine($"Счет успешно создан");

                        break;
                    case "2":

                        bankAccounts.BankAccountType = Convert.ToInt32(bankAccountValueAndType.bankAccountType);

                        bankAccounts.BankAccountNumber = bankAccounts.BankAccountNumber + bankAccountNum;

                        bankAccountValueAndType.bankAccountValueType = "RUB";

                        bankAccountValueAndType.bankAccountType = "Бюджетный";

                        Console.WriteLine($"Счет успешно создан");

                        break;
                    case "3":

                        bankAccounts.BankAccountType = Convert.ToInt32(bankAccountValueAndType.bankAccountType);

                        bankAccounts.BankAccountNumber = bankAccounts.BankAccountNumber + bankAccountNum;

                        bankAccountValueAndType.bankAccountValueType = "USD";

                        bankAccountValueAndType.bankAccountType = "Валютный";

                        Console.WriteLine($"Счет {bankAccountNum} успешно создан");

                        break;
                    default:
                        Console.WriteLine("Введите номер счета корректно");
                        break;



                }



            } while (bankAccountValueAndType.bankAccountType == "1" || bankAccountValueAndType.bankAccountType == "2" || bankAccountValueAndType.bankAccountType == "3");

            return (bankAccounts, bankAccountValueAndType);

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

            (string bankAccountValueType, string bankAccountType)[] bankAccountsValuesAndTypes = new (string, string) [numberOfAccounts];

            for (int i = 0; i < bankAccounts.Length; i++)
            {

                bankAccounts[i] = new Bank();

                (bankAccounts[i], bankAccountsValuesAndTypes[i]) = bankAccountCreation(bankAccounts[i], bankAccountsValuesAndTypes[i], i);

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
                    default: Console.WriteLine("Введите запрос корректно.");
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
            bankAccountNumber = 40000000,//Номер самого первого счета.

            balance = 0,

            bankAccountType = 0 // 1 Означает то, что это рублевый счет. 2 Бюджетный счет. 3 Валютный. 0 В данном случае это значение по умолчанию, которое должно будет измениться на предложенное.
        }

        public int BankAccountNumber = (int)BankAccountInfo.bankAccountNumber;

        public int Balance = (int)BankAccountInfo.balance;

        private int bankAccountType = (int)BankAccountInfo.bankAccountType;

        public int BankAccountType { get { return bankAccountType; } set { bankAccountType = value; } }
    }
}

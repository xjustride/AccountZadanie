# AccountZadanie

Tworzysz bibliotekę klas. Pracujesz w przestrzeni nazw Bank.

Dany jest interfejs IAccount określający wymagania dotyczące projektowanej przez Ciebie klasy Account.

using System;

namespace Bank
{
    public interface IAccount
    {
        // nazwa klienta, bez spacji przed i po
        // readonly - modyfikowalna wyłącznie w konstruktorze
        string Name {get;}

        // bilans, aktualny stan środków, podawany w zaokrągleniu do 2 miejsc po przecinku
        decimal Balance {get;}

        // czy konto jest zablokowane
        bool IsBlocked { get; }
        void Block();            // zablokowanie konta
        void Unblock();          // odblokowanie konta

        // wpłata, dla kwoty ujemnej - zignorowana (false)
        // jeśli konto zablokowane - zignorowana (false)
        // true jeśli wykonano i nastąpiła zmiana salda
        bool Deposit(decimal amount);

        // wypłata, dla kwoty ujemnej - zignorowana (false)
        // jeśli konto zablokowane - zignorowana (false)
        // jeśli jest niewystarczająca ilość środków - zignorowana (false)
        // true jeśli wykonano i nastąpiła zmiana salda   
        bool Withdrawal(decimal amount);
    }
}

Nie kopiuj interfejsu, jest on dołączany podczas kompilacji!

Utwórz klasę Account implementującą interfejs IAccount i spełniającą następujące wymagania:

Dane:

    Name - string, nazwa klienta, bez spacji przed i po, co najmniej 3 znaki, po utworzeniu obiektu nie może zostać zmodyfikowana, nawet wewnątrz klasy (read only)
    Balance - decimal, aktualny stan środków (saldo), nigdy nie może być ujemne, zapamiętane w zaokrągleniu do 4. cyfr po przecinku
    IsBlocked - bool, informacja, ze konto jest lub nie jest zablokowane

Zachowanie:

    Wszystkie operacje arytmetyczne wykonywane z dokładnością do 4. cyfr po przecinku
    Konstruktor tworzy obiekt na podstawie nazwy klienta (obligatoryjnie) i salda początkowego (opcjonalnie). Domyślnie, saldo początkowe wynosi 0. W przypadku podania ujemnego salda początkowego, zgłaszany jest wyjątek typu ArgumentOutOfRangeException. Nazwa konta musi mieć przynajmniej 3 znaki, w przeciwnym przypadku zgłaszany wyjątek ArgumentException. W momencie utworzenia konto jest odblokowane.
    Wpłatę można wykonać dla podanej kwoty (wartość nieujemna), o ile konto nie jest zablokowane. Jeśli saldo ulega zmianie, zwracana jest wartość true. Metoda Deposit nie zgłasza wyjątków.
    Wypłatę można wykonać dla podanej kwoty (wartość nieujemna), o ile konto nie jest zablokowane oraz na koncie jest wystarczająca ilość środków. Jeśli saldo ulega zmianie, zwracana jest wartość true. Metoda Withdrawal nie zgłasza wyjątków.
    Konto można zablokować jedynie metodą Block() lub odblokować jedynie metodą Unblock().

    Tekstową reprezentacją konta jest napis o formacie:
        jeśli konto nie jest zablokowane: Account name: {Name}, balance: {Balance}
        jeśli konto jest zablokowane: Account name: {Name}, balance: {Balance}, blocked

    Saldo podawane jest w zaokrągleniu do 2. miejsc po przecinku.

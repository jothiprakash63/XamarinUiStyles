using System;
using System.Collections.Generic;

namespace KantimeEvv.Services.Interfaces
{
    public interface IDatabaseService
    {
        List<Contact> GetContacts ();

        void UpdateContact (Contact contact);

        List<Quote> GetQuotes ();

        void UpdateQuote (Quote quote);
    }
}


using System;

namespace Autofixture.Tutorial
{
    public class ContactsService
    {
        private readonly IContactsRepository _repository;

        public ContactsService(IContactsRepository repository)
        {
            _repository = repository;
        }

        public Contact[] SearchContacts(string text)
        {
            if (text == null) throw new ArgumentNullException(nameof(text));

            return _repository.ListContaining(text);
        }
    }
}

using ContactDB;

namespace ContactRepository
{
    class DatabaseManager
    {
        private static readonly ContactsEntities entities;

        // Initialize and open the database connection
        static DatabaseManager()
        {
            entities = new ContactsEntities();
            entities.Database.Connection.Open();
        }

        // Provide an accessor to the database
        public static ContactsEntities Instance
        {
            get
            {
                return entities;
            }
        }
    }
}
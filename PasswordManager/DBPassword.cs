using System;

namespace PasswordManager
{
    [Serializable]
    public class DBPassword : DBLogApp
    {
        public string NameOf { get; set; }
        public DBPassword() { }
        public override string ToString()
        {
            return $"{NameOf}";
        }
    }
}

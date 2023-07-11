using System.Runtime.Serialization;

namespace JPVApiCrud.Repository
{
    [Serializable]
    internal class InputValidationException : Exception
    {
        public InputValidationException(string? message) : base(message)
        {
        }      
    }
}
namespace Application.Common.Models
{
    public class ValidationResult
    {
        public ValidationResult(bool isValid, string errorMessage)
        {
            IsValid = isValid;
            ErrorMessage = errorMessage;
        }

        public bool IsValid { get; set; }
        public string ErrorMessage { get; set; }

        public static ValidationResult Failed(string errorMessage)
        {
            return new ValidationResult(false, errorMessage);
        }

        public static ValidationResult Success()
        {
            return new ValidationResult(true, null);
        }
    }
}

namespace NLayer.Common.Helpers
{
    public static class ValidationExpressions
    {
        public const string TimeRegex = @"^([1-9]|1[0-2]|0[1-9]):[0-5][0-9] (am|pm|AM|PM)$";
        public const string PhoneRegex = @"^\+[1-9]\d{1,14}$";
        public const string CountryCityRegex = @"^[\p{L}0-9-\s'.,]+$";
        public const string LettersHyphensLanguageSpecificCharactersPeriodsSpacesRegex = @"^[\p{L}-.\s]+$";
        public const string LettersHyphensLanguageSpecificCharactersNumbersPeriodsRegex = @"^[\p{L}0-9-.]+$";
        public const string ExtendedListOfAllowedCharactersRegex = @"^[\p{L}0-9\s!""#$%&'()*+,-.\/:;<=>?@[\\\]^_`{|}~]+$";
    }
}

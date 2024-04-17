namespace CRMExam.Validation
{
    public class ValidationMessage
    {
        public const string REQUIRED = "Поле {0} является обязательным";
        public const string MAX_LENGTH = "Поле {0} не может быть больше {1}";
        public const string EMAIL = "Поле {0} должно содержать email адресс";
        public const string PHONE = "Поле {0} должно содержать номер телефона";
        public const string USER_ENUM = "Поле {0} может иметь только такие значения \"admin, marketing, saller\"";
        public const string CONTACT_ENUM = "Поле {0} может иметь только такие значения \"Cold, Warm, Lead\"";
        public const string LEAD_ENUM = "Поле {0} может иметь только такие значения \"New, Proposition, Negotitation, Contract, Lost\"";
    }
}

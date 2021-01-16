using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Base_C_Lesson_5
{
    internal class Account
    {
        public List<string> errors = new List<string>();

        public bool checkLogin(string login)
        {
            login = login.Trim();
            // Без регулярок
            if (login.Length < 2 || login.Length > 10) errors.Add("Длина логина не соответствует.");
            if(char.IsDigit(login[0])) errors.Add("Первый символ не должен быть цифрой.");
            for (int i = 0; i < login.Length; i++)
            {
                if (!(Char.IsDigit(login[i]) || login[i] >= 'a' && login[i] <= 'z' || login[i] >= 'A' && login[i] <= 'Z'))
                {
                    errors.Add("Используются недопустимые символы.");
                    break;
                }
            }

            // С регулярками
            var regex = new Regex("^[A-z]{1}[A-z0-9]{1,9}$");
            if (!regex.IsMatch(login)) errors.Add("[Regex]Используются недопустимые символы. ("+ login + ")");
            return (errors.Count > 0) ? false : true;
        }


    }
}
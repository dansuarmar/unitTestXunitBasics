using System;
using System.Collections.Generic;
using System.Text;

namespace ClaseExterna.StrongCoupling
{
    public static class ValidadorEmailHelper
    {
        public static bool EsValido(string email) 
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}

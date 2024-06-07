using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MextFullstackSaaS.Application.Common.Translations
{
    public class CommonTranslationKeys
    {
        // General Keys

        public static string GeneralValidationExceptionMessage => nameof(GeneralValidationExceptionMessage);
        public static string GeneralServerExceptionMessage => nameof(GeneralServerExceptionMessage);

        //userAuth Keys

        public static string UserAuthRegisterSuccededMessage =>nameof(UserAuthRegisterSuccededMessage);
        public static string UserAuthVerifySuccededMessage => nameof(UserAuthVerifySuccededMessage);
    }
}

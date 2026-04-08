using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Helpers
{
    public static class ConverterType
    {
        /// <summary>
        /// Конвертер строки с датой в обьект даты в формате дд.мм.гггг (с поддержкой пустоты или нулевого значения)
        /// </summary>
        /// <param name="date">Строка с датой для конвертации</param>
        /// <returns>Если строка пустая - null, если строка заполненна (датой) - DateTime</returns>
        public static DateTime? convertStringToData(string date)
        {
            if (!date.IsNullOrEmpty())
            {
                return DateTime.ParseExact(date, "dd.MM.yyyy", null);
            }
            else
            {
                return null;
            }
        }
    }
}

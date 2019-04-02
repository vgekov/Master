﻿namespace BankWebApplication.Extensions
{
    using Microsoft.AspNetCore.Mvc.ViewFeatures;

    using static WebConstants;

    public static class TempDataMessageExtensions
    {
        public static void AddSuccessMessage(this ITempDataDictionary tempData, string message)
        {
            tempData[TempDataSuccess] = message;
        }
        public static void AddErrorMessage(this ITempDataDictionary tempData, string message)
        {
            tempData[TempDateError] = message;
        }
    }
}

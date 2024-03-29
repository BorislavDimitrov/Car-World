﻿namespace CarWorld.Web.Infrastructure.Extensions
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Reflection;

    public static class EnumsDisplayExtension
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            string displayName;
            displayName = enumValue.GetType()
                .GetMember(enumValue.ToString())
                .FirstOrDefault()
                .GetCustomAttribute<DisplayAttribute>()?
                .GetName();
            if (String.IsNullOrEmpty(displayName))
            {
                displayName = enumValue.ToString();
            }
            return displayName;
        }
    }
}

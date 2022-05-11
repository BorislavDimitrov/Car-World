using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CarWorld.Web.Infrastructure.ValidationAttributes
{
    public class FileSizeAndFormatAttribute : ValidationAttribute
    {
        private readonly string[] DefaultAllowedFormats = { "pdf", "png", "jpg", "jpeg", "docx", "doc", "txt", "ppt", "html", "css", "pptx" };
        const int BiggestPossibleSize = 50;

        public int MaxAllowedSize { get; set; }

        public string[] AllowedFormats { get; set; }

        public FileSizeAndFormatAttribute(int maxAllowedSize = BiggestPossibleSize, params string[] allowedFormats)
        {
            this.MaxAllowedSize = maxAllowedSize;
            this.AllowedFormats = allowedFormats;
            ErrorMessage = $"The file must be with maximum size of {MaxAllowedSize} and be in of the {string.Join(", ", AllowedFormats)}";
        }

        public override bool IsValid(object? value)
        {
            if (value == null)
            {
                return true;
            }

            if (MaxAllowedSize >= BiggestPossibleSize)
            {
                MaxAllowedSize = BiggestPossibleSize;
            }

            if (AllowedFormats.Length == 0)
            {
                AllowedFormats = DefaultAllowedFormats;
            }

            MaxAllowedSize *= 1024 * 1024;

            if (value is IFormFile fileValue)
            {
                if (fileValue.Length <= MaxAllowedSize && AllowedFormats.Any(x => fileValue.FileName.EndsWith("." + x)))
                {
                    return true;
                }
            }

            return false;
        }
    }
}

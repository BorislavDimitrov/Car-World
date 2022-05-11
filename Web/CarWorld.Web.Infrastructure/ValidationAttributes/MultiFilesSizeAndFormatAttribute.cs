namespace CarWorld.Web.Infrastructure.ValidationAttributes
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using Microsoft.AspNetCore.Http;

    public class MultiFilesSizeAndFormatAttribute : ValidationAttribute
    {
        private readonly string[] DefaultAllowedFormats = { "pdf", "png", "jpg", "jpeg", "docx", "doc", "txt", "ppt", "html", "css", "pptx" };
        const int BiggestPossibleSize = 50;

        public int MaxAllowedSize { get; set; }

        public string[] AllowedFormats { get; set; }

        public int maxNumberOfFiles { get; set; }

        public MultiFilesSizeAndFormatAttribute(int maxNumberOfFiles = 0, int maxAllowedSize = BiggestPossibleSize, params string[] allowedFormats)
        {
            this.MaxAllowedSize = maxAllowedSize;
            this.AllowedFormats = allowedFormats;
            this.maxNumberOfFiles = maxNumberOfFiles;
            ErrorMessage = $"Max count of files:{maxNumberOfFiles}. Each file must be with maximum size of {MaxAllowedSize} and have one of the extensions: {string.Join(", ", AllowedFormats)}";
        }

        public override bool IsValid(object? value)
        {

            if (MaxAllowedSize >= BiggestPossibleSize)
            {
                MaxAllowedSize = BiggestPossibleSize;
            }

            if (AllowedFormats.Length == 0)
            {
                AllowedFormats = DefaultAllowedFormats;
            }

            MaxAllowedSize *= 1024 * 1024;

            if (value is IEnumerable<IFormFile> fileValues)
            {
                if (fileValues.Count() > 10)
                {
                    return false;
                }

                foreach (var file in fileValues)
                {
                    if (file.Length >= MaxAllowedSize || !AllowedFormats.Any(x => file.FileName.EndsWith("." + x)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}

using System.Collections.Generic;

namespace UserManagement.Shared.SharedDTOs
{
    public class ErrorDto
    {
        public List<string> Errors { get; set; } = new List<string>();

        public ErrorDto()
        {
            Errors = new List<string>();
        }

        public ErrorDto(string errorMessage)
        {
            Errors.Add(errorMessage);
        }

        public ErrorDto(List<string> errors)
        {
            Errors = errors;
        }
    }
}

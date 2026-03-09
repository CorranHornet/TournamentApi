using System;
using System.ComponentModel.DataAnnotations;

namespace TournamentApi.Dtos
{
    public class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if(value is DateTime date)
            {
                return date > DateTime.Now;
            }
            return false; // invalid if not a DateTime
        }
    }
}

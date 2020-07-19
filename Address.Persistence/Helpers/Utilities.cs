using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Address.Persistence.Helpers
{
    /// <summary>
    /// General utilities of the persistence project
    /// </summary>
    internal static class Utilities
    {
        /// <summary>
        /// Improves the exception message of a DbEntityValidationException.
        /// </summary>
        /// <param name="ex">DbEntityValidationException.</param>
        /// <returns></returns>
        //internal static string EFMessageException(DbEntityValidationException ex)
        //{
        //    //((System.Data.Entity.Validation.DbEntityValidationException)$exception).EntityValidationErrors
        //    // Retrieve the error messages as a list of strings.
        //    var errorMessages = ex.EntityValidationErrors
        //            .SelectMany(x => x.ValidationErrors)
        //            .Select(x => x.ErrorMessage);

        //    // Join the list to a single string.
        //    var fullErrorMessage = string.Join("; ", errorMessages);

        //    // Combine the original exception message with the new one.
        //    var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

        //    return exceptionMessage;
        //}
    }
}

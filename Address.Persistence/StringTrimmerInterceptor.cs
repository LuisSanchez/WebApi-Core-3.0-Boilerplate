using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Linq;

namespace Address.Persistence
{
    // DOESNT WORK PROPERLY IN CORE, WAS WORKING ON FRAMEWORK 4.7.2
    /// <summary>
    /// This class trims automatically every string property on the model
    /// </summary>
    public class StringTrimmerInterceptor : DbCommandInterceptor
    {
        //public void TreeCreated(DbCommandTreeInterceptionContext interceptionContext)
        //{
        //    if (interceptionContext.OriginalResult.DataSpace == DataSpace.SSpace)
        //    {
        //        var queryCommand = interceptionContext.Result as DbQueryCommandTree;
        //        if (queryCommand != null)
        //        {
        //            var newQuery = queryCommand.Query.Accept(new StringTrimmerQueryVisitor());
        //            interceptionContext.Result = new DbQueryCommandTree(
        //                queryCommand.MetadataWorkspace,
        //                queryCommand.DataSpace,
        //                newQuery);
        //        }
        //    }
        //}

        //private class StringTrimmerQueryVisitor : DefaultExpressionVisitor
        //{
        //    private static readonly string[] _typesToTrim = { "nvarchar", "varchar", "char", "nchar", "varchar2" };

        //    public override DbExpression Visit(DbNewInstanceExpression expression)
        //    {
        //        var arguments = expression.Arguments.Select(a =>
        //        {
        //            var propertyArg = a as DbPropertyExpression;
        //            if (propertyArg != null && _typesToTrim.Contains(propertyArg.Property.TypeUsage.EdmType.Name))
        //            {
        //                return EdmFunctions.Trim(a);
        //            }

        //            return a;
        //        });

        //        return DbExpressionBuilder.New(expression.ResultType, arguments);
        //    }
        //}
    }
}
﻿using System.Linq.Expressions;

namespace Domain.Core.Util;

public static class ExpressionExtension
{
        public static Expression<Func<T, bool>> Start<T> ()  { return f => true;  }
 
        public static Expression<Func<T, bool>> Or<T> (this Expression<Func<T, bool>> expr1,
            Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke (expr2, expr1.Parameters);
            return Expression.Lambda<Func<T, bool>>
                (Expression.OrElse (expr1.Body, invokedExpr), expr1.Parameters);
        }
 
        public static Expression<Func<T, bool>> And<T> (this Expression<Func<T, bool>> expr1,
            Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke (expr2, expr1.Parameters);
            return Expression.Lambda<Func<T, bool>>
                (Expression.AndAlso (expr1.Body, invokedExpr), expr1.Parameters);
        }
}
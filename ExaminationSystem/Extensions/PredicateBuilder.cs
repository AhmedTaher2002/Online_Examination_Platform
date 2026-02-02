using System;
using System.Linq.Expressions;

namespace ExaminationSystem.Extensions
{
    public static class PredicateBuilder
    {
        public static Expression<Func<T, bool>> True<T>() => _ => true;
        public static Expression<Func<T, bool>> False<T>() => _ => false;

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
        {
            var param = Expression.Parameter(typeof(T));
            var leftBody = ReplaceParameter(left.Body, left.Parameters[0], param);
            var rightBody = ReplaceParameter(right.Body, right.Parameters[0], param);
            return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(leftBody, rightBody), param);
        }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
        {
            var param = Expression.Parameter(typeof(T));
            var leftBody = ReplaceParameter(left.Body, left.Parameters[0], param);
            var rightBody = ReplaceParameter(right.Body, right.Parameters[0], param);
            return Expression.Lambda<Func<T, bool>>(Expression.OrElse(leftBody, rightBody), param);
        }

        public static Expression<Func<T, bool>> Not<T>(this Expression<Func<T, bool>> expr)
        {
            var param = expr.Parameters[0];
            return Expression.Lambda<Func<T, bool>>(Expression.Not(expr.Body), param);
        }

        private static Expression ReplaceParameter(Expression body, ParameterExpression from, ParameterExpression to)
            => new ParameterReplacer(from, to).Visit(body);

        private sealed class ParameterReplacer : ExpressionVisitor
        {
            private readonly ParameterExpression _from;
            private readonly ParameterExpression _to;

            public ParameterReplacer(ParameterExpression from, ParameterExpression to)
            {
                _from = from;
                _to = to;
            }

            protected override Expression VisitParameter(ParameterExpression node) =>
                node == _from ? _to : base.VisitParameter(node);
        }
    }
}
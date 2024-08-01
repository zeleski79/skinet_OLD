using System.Linq.Expressions;

namespace Core.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification() {
        }

        // Use the contructor to set our where clause criteria
        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        // Var Criteria ot type Expression that will contain our where clause expression
        public Expression<Func<T, bool>> Criteria {get;}

        // Var Includes of type List of Expressions that will contains our include expressions
        public List<Expression<Func<T, object>>> Includes {get;} = 
            new List<Expression<Func<T, object>>>();

        // Method to add include in the list of Includes
        protected void AddInclude(Expression<Func<T, object>> includeExpression) {
            Includes.Add(includeExpression);
        }
    }
}
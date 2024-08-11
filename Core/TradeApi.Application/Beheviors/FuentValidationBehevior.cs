using FluentValidation;
using MediatR;

namespace TradeApi.Application.Beheviors
{
    public class FuentValidationBehevior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> validator;

        public FuentValidationBehevior(IEnumerable<IValidator<TRequest>> validator)
        {
            this.validator = validator;
        }

        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);
            var failture = validator
                .Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .GroupBy(x => x.ErrorMessage)
                .Select(x => x.First())
                .Where(f => f != null)
                .ToList();

            if (failture.Any())            
                throw new ValidationException(failture);

            return next();
            
        }
    }
}

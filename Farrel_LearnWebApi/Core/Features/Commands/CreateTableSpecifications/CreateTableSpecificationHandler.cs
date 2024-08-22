using MediatR;
using Persistence.Models;
using Persistence.Repositories;

namespace Core.Features.Commands.CreateTableSpecification
{
    public class CreateTableSpecificationHandler : IRequestHandler<CreateTableSpecificationCommand, CreateTableSpecificationResponse>
    {
        private readonly ITableSpecificationRepository _tableSpecificationRepository;

        public CreateTableSpecificationHandler(ITableSpecificationRepository tableSpecificationRepository)
        {
            _tableSpecificationRepository = tableSpecificationRepository;
        }

        public async Task<CreateTableSpecificationResponse> Handle(CreateTableSpecificationCommand command, CancellationToken cancellationToken)
        {
            var newTableSpecification = new TableSpecification
            {
                TableId = Guid.NewGuid(),
                TableNumber = command.TableNumber,
                ChairNumber = command.ChairNumber,
                TablePic = command.TablePic,
                TableType = command.TableType
            };

            await _tableSpecificationRepository.AddAsync(newTableSpecification);

            return new CreateTableSpecificationResponse
            {
                TableId = newTableSpecification.TableId,
                Success = true,
                Message = "Table specification created successfully."
            };
        }
    }
}

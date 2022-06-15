using System;
using System.Collections.Generic;
using System.Text;

using CaprichoHexagonal.Core.Domain.Interfaces;

namespace CaprichoHexagonal.Core.Infraestructure.Repository.Abstract
{
    public interface IDetailRepository<Entity, TransactionId>: ICreate<Entity>, ITransaction
    {
        List<Entity> GetDetailsByTransaction(TransactionId transactionId);
        void Cancel(Guid entityId);
    }
}

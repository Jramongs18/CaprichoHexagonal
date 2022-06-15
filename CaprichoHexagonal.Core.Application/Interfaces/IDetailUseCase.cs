using System;
using System.Collections.Generic;
using System.Text;

using CaprichoHexagonal.Core.Domain.Interfaces;

namespace CaprichoHexagonal.Core.Application.Interfaces
{
    public interface IDetailUseCase<Entity, EntityId>:ICreate<Entity>
    {
        void Cancel(EntityId entityId);
    }
}

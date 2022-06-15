using System;
using System.Collections.Generic;
using System.Text;

using CaprichoHexagonal.Core.Domain.Interfaces;

namespace CaprichoHexagonal.Core.Application.Interfaces
{
    public interface IBaseUseCase<Entity, EntityId>: ICreate<Entity>,
        IRead<Entity,EntityId>, IUpdate<Entity>, IDelete<EntityId>
    {
    }
}

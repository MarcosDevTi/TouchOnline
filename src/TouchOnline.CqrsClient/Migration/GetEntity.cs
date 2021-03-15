using System;
using System.Collections.Generic;
using System.Text;
using TouchOnline.CqrsClient.Contracts;
using TouchOnline.Domain;

namespace TouchOnline.CqrsClient.Migration
{
    public class GetEntity<IEntityHandler> : IQuery<IEnumerable<IEntityHandler>>
    {
    }

    public class IEntityHandler: Entity
    {

    }

}

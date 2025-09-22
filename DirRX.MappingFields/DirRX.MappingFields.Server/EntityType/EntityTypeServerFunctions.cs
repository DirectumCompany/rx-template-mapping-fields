using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using DirRX.MappingFields.EntityType;

namespace DirRX.MappingFields.Server
{
  partial class EntityTypeFunctions
  {

    /// <summary>
    /// 
    /// </summary>       
    [Public, Remote(IsPure = true)]
    public static IQueryable<IEntityType> GetEntitiesType()
    {
      return EntityTypes.GetAll();
    }

  }
}
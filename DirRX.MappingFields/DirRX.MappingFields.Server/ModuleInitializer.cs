using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Sungero.Domain.Initialization;

namespace DirRX.MappingFields.Server
{
  public partial class ModuleInitializer
  {

    public override void Initializing(Sungero.Domain.ModuleInitializingEventArgs e)
    {
      CreateEntitiesType();
      CreateReportsTables();
    }
    
    public static void CreateEntitiesType()
    {
      var entitiesMetadata = PublicFunctions.Module.GetEntitiesMetadata();
      PublicFunctions.Module.CreateEntitiesType(entitiesMetadata);
    }
    
    /// <summary>
    /// Создать таблицы для отчетов.
    /// </summary>
    public static void CreateReportsTables()
    {
      var entityMappingReport = Constants.EntityMappingReport.SourceTableName;
      
      Sungero.Docflow.PublicFunctions.Module.DropReportTempTables(new[] {
                                                            entityMappingReport
                                                          });
      
      Sungero.Docflow.PublicFunctions.Module.ExecuteSQLCommandFormat(Queries.EntityMappingReport.CreateEntityMappingTable, new[] { entityMappingReport });

    }
  }
}

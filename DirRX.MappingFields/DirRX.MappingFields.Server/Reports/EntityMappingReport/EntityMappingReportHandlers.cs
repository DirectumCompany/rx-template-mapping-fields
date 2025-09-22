using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Sungero.Metadata;
using Sungero.Domain.Shared;

namespace DirRX.MappingFields
{
  partial class EntityMappingReportServerHandlers
  {

    public override void AfterExecute(Sungero.Reporting.Server.AfterExecuteEventArgs e)
    {
      Sungero.Docflow.PublicFunctions.Module.DeleteReportData(Constants.EntityMappingReport.SourceTableName, EntityMappingReport.ReportSessionId);
    }

    public override void BeforeExecute(Sungero.Reporting.Server.BeforeExecuteEventArgs e)
    {
      EntityMappingReport.ReportSessionId = Guid.NewGuid().ToString();
      var guidsSelected = EntityMappingReport.EntitiesType.Select(c => Guid.Parse(c.Guid));
      
      var entities = PublicFunctions.Module.GetEntitiesMetadata().Where(c => guidsSelected.Contains(c.NameGuid));
      var tableData = new List<MappingFields.Structures.Module.ITableData>();
      
      foreach (var entity in entities)
      {
        var propertiesInfo = MappingFields.PublicFunctions.Module.GetPropertiesType(entity.NameGuid.ToString(), string.Empty);
        
        int i = 0;
        
        foreach (var propertyInfo in propertiesInfo)
        {
          var data = MappingFields.Structures.Module.TableData.Create();
          data.NameEntity = entity.GetDisplayName();
          data.ItemId = i++;
          data.NameProperty = propertyInfo.IsRequired ? string.Format("*{0}", propertyInfo.Name) : propertyInfo.Name;
          data.LocalizedName = propertyInfo.IsRequired ? string.Format("*{0}", propertyInfo.LocalizedName) : propertyInfo.LocalizedName;
          data.PropertyGuid = propertyInfo.PropertyGuid;
          data.Type = PublicFunctions.Module.CastTypeEntityToLocalizeName(propertyInfo.Type, propertyInfo.PropertyGuid, false);
          data.MaxStringLength = propertyInfo.MaxStringLength == null ? string.Empty : propertyInfo.MaxStringLength.ToString();
          data.TypeJson = PublicFunctions.Module.CastTypeEntityToLocalizeName(propertyInfo.Type, propertyInfo.PropertyGuid, true);
          
          // тут дозаполнение типа данных для перечисления
          if (propertyInfo.EnumCollection.Any())
          {
            data.Type = string.Format("{0}:\n {1}", data.Type, string.Join(Environment.NewLine,  propertyInfo.EnumCollection.Select(c => string.Format("  • «{0}»", c.LocalizedName)).ToList()));
            data.TypeJson = string.Format("{0}:\n {1}", data.TypeJson, string.Join(Environment.NewLine,  propertyInfo.EnumCollection.Select(c => string.Format("  • «{0}»", c.Name)).ToList()));
          }
          
          data.ReportSessionId = EntityMappingReport.ReportSessionId;
          tableData.Add(data);
        }
      }
      
      Sungero.Docflow.PublicFunctions.Module.WriteStructuresToTable(Constants.EntityMappingReport.SourceTableName, tableData);
    }

  }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;

namespace DirRX.MappingFields
{
  partial class EntityMappingReportClientHandlers
  {

    public override void BeforeExecute(Sungero.Reporting.Client.BeforeExecuteEventArgs e)
    {
      var dialog = Dialogs.CreateInputDialog("Выберите типы сущностей для формирования маппинга полей");

      var entityTypeSelect = dialog.AddMultilineString("Тип сущности", true).WithRowsCount(4);
      entityTypeSelect.IsEnabled = false;
      
      var hyperlinkEmployeesSelect = dialog.AddHyperlink("Выбрать");
      
      var selectedEntityType = new List<IEntityType>();
      hyperlinkEmployeesSelect.SetOnExecute(
        () =>
        {
          selectedEntityType = PublicFunctions.EntityType.Remote.GetEntitiesType().ShowSelectMany().ToList();
          entityTypeSelect.Value = string.Join("; ", selectedEntityType.Select(s => s.Name));
        });
      
      if (dialog.Show() == DialogButtons.Ok)
        EntityMappingReport.EntitiesType.AddRange(selectedEntityType);
      else
        e.Cancel = true;
    }

  }
}
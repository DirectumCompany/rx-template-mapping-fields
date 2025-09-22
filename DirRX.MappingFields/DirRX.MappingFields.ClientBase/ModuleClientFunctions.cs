using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;

namespace DirRX.MappingFields.Client
{
  public class ModuleFunctions
  {

    /// <summary>
    /// Диалог для выбора типов сущностей.
    /// </summary>
    [Public]
    public System.Collections.Generic.IEnumerable<MappingFields.IEntityType> ShowSelectTypeEntityDialog()
    {
      var dialog = Dialogs.CreateInputDialog("Выберите типы сущностей для формирования маппинга полей");
      var selectEntityType = dialog.AddSelectMany("Тип сущности", true, MappingFields.EntityTypes.Null);

      if (dialog.Show() == DialogButtons.Ok)
      {
        return selectEntityType.Value;
      }
      
      return null;
    }

  }
}
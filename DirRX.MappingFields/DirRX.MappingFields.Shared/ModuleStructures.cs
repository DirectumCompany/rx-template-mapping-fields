using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;

namespace DirRX.MappingFields.Structures.Module
{
  /// <summary>
  /// Модель таблицы.
  /// </summary>
  partial class TableData
  {
    /// <summary>
    /// Наименование сущности.
    /// </summary>
    public string ReportSessionId { get; set; }
    
    /// <summary>
    /// Номер элемента.
    /// </summary>
    public int ItemId { get; set; }
    
    /// <summary>
    /// Наименование сущности.
    /// </summary>
    public string NameEntity { get; set; }
    
    /// <summary>
    /// Наименование свойства.
    /// </summary>
    public string NameProperty { get; set; }
    
    /// <summary>
    /// Локализованное наименование свойства.
    /// </summary>
    public string LocalizedName { get; set; }
    
    /// <summary>
    /// Тип данных в json.
    /// </summary>
    public string TypeJson { get; set; }
    
    /// <summary>
    /// Тип свойства.
    /// </summary>
    public string Type { get; set; }
    
    /// <summary>
    /// Guid ссылочного свойства.
    /// </summary>
    public string PropertyGuid { get; set; }
    
    /// <summary>
    /// Значения свойства перечисления.
    /// </summary>
    public string EnumCollection { get; set; }
    
    /// <summary>
    /// Максимальная длина текстового поля.
    /// </summary>
    public string MaxStringLength { get; set; }
  }
  
  /// <summary>
  /// Информация о коллекциях.
  /// </summary>
  partial class CollectionInfo
  {
    /// <summary>
    /// Наименование.
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Локализованное наименование.
    /// </summary>
    public string LocalizedName { get; set; }
    
    /// <summary>
    /// Информация о свойствах.
    /// </summary>
    public List<DirRX.MappingFields.Structures.Module.IPropertyInfo> Properties { get; set; }
  }

  /// <summary>
  /// Информация о свойствах.
  /// </summary>
  [Public]
  partial class PropertyInfo
  {
    /// <summary>
    /// Наименование свойства.
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Локализованное наименование свойства.
    /// </summary>
    public string LocalizedName { get; set; }
    
    /// <summary>
    /// Тип данных.
    /// </summary>
    public string Type { get; set; }
    
    /// <summary>
    /// Guid ссылочного свойства.
    /// </summary>
    public string PropertyGuid { get; set; }
    
    /// <summary>
    /// Признак обязательности свойства.
    /// </summary>
    public bool IsRequired { get; set; }
    
    /// <summary>
    /// Значения свойства перечислении.
    /// </summary>
    public List<DirRX.MappingFields.Structures.Module.IEnumerationInfo> EnumCollection { get; set; }
    
    /// <summary>
    /// Максимальная длина текстового поля.
    /// </summary>
    public int? MaxStringLength { get; set; }
  }
  
  /// <summary>
  /// Информация о перечислениях.
  /// </summary>
  [Public]
  partial class EnumerationInfo
  {
    /// <summary>
    /// Наименование.
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Локализованное наименование.
    /// </summary>
    public string LocalizedName { get; set; }
  }
}
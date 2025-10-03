using System;
using Sungero.Core;

namespace DirRX.MappingFields.Constants
{
  public static class Module
  {
    /// <summary>
    /// Обобщенное наименование типов.
    /// </summary>
    public static class CustomType
    {
      /// <summary>
      /// Дата.
      /// </summary>
      public const string Date = "Date";
      
      /// <summary>
      /// Логический тип данных.
      /// </summary>
      public const string Bool = "Bool";
      
      /// <summary>
      /// Числовой тип данных.
      /// </summary>
      public const string Numeric = "Numeric";
      
      /// <summary>
      /// Строковый тип данных.
      /// </summary>
      public const string String = "String";
      
      /// <summary>
      /// Перечисление.
      /// </summary>
      public const string Enumeration = "Enumeration";
      
      /// <summary>
      /// Бинарные данные.
      /// </summary>
      public const string BinaryData = "BinaryData";
      
      /// <summary>
      /// Вещественное.
      /// </summary>
      public const string Double = "Double";
      
      /// <summary>
      /// Картинка.
      /// </summary>
      public const string Image = "Image";

      /// <summary>
      /// Перечисление.
      /// </summary>
      public const string Collection = "Collection";
      
      /// <summary>
      /// Ссылочный тип данных.
      /// </summary>
      public const string Navigation = "Navigation";
    }
    
    /// <summary>
    /// Обобщенное наименование типов.
    /// </summary>
    public static class CustomTypeLocalize
    {
      /// <summary>
      /// Дата.
      /// </summary>
      public const string Date = "Дата";
      
      /// <summary>
      /// Логический тип данных.
      /// </summary>
      public const string Bool = "Логическое";
      
      /// <summary>
      /// Числовой тип данных.
      /// </summary>
      public const string Numeric = "Целое число";
      
      /// <summary>
      /// Строковый тип данных.
      /// </summary>
      public const string String = "Строка";
      
      /// <summary>
      /// Перечисление.
      /// </summary>
      public const string Enumeration = "Перечисление";
      
      /// <summary>
      /// Перечисление.
      /// </summary>
      public const string Collection = "Коллекция";
      
      /// <summary>
      /// Бинарные данные.
      /// </summary>
      public const string BinaryData = "Бинарные данные";
      
      /// <summary>
      /// Вещественное.
      /// </summary>
      public const string Double = "Вещественное";
      
      /// <summary>
      /// Картинка.
      /// </summary>
      public const string Image = "Картинка";
    }
    
    /// <summary>
    /// Guid сущность Документ.
    /// </summary>
    [Public]
    public const string DocumentGUID = "030d8d67-9b94-4f0d-bcc6-691016eb70f3";
    
    /// <summary>
    /// Guid сущности Справочник.
    /// </summary>
    [Public]
    public const string DatabookGUID = "04581d26-0780-4cfd-b3cd-c2cafc5798b0";
    
    /// <summary>
    /// Guid сущности Задача.
    /// </summary>
    [Public]
    public const string TaskGUID = "d795d1f6-45c1-4e5e-9677-b53fb7280c7e";
    
    /// <summary>
    /// Guid сущности.
    /// </summary>
    [Public]
    public const string EntityGUID = "79aaa247-5f24-47a3-bf05-f0cd7ad30161";
    
    /// <summary>
    /// Guid уведомления.
    /// </summary>
    [Public]
    public const string NoticeGUID = "ef79164b-2ce7-451b-9ba6-eb59dd9a4a74";
    
    /// <summary>
    /// Guid задания.
    /// </summary>
    [Public]
    public const string AssignmentGUID = "91cbfdc8-5d5d-465e-95a4-3235b8c01d5b";
    
  }
}
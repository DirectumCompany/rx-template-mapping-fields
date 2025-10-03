using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Sungero.Domain.Shared;
using Sungero.Metadata;

namespace DirRX.MappingFields.Server
{
  public class ModuleFunctions
  {
    /// <summary>
    /// Преобразование типа данных в локализованное значение.
    /// </summary>
    /// <param name="type">Тип данных.</param>
    /// <param name="guid">Guid типа сущности.</param>
    /// <param name="isJson">Локализация для json.</param>
    /// <returns>Локализованный тип данных.</returns>
    [Public]
    public string CastTypeEntityToLocalizeName(string type, string guid, bool isJson)
    {
      var customType = GetMatchingTypeToCustomType(type);
      
      if (customType == Constants.Module.CustomType.String)
        return Constants.Module.CustomTypeLocalize.String;
      if (customType == Constants.Module.CustomType.Bool)
        return Constants.Module.CustomTypeLocalize.Bool;
      if (customType == Constants.Module.CustomType.Date)
        return Constants.Module.CustomTypeLocalize.Date;
      if (customType == Constants.Module.CustomType.Numeric)
        return Constants.Module.CustomTypeLocalize.Numeric;
      if (customType == Constants.Module.CustomType.Enumeration)
        return Constants.Module.CustomTypeLocalize.Enumeration;
      if (customType == Constants.Module.CustomType.BinaryData)
        return Constants.Module.CustomTypeLocalize.BinaryData;
      if (customType == Constants.Module.CustomType.Double)
        return Constants.Module.CustomTypeLocalize.Double;
      if (customType == Constants.Module.CustomType.Image)
        return Constants.Module.CustomTypeLocalize.Image;
      if (customType == Constants.Module.CustomType.Collection)
        return Constants.Module.CustomTypeLocalize.Collection;
      if (customType == Constants.Module.CustomType.Navigation)
        return FindBaseEntityName(guid, isJson);
      
      return string.Empty;
    }
    
    /// <summary>
    /// Поиск базового типа сущности.
    /// </summary>
    /// <param name="guid">Guid сущности.</param>
    /// <returns>Guid базового типа сущности.</returns>
    public string FindBaseEntityName(string guid)
    {
      var guidSearch = guid;
      var typeStr = string.Empty;
      var needFind = true;
      
      while (needFind)
      {
        var entity = Sungero.Metadata.Services.MetadataSearcher.FindEntityMetadata(Guid.Parse(guidSearch));

        if (entity != null)
        {
          if (entity.BaseGuid == Guid.Parse(PublicConstants.Module.DatabookGUID))
            typeStr = PublicConstants.Module.DatabookGUID;
          else if (entity.BaseGuid == Guid.Parse(PublicConstants.Module.DocumentGUID))
            typeStr = PublicConstants.Module.DocumentGUID;
          else if (entity.BaseGuid == Guid.Parse(PublicConstants.Module.TaskGUID))
            typeStr = PublicConstants.Module.TaskGUID;
          // В перекрытиях у справочников родительский гуид почему то считается от Entity, а не от DatabookEntry.
          else if (entity.BaseGuid == Guid.Parse(PublicConstants.Module.EntityGUID))
            typeStr = PublicConstants.Module.DatabookGUID;
          
          if (!string.IsNullOrEmpty(typeStr))
            needFind = false;
          
          guidSearch = entity.BaseGuid.ToString();
          
          if (guidSearch == null)
            needFind = false;
        }
        else
          needFind = false;
      }
      
      return typeStr;
    }
    
    /// <summary>
    /// Поиск базового типа сущности.
    /// </summary>
    /// <param name="guid">Guid сущности.</param>
    /// <param name="isJson">Локализация для json.</param>
    /// <returns>Guid базового типа сущности.</returns>
    public string FindBaseEntityName(string guid, bool isJson)
    {
      var guidSearch = guid;
      var typeStr = string.Empty;
      var needFind = true;
      var nameEntity = Sungero.Metadata.Services.MetadataSearcher.FindEntityMetadata(Guid.Parse(guidSearch)).GetDisplayName();
      
      while (needFind)
      {
        var entity = Sungero.Metadata.Services.MetadataSearcher.FindEntityMetadata(Guid.Parse(guidSearch));
        
        if (entity != null)
        {
          if (entity.BaseGuid == Guid.Parse(PublicConstants.Module.DatabookGUID))
            typeStr = isJson ? string.Format("Идентификатор (целое число) записи справочника <b>{0}</b>", nameEntity) : string.Format("Справочник <b>{0}</b>", nameEntity);
          if (entity.BaseGuid == Guid.Parse(PublicConstants.Module.DocumentGUID))
            typeStr = isJson ? string.Format("Идентифкатор (целое число) документа <b>{0}</b>", nameEntity) : string.Format("Документ <b>{0}</b>", nameEntity);
          if (entity.BaseGuid == Guid.Parse(PublicConstants.Module.TaskGUID))
            typeStr = isJson ? string.Format("Идентификатор (целое число) задачи <b>{0}</b>", nameEntity) : string.Format("Задача <b>{0}</b>", nameEntity);
          
          if (!string.IsNullOrEmpty(typeStr))
            needFind = false;
          
          guidSearch = entity.BaseGuid.ToString();
          
          if (guidSearch == null)
            needFind = false;
        }
        else
          needFind = false;
      }
      
      return typeStr;
    }
    
    /// <summary>
    /// Получить обобщенный тип по типу свойства.
    /// </summary>
    /// <param name="type">Наименование типа свойства.</param>
    /// <returns>Обобщенное наименование типа.</returns>
    public static string GetMatchingTypeToCustomType(string type)
    {
      var dict = new Dictionary<string, string>()
      {
        { Sungero.Metadata.PropertyType.Data.ToString(), Constants.Module.CustomType.Date },
        { Sungero.Metadata.PropertyType.DateTime.ToString(), Constants.Module.CustomType.Date },
        { Sungero.Metadata.PropertyType.Boolean.ToString(), Constants.Module.CustomType.Bool },
        { Sungero.Metadata.PropertyType.Integer.ToString(), Constants.Module.CustomType.Numeric },
        { Sungero.Metadata.PropertyType.LongInteger.ToString(), Constants.Module.CustomType.Numeric },
        { Sungero.Metadata.PropertyType.String.ToString(), Constants.Module.CustomType.String },
        { Sungero.Metadata.PropertyType.Text.ToString(), Constants.Module.CustomType.String },
        { Sungero.Metadata.PropertyType.BinaryData.ToString(), Constants.Module.CustomType.BinaryData },
        { Sungero.Metadata.PropertyType.Double.ToString(), Constants.Module.CustomType.Double },
        { Sungero.Metadata.PropertyType.Image.ToString(), Constants.Module.CustomType.Image },
        { Sungero.Metadata.PropertyType.Enumeration.ToString(), Constants.Module.CustomType.Enumeration },
        { Sungero.Metadata.PropertyType.Collection.ToString(), Constants.Module.CustomType.Collection },
        { Sungero.Metadata.PropertyType.Navigation.ToString(), Constants.Module.CustomType.Navigation }
      };
      
      var customType = string.Empty;
      dict.TryGetValue(type, out customType);
      return customType;
    }
    
    /// <summary>
    /// Создание записей в справочнике Типы сущностей
    /// </summary>
    /// <param name="entityMetadata">Список метаданных сущностей.</param>
    public void CreateEntitiesType(List<Sungero.Metadata.EntityMetadata> entityMetadata)
    {
      foreach (var metadata in entityMetadata)
      {
        var entityType = EntityTypes.GetAll(e => e.Guid == metadata.NameGuid.ToString()).FirstOrDefault();
        
        if (entityType == null)
          entityType = EntityTypes.Create();
        
        var baseGuid = FindBaseEntityName(metadata.BaseGuid.ToString());
        
        if (baseGuid == PublicConstants.Module.DatabookGUID)
          entityType.Type = MappingFields.EntityType.Type.DatabookEntry;
        else if (baseGuid == PublicConstants.Module.DocumentGUID)
          entityType.Type = MappingFields.EntityType.Type.Document;
        
        entityType.Name = metadata.GetDisplayName();
        entityType.NameDevelopment = metadata.Name;
        entityType.Guid = metadata.NameGuid.ToString();
        entityType.IsAbstract = metadata.IsAbstract;
        
        entityType.Save();
      }
    }
    
    /// <summary>
    /// Получить метаданные всех наследников от Справочника и Документа.
    /// </summary>
    /// <returns>Список метаданных наследников.</returns>
    [Public]
    public List<Sungero.Metadata.EntityMetadata> GetEntitiesMetadata()
    {
      var baseEntityes = new List<string>()
      {
        {PublicConstants.Module.DatabookGUID},
        {PublicConstants.Module.DocumentGUID}
      };
      
      var entitiesMetadata = new List<Sungero.Metadata.EntityMetadata>();
      
      foreach (var baseEntity in baseEntityes)
      {
        var baseEntityMetadata = Sungero.Metadata.Services.MetadataSearcher.FindEntityMetadata(Guid.Parse(baseEntity));
        
        var childEntities = Sungero.Metadata.EntityMetadata.GetDescendants(baseEntityMetadata)
          .Cast<Sungero.Metadata.EntityMetadata>()
          .Where(c => c.CanCreateInstance == true && c.IsLayerMetadata == false)
          .ToList();
        var abstractEntities = Sungero.Metadata.EntityMetadata.GetDescendants(baseEntityMetadata)
          .Cast<Sungero.Metadata.EntityMetadata>()
          .Where(c => c.IsAbstract == true && c.InterfaceType.Namespace != "Sungero.CoreEntities" && c.IsLayerMetadata == false)
          .ToList();
        
        entitiesMetadata.AddRange(childEntities);
        entitiesMetadata.AddRange(abstractEntities);
      }
      
      return entitiesMetadata;
    }
    
    #region Методы приведения к типу.
    
    /// <summary>
    /// Приведение объекта к типу StringPropertyMetadata.
    /// </summary>
    /// <param name="castEntity">Объект для приведения.</param>
    /// <returns>Объект с типом StringPropertyMetadata, либо null при ошибке во время приведения к типу.</returns>
    public static Sungero.Metadata.StringPropertyMetadata CastToStringPropertyMetadata(object castEntity)
    {
      StringPropertyMetadata val = null;
      
      if (castEntity == null)
        return val;
      
      try
      {
        val = (StringPropertyMetadata)castEntity;
      }
      catch (Exception ex)
      {
        Logger.Error("Error", ex);
      }
      
      return val;
    }
    
    /// <summary>
    /// Приведение объекта к типу EnumPropertyMetadata.
    /// </summary>
    /// <param name="castEntity">Объект для приведения.</param>
    /// <returns>Объект с типом EnumPropertyMetadata, либо null при ошибке во время приведения к типу.</returns>
    public static Sungero.Metadata.EnumPropertyMetadata CastToEnumPropertyMetadata(object castEntity)
    {
      EnumPropertyMetadata val = null;
      
      if (castEntity == null)
        return val;
      
      try
      {
        val = (EnumPropertyMetadata)castEntity;
      }
      catch (Exception ex)
      {
        Logger.Error("Error", ex);
      }
      
      return val;
    }
    
    /// <summary>
    /// Приведение объекта к типу EnumPropertyInfo.
    /// </summary>
    /// <param name="castEntity">Объект для приведения.</param>
    /// <returns>Объект с типом EnumPropertyInfo, либо null при ошибке во время приведения к типу.</returns>
    public static Sungero.Domain.Shared.EnumPropertyInfo CastToEnumPropertyInfo(object castEntity)
    {
      EnumPropertyInfo val = null;
      
      if (castEntity == null)
        return val;
      
      try
      {
        val = (EnumPropertyInfo)castEntity;
      }
      catch (Exception ex)
      {
        Logger.Error("Error", ex);
      }
      
      return val;
    }
    
    /// <summary>
    /// Приведение объекта к типу NavigationPropertyMetadata.
    /// </summary>
    /// <param name="castEntity">Объект для приведения.</param>
    /// <returns>Объект с типом NavigationPropertyMetadata, либо null при ошибке во время приведения к типу.</returns>
    public static Sungero.Metadata.NavigationPropertyMetadata CastToNavigationPropertyMetadata(object castEntity)
    {
      NavigationPropertyMetadata val = null;
      
      if (castEntity == null)
        return val;
      
      try
      {
        val = (NavigationPropertyMetadata)castEntity;
      }
      catch (Exception ex)
      {
        Logger.Error("Error", ex);
      }
      
      return val;
    }
    
    #endregion
    
    /// <summary>
    /// Создать сущность по Guid типа.
    /// </summary>
    /// <param name="typeGuid">Guid типа сущности.</param>
    /// <returns>Сущность.</returns>
    [Remote(PackResultEntityEagerly = true)]
    public virtual IEntity CreateEntityByTypeGuid(string typeGuid)
    {
      var entityType = Sungero.Domain.Shared.TypeExtension.GetTypeByGuid(Guid.Parse(typeGuid));
      using (var session = new Sungero.Domain.Session())
      {
        return session.Create(entityType);
      }
    }
    
    /// <summary>
    /// Получить список дополнительных реквизитов сущности Учетная запись, которые не доступны для выбора.
    /// </summary>
    /// <returns>Список реквизитов.</returns>
    public virtual List<string> GetAdditionalExcludePropForLogins()
    {
      return new List<string> {
        "NeedChangePassword",
        "TypeAuthentication",
        "PasswordLastChangeDate",
        "LockoutEndDate"
      };
    }
    
    /// <summary>
    /// Сравнить объект с типом.
    /// </summary>
    /// <param name="comparedObject">Объект для сравнения.</param>
    /// <param name="comparedType">Тип для сравнения.</param>
    /// <returns>True - если тип объекта совпадает с входным типом, иначе false.</returns>
    public static bool CompareObjectWithType(object comparedObject, System.Type comparedType)
    {
      if (comparedObject == null)
        return false;
      
      var objectType = comparedObject.GetType();
      return Equals(objectType, comparedType);
    }
    
    /// <summary>
    /// Получить список с информацией о реквизитах типа сущности.
    /// </summary>
    /// <param name="guid">Guid типа сущности.</param>
    /// <param name="collectionName">Наименование коллекции.</param>
    /// <returns>Список с информацией о реквизитах типа сущности.</returns>
    [Public]
    public virtual List<DirRX.MappingFields.Structures.Module.IPropertyInfo> GetPropertiesType(string guid, string collectionName)
    {
      var propertiesList = new List<Structures.Module.IPropertyInfo>();
      
      var typeGuid = Guid.Parse(guid);
      var type = TypeExtension.GetTypeByGuid(typeGuid);
      if (type == null)
        return propertiesList;
      
      var typeMetadata = type.GetFinalType().GetEntityMetadata();
      
      var properties = Enumerable.Empty<Sungero.Metadata.PropertyMetadata>();
      var excludeProperties = Functions.Module.GetExcludeProperties();
      var excludePropertyTypes = Functions.Module.GetExcludePropertyTypes();
      if (string.IsNullOrEmpty(collectionName))
      {
        properties = typeMetadata.Properties.Where(m => !excludeProperties.Contains(m.Name))
          .Where(m => !excludePropertyTypes.Contains(m.PropertyType));
      }
      else
      {
        properties = typeMetadata.Properties.Where(m => m.Name == collectionName)
          .Cast<Sungero.Metadata.CollectionPropertyMetadata>()
          .FirstOrDefault()
          .InterfaceMetadata
          .Properties
          .Where(m => !excludeProperties.Contains(m.Name))
          .Where(m => !excludePropertyTypes.Contains(m.PropertyType))
          .Where(m => !Functions.Module.CompareObjectWithType(m, typeof(Sungero.Metadata.NavigationPropertyMetadata)) ||
                 !Functions.Module.CastToNavigationPropertyMetadata(m).IsReferenceToRootEntity);
      }
      
      var isAnyEnum = properties.Any(m => Functions.Module.CompareObjectWithType(m, typeof(Sungero.Metadata.EnumPropertyMetadata)));
      IEntity entity = null;
      if (isAnyEnum)
      {
        AccessRights.AllowRead(() => {
                                 if (!typeMetadata.IsAbstract)
                                   entity = CreateEntityByTypeGuid(typeMetadata.NameGuid.ToString());
                               });
      }
      
      foreach (var propertyMetadata in properties)
      {
        #region Получение локализованных значений перечислений
        
        var enumInfo = new List<Structures.Module.IEnumerationInfo>();
        if (isAnyEnum && Functions.Module.CompareObjectWithType(propertyMetadata, typeof(Sungero.Metadata.EnumPropertyMetadata)))
        {
          var enumPropertyMetadata = propertyMetadata as Sungero.Metadata.EnumPropertyMetadata;

          if (enumPropertyMetadata != null)
          {
            foreach (var val in enumPropertyMetadata?.Values)
              enumInfo.Add(DirRX.MappingFields.Structures.Module.EnumerationInfo.Create(val.Name, Sungero.Domain.Shared.EnumLocalization.GetLocalizedValue(val) ?? string.Empty));
          }
        }
        
        #endregion
        
        var entityGuid = string.Empty;
        if (Functions.Module.CompareObjectWithType(propertyMetadata, typeof(Sungero.Metadata.NavigationPropertyMetadata)))
          entityGuid = Functions.Module.CastToNavigationPropertyMetadata(propertyMetadata)?.EntityGuid.ToString() ?? string.Empty;
        
        int? strLength = null;
        if (Functions.Module.CompareObjectWithType(propertyMetadata, typeof(Sungero.Metadata.StringPropertyMetadata)))
          strLength = Functions.Module.CastToStringPropertyMetadata(propertyMetadata)?.Length;
        
        propertiesList.Add(Structures.Module.PropertyInfo.Create(propertyMetadata.Name,
                                                                 propertyMetadata.GetLocalizedName().ToString(),
                                                                 propertyMetadata.PropertyType.ToString(),
                                                                 entityGuid,
                                                                 propertyMetadata.IsRequired,
                                                                 enumInfo,
                                                                 strLength));
      }
      
      if (entity != null)
      {
        using (var session = new Sungero.Domain.Session())
        {
          session.Delete(entity);
        }
      }
      
      return propertiesList;
    }
    
    /// <summary>
    /// Получить список свойст, которые не доступны для выбора.
    /// </summary>
    /// <returns>Список свойст.</returns>
    public virtual List<string> GetExcludeProperties()
    {
      return new List<string> {
        "SID",
        "Sid",
        "TypeDiscriminator",
        "Params",
        "NeedWriteHistory",
        "DisplayValue",
        "IsPropertyChangedHandlerEnabled",
        "SecureObject",
        "InternalAccessRights",
        "IsTransient",
        "RootEntity",
        "PersonalPhotoHash",
        "PersonalPhotoHash",
        "IsCardReadOnly",
        "Parameters"
      };
    }
    
    /// <summary>
    /// Получить список типов, которые не доступны для выбора.
    /// </summary>
    /// <returns>Список типов.</returns>
    public virtual List<object> GetExcludePropertyTypes()
    {
      return new List<object> {
        Sungero.Metadata.PropertyType.Component,
      };
    }
  }
}
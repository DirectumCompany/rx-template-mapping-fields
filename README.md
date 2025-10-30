# Отчет. Маппинг полей прикладной разработки
Репозиторий с решением "Отчет. Маппинг полей прикладной разработки".
> [!NOTE]
> Замечания и пожеланию по развитию шаблона разработки фиксируйте через [Issues](https://github.com/DirectumCompany/rx-template-mapping-fields/issues).
При оформлении ошибки, опишите сценарий для воспроизведения. Для пожеланий приведите обоснование для описываемых изменений - частоту использования, бизнес-ценность, риски и/или эффект от реализации.
> 
> Внимание! Изменения будут вноситься только в новые версии.

## Описание
Решение позволяет сформировать отчет с маппингом полей из любой сущности в прикладной разработке.

Работа с отчетом происходит из модуля "Маппинг полей". По действию "Маппинг полей".

После нажатия на действие открывается диалог с выбором сущностей по которым необходимо сгенерировать отчет с маппингом полей. 

<img width="524" height="269" alt="image" src="https://github.com/user-attachments/assets/a5050e73-d13f-44e8-8b54-6ab1bf7c04fa" />

Выбрав сущность и выполнив диалог будет сгенерирован отчет. Пример на скриншоте ниже:
<img width="951" height="626" alt="image" src="https://github.com/user-attachments/assets/a8c95500-2973-4dca-b083-e772332ddcd3" />

В состав решения входит:
1. Модуль "Маппинг полей".
2. Справочник "Типы сущностей".
3. Отчет "Маппинг полей".

## Порядок установки
Для работы требуется установленный Directum RX версии 25.1 и выше.

## Установка для ознакомления
1. Склонировать репозиторий с rx-template-mapping-fields в папку.
2. Указать в _ConfigSettings.xml DDS:
```xml
<block name="REPOSITORIES">
  <repository folderName="Base" solutionType="Base" url="" /> 
  <repository folderName="<Папка из п.1>" solutionType="Work" 
     url="https://github.com/DirectumCompany/rx-template-mapping-fields" />
</block>
```

## Установка для использования
Возможные варианты

**A. Fork репозитория**
1. Сделать fork репозитория rx-template-mapping-fields для своей учетной записи.
2. Склонировать созданный в п. 1 репозиторий в папку.
3. Указать в _ConfigSettings.xml DDS:
```xml
<block name="REPOSITORIES">
  <repository folderName="Base" solutionType="Base" url="" /> 
  <repository folderName="<Папка из п.2>" solutionType="Work" 
     url="https://github.com/DirectumCompany/rx-template-mapping-fields" />
</block>
```

**B. Подключение на базовый слой.**
1. Склонировать репозиторий rx-template-approval-from-registry в папку.
2. Указать в _ConfigSettings.xml DDS:
```xml
<block name="REPOSITORIES">
  <repository folderName="Base" solutionType="Base" url="" /> 
  <repository folderName="<Папка из п.1>" solutionType="Base" 
     url="<Адрес репозитория gitHub>" />
  <repository folderName="<Папка для рабочего слоя>" solutionType="Work" 
     url="<Адрес репозитория для рабочего слоя>" />
</block>
```

**C. Копирование репозитория в систему контроля версий.**
Рекомендуемый вариант для проектов внедрения.
1. В системе контроля версий с поддержкой git создать новый репозиторий.
2. Склонировать репозиторий <Название репозитория> в папку с ключом `--mirror`.
3. Перейти в папку из п. 2.
4. Импортировать клонированный репозиторий в систему контроля версий командой:
`git push –mirror <Адрес репозитория из п. 1>`

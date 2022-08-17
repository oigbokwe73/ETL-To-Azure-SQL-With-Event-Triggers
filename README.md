## Architecture Diagram

![image](https://user-images.githubusercontent.com/15838780/149241508-67d1d0af-9aea-47e3-abc2-335e891fafdc.png)


## Appplication Setting 

|Key|Value | Comment|
|:----|:----|:----|
|AzureWebJobsStorage|[CONNECTION STRING]|RECOMMENDATION :  store in AzureKey Vault.|
|FilePath| d:\home\site\wwwroot\Config\ |
|ApiKeyName|[API KEY NAME]|Will be passed in the header  :  the file name of the config.
|AppName| [APPLICATION NAME]| This is the name of the Function App. Used in log analytics|
|StorageAcctName|[STORAGE ACCOUNT NAME]|Example  "AzureWebJobsStorage"|
|ConnectionString|[CONNECTION_STRING NAME]|Example  "ConnectionString"|



## How to install  ACI for SFTP ##

https://docs.microsoft.com/en-us/samples/azure-samples/sftp-creation-template/sftp-on-azure

## Function App  Configuration 


|FileName|Description|
|:----|:----|
|3FB620B0E0FD4E8F93C9E4D839D00E1C.json| Upload CSV File. Create Batched Files. Return Status Check|
|43EFE991E8614CFB9EDECF1B0FDED37A.json| Upload CSV File into NoSql Table Store Database.|
|3FB620B0E0FD4E8F93C9E4D839D00E1D.json| Upload Batched files into SQL Database|



## Upload CSV File

|Key|Value|Comments|
|:----|:----|:----|
|ReadCsvAsStream|Yes| Required to parse the csv file while uploading|
|messageformat|application/json OR application/xml| required|
|FolderName||OPTIONAL:This is required for additonal XSL transformation |
|FileName||OPTIONAL:This is required for additonal XSL transformation |
|TableName|<AZURE TABLE NAME>| REQUIRED Create table add records|
|StorageAccount|<STORAGE ACCOUNT KEY>| Name of the  storage account key in AppSettings.|



  
  
  ## Products

|products|links|Comments|
|:----|:----|:----|
|Azure Getting Started |https://azure.microsoft.com/en-us/free/| Create free account + $200 in Credit|
|Azure Storage Explorer|https://azure.microsoft.com/en-us/features/storage-explorer/#features|useful view and query data in azure table storage|
|Postman|https://www.postman.com/downloads/|Postman supports the Web or Desktop Version|
|VsCode| https://visualstudio.microsoft.com/downloads/ |  Required extensions. Azure Functions, Azure Account
|VS Studio Community Edition |https://visualstudio.microsoft.com/downloads/| Recommended. Nice intergration with Azure. software is free.

  
  ## Contact
  
For questions related to this project, can be reached via email :- support@xenhey.com

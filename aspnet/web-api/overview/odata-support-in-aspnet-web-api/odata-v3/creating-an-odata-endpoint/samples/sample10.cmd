HTTP/1.1 200 OK
Cache-Control: no-cache
Pragma: no-cache
Content-Type: application/xml; charset=utf-8
Expires: -1
Server: Microsoft-IIS/8.0
DataServiceVersion: 3.0
Date: Mon, 23 Sep 2013 23:05:52 GMT
Content-Length: 1086

<?xml version="1.0" encoding="utf-8"?>
<edmx:Edmx Version="1.0" xmlns:edmx="http://schemas.microsoft.com/ado/2007/06/edmx">
  <edmx:DataServices m:DataServiceVersion="3.0" m:MaxDataServiceVersion="3.0" 
    xmlns:m="http://schemas.microsoft.com/ado/2007/08/dataservices/metadata">
    <Schema Namespace="ProductService.Models" xmlns="http://schemas.microsoft.com/ado/2009/11/edm">
      <EntityType Name="Product">
        <Key>
          <PropertyRef Name="ID" />
        </Key>
        <Property Name="ID" Type="Edm.Int32" Nullable="false" />
        <Property Name="Name" Type="Edm.String" />
        <Property Name="Price" Type="Edm.Decimal" Nullable="false" />
        <Property Name="Category" Type="Edm.String" />
      </EntityType>
    </Schema>
    <Schema Namespace="Default" xmlns="http://schemas.microsoft.com/ado/2009/11/edm">
      <EntityContainer Name="Container" m:IsDefaultEntityContainer="true">
        <EntitySet Name="Products" EntityType="ProductService.Models.Product" />
      </EntityContainer>
    </Schema>
  </edmx:DataServices>
</edmx:Edmx>
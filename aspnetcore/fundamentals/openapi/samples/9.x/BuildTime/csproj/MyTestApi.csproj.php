<!-- 
    This file is needed to contain snippets and provides a convenient
    location to copy/paste the <PropertyGroup> into the .csproj file.
    The dash dash sequence is an illegal string in an XML comment and
    results in the error: An XML comment cannot contain --.
    
    That's why this is stored as an HTML file.
 -->

<!-- <snippet_file_name> -->
<PropertyGroup>
    <OpenApiGenerateDocumentsOptions>--file-name my-open-api</OpenApiGenerateDocumentsOptions>
</PropertyGroup>
<!-- </snippet_file_name> -->

<!--<snippet_1>-->
<PropertyGroup>
    <OpenApiDocumentsDirectory>.</OpenApiDocumentsDirectory>
</PropertyGroup>
<!--</snippet_1>-->
<!--<snippet2>-->
<PropertyGroup>
    <OpenApiDocumentsDirectory>../MyOpenApiDocs</OpenApiDocumentsDirectory>
</PropertyGroup>
<!--</snippet2>-->

<!--<snippet_doc_name>-->
<PropertyGroup>
    <OpenApiGenerateDocumentsOptions>--document-name v2</OpenApiGenerateDocumentsOptions>
</PropertyGroup>
<!--</snippet_doc_name>-->

<!-- <snippet_all> -->
<PropertyGroup>
    <OpenApiDocumentsDirectory>.</OpenApiDocumentsDirectory>
    <OpenApiGenerateDocumentsOptions>--file-name my-open-api</OpenApiGenerateDocumentsOptions>
    <OpenApiGenerateDocumentsOptions>--document-name v2</OpenApiGenerateDocumentsOptions>
</PropertyGroup>
<!-- </snippet_all> -->

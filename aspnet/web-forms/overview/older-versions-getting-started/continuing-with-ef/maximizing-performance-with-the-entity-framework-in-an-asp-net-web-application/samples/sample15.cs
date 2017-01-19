<#
/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.

THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

***************************************************************************/
#>

<#
    //
    // TITLE: T4 template to generate views for an EDMX file in a C# project
    //
    // DESCRIPTION:
    // This is a T4 template to generate views in C# for an EDMX file in C# projects.
    // The generated views are automatically compiled into the project's output assembly.
    //
    // This template follows a simple file naming convention to determine the EDMX file to process:
    // - It assumes that [edmx-file-name].Views.tt will process and generate views for [edmx-file-name].EDMX
    // - The views are generated in the code behind file [edmx-file-name].Views.cs
    //
    // USAGE:
    // Do the following to generate views for an EDMX file (e.g. Model1.edmx) in a C# project
    // 1. In Solution Explorer, right-click the project node and choose "Add...Existing...Item" from the context menu
    // 2. Browse to and choose this .tt file to include it in the project 
    // 3. Ensure this .tt file is in the same directory as the EDMX file to process 
    // 4. In Solution Explorer, rename this .tt file to the form [edmx-file-name].Views.tt (e.g. Model1.Views.tt)
    // 5. In Solution Explorer, right-click Model1.Views.tt and choose "Run Custom Tool" to generate the views
    // 6. The views are generated in the code behind file Model1.Views.cs
    //
    // TIPS:
    // If you have multiple EDMX files in your project then make as many copies of this .tt file and rename appropriately
    // to pair each with each EDMX file.
    //
    // To generate views for all EDMX files in the solution, click the "Transform All Templates" button in the Solution Explorer toolbar
    // (its the rightmost button in the toolbar) 
    //
#>
<#
    //
    // T4 template code follows
    //
#>
<#@ template language="C#" hostspecific="true"#>
<#@ include file="EF.Utility.CS.ttinclude"#>
<#@ output extension=".cs" #>
<# 
    // Find EDMX file to process: Model1.Views.tt generates views for Model1.EDMX
    string edmxFileName = Path.GetFileNameWithoutExtension(this.Host.TemplateFile).ToLowerInvariant().Replace(".views", "") + ".edmx";
    string edmxFilePath = Path.Combine(Path.GetDirectoryName(this.Host.TemplateFile), edmxFileName);
    if (File.Exists(edmxFilePath))
    {
        // Call helper class to generate pre-compiled views and write to output
        this.WriteLine(GenerateViews(edmxFilePath));
    }
    else
    {
        this.Error(String.Format("No views were generated. Cannot find file {0}. Ensure the project has an EDMX file and the file name of the .tt file is of the form [edmx-file-name].Views.tt", edmxFilePath));
    }
    
    // All done!
#>

<#+
    private String GenerateViews(string edmxFilePath)
    {
        MetadataLoader loader = new MetadataLoader(this);
        MetadataWorkspace workspace;
        if(!loader.TryLoadAllMetadata(edmxFilePath, out workspace))
        {
            this.Error("Error in the metadata");
            return String.Empty;
        }
            
        String generatedViews = String.Empty;
        try
        {
            using (StreamWriter writer = new StreamWriter(new MemoryStream()))
            {
                StorageMappingItemCollection mappingItems = (StorageMappingItemCollection)workspace.GetItemCollection(DataSpace.CSSpace);

                // Initialize the view generator to generate views in C#
                EntityViewGenerator viewGenerator = new EntityViewGenerator();
                viewGenerator.LanguageOption = LanguageOption.GenerateCSharpCode;
                IList<EdmSchemaError> errors = viewGenerator.GenerateViews(mappingItems, writer);

                foreach (EdmSchemaError e in errors)
                {
                    // log error
                    this.Error(e.Message);
                }

                MemoryStream memStream = writer.BaseStream as MemoryStream;
                generatedViews = Encoding.UTF8.GetString(memStream.ToArray());
            }
        }
        catch (Exception ex)
        {
            // log error
            this.Error(ex.ToString());
        }

        return generatedViews;
    }
#>
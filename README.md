# MigrationSupport
Tooling to support migrating an ASP.NET Web Forms-based application to .NET with CoreForms

## DesignerAttributeRewriter
Console application which will remove the System.ComponentModel.DesignerAttribute from a list of assemblies.
Use this tool to help with libraries that contain strong-typed references to Designer-types on their web controls.

Usage:
1. Check out the repository and compile the project. You can quickly review the code to ensure it is safe.
2. Convert the control library by passing the source folder and the destination folder on the command line:
   `DesignerAttributeRewriter.exe inputDirectory outputDirectory`


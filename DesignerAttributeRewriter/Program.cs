// Copyright (c) 2023 RUBICON IT GmbH, www.rubicon.eu
// SPDX-License-Identifier: MIT

using dnlib.DotNet;

internal class Program
{
  public static void Main (string[] args)
  {
    if (args.Length != 2)
    {
      Console.WriteLine ("Usage: DesignerAttributeRewriter.exe inputDirectory outputDirectory");
      return;
    }

    var inputDirectory = args[0];
    var outputDirectory = args[1];

    if (!Directory.Exists (inputDirectory))
    {
      Console.WriteLine($"The input directory '{inputDirectory}' does not exist.");
      return;
    }

    if (!Directory.Exists (outputDirectory))
      Directory.CreateDirectory (outputDirectory);

    foreach (var assemblyPath in Directory.EnumerateFiles (inputDirectory, "*.dll"))
    {
      var moduleDefMd = ModuleDefMD.Load (assemblyPath);

      var moduleDef = moduleDefMd.Assembly.Modules.Single();
      foreach (var typeDef in moduleDef.Types)
      {
        typeDef.CustomAttributes.RemoveAll ("System.ComponentModel.DesignerAttribute");
      }

      var filename = Path.Combine (outputDirectory, Path.GetFileName (assemblyPath));
      if (File.Exists (filename))
        File.Delete (filename);

      moduleDefMd.Write (filename);
    }
  }
}
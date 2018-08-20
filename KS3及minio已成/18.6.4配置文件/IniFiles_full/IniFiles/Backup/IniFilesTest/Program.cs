using System;
using System.Collections.Generic;
using Gajatko.IniFiles;

namespace IniFilesTest
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		static void Main()
		{
			// Watch files in this project: 
			//		Sources: "test.txt", "win.ini"
			//		Results: "bin\..\test1.txt", "bin\..\mail.txt", "new.ini", "light.txt"

			//   After first run of demo, try uncomment these and compare result with the previous output:

			////If you uncomment this, you will get traditional-looking INI files
			//IniFileSettings.PreserveFormatting = false;
			////If you uncomment these, you will get a custom formatted files
			//IniFileSettings.QuoteChar = '\"';
			//IniFileSettings.DefaultSectionFormatting = "[ $ ]   ;";
			//IniFileSettings.DefaultValueFormatting = " ? = $           ;";
			//IniFileSettings.CommentChars = new string[] { "//", ";" };
			////Uncomment both of above will force the custom formatting.
			
			#region USER MODE ("test.txt" -> "test1.txt")
			
			// Here are listed a few possible operations
			// Read the comments, see the effects :) (in the "test1.txt" file)
			IniFile file = IniFile.FromFile("test.txt");
			// Adds a new section
			file["New section"]["KEYE"] = "geage";
			// Adds new values to an existing section
			file["First"]["NewOne"] = "aaa";
			file["First"]["NewTwo"] = "bbb";
			file["First"]["NewThree"] = "ccc";
			// Sets an existing value
			file["First"]["Number"] = "666";
			// Overrides a comment of a section
			file["Another"].Comment = @"Override multiline comment of 'Another'" 
				+ (IniFileSettings.PreserveFormatting ? Environment.NewLine + 
				"Spaces surrounding section name are preserved." : "");
			// Rename secion
			file["Another"].Name = "Section Another was renamed";
			// Adds a comment of value "KEYE".
			file["New section"].SetComment("KEYE", "Comment for a newly created key");
			// Adds an inline comment of value "KEYE".
			file["New section"].SetInlineComment("KEYE", "Inline comment for a newly created key");
			// Comment at the end of file
			file.Foot = "As you see, it is cool.";
			// Header
			if (IniFileSettings.PreserveFormatting)
				file.Header += Environment.NewLine + Environment.NewLine + @"Preserving format feature is ON.
Note that new values in [First] section look the same as
the one which already existed.";
			else
				file.Header += Environment.NewLine + Environment.NewLine + @"Preserving format feature is OFF.";

			// Save file to the disc
			file.Save("test1.txt");
			//U can comment this out and add "file" to watches for more reflection.
			//file = IniFile.FromFile("test1.txt");
			#endregion

			#region HARDCORE MODE ("win.ini" -> "mail.ini")			
			IniFileReader reader = new IniFileReader("win.ini");
			// Extract "Mail" section to another file.
			IniFileSectionStart sss;
			sss = reader.GotoSection("Mail");
			List<IniFileElement> sectionElements = reader.ReadSection();
			reader.Close();
			// Create an IniFile
			IniFile mailSection = IniFile.FromElements(sectionElements);
			mailSection.Header = "This is an extracted 'Mail' section";
			mailSection.Save("mail.ini");

			//Rusty alternative:
			//IniFileWriter writer = new IniFileWriter("mail.ini");
			//writer.WriteElement(IniFileCommentary.FromComment("This is an extracted \"Mail\" section"));
			//writer.WriteElement(new IniFileBlankLine(1));
			//writer.WriteElements(sectionElements);
			//writer.Close();
			#endregion

			#region SAMPLE FROM THE ARTICLE ("new.ini")
			// SAMPLE FROM THE ARTICLE ("new.ini")
			file = new IniFile();
			// Adds a new section
			file["LastUser"]["Name"] = "Gajatko";
			// Add comments
			file["LastUser"].Comment =
@"This section contains information about user
which logged in at previous program run";
			file["LastUser"].SetComment("Name", "Name of user");
			// Rename sections and keys
			file["LastUser"].Name = "RecentUser";
			file["RecentUser"].RenameKey("Name", "Login");
			// Get names of all section:
			string[] sections = file.GetSectionNames();
			// Set existing values:
			file["RecentUser"]["Login"] = "Chuck";
			// Override existing comment:
			file["RecentUser"].Comment = "New Comment";
			// Save to disc
            file.Save("new.ini");
			#endregion

			#region LIGHT MODE ("light.txt")
			Gajatko.IniFiles.Light.IniFileLight light = new Gajatko.IniFiles.Light.IniFileLight();
			// Set data
			light.Sections.Add("Data", new Dictionary<string, string>());
			light.Sections["Data"].Add("Name", "Mickey");
			light.Sections["Data"].Add("Surname", "Mouse");
			// Value comment
			light.Comments.Add("Data.Surname", "This is a surname");
			// Section comment
			light.Comments.Add("Data", "This is a section");
			// Footer
			light.Comments.Add("", "Footer");
			// Save INI
			light.Save("light.txt");
			// Read it back for testing
			light = new Gajatko.IniFiles.Light.IniFileLight("light.txt");
			string commentOfSurname = light.Comments["Data.Surname"];
			string commentOfSection = light.Comments["Data"];
			#endregion
			
			// ... that's it!

			Console.WriteLine(
@"Watch these files in this project: 
Sources: 'test.txt', 'win.ini'
Results: 'bin\..\test1.txt', 'bin\..\mail.txt', 'new.ini', 'light.txt'");
			Console.ReadLine();
		}
	}
}
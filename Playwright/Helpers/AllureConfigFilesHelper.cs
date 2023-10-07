﻿namespace Playwright.Helpers
{
    public class AllureConfigFilesHelper
    {
        private static string CreateBatFile()
        {
            string path = OperatingSystem.IsWindows()
            ? Browser.RootPath() + "allure serve.bat" //Path for OS Windows
            : (OperatingSystem.IsMacOS() || OperatingSystem.IsLinux()
                ? Browser.RootPath() + "allure serve.sh" //Path for OS Linux or MacOS
                : throw new PlatformNotSupportedException("Unsupported operating system."));

            string allureResultsDirectory = Browser.RootPath() + @"allure-results";
            string allureResults = string.Concat("echo off\r\n",
                                                 @"allure serve ", allureResultsDirectory,
                                                 "\r\npause");
            FileInfo fileInf = new(path);
            if (fileInf.Exists)
            {
                fileInf.Delete();
            }
            else if (!Directory.Exists(allureResultsDirectory))
            {
                Directory.CreateDirectory(allureResultsDirectory);
            }
            using (StreamWriter writer = new(path, false, Encoding.UTF8))
            {
                writer.Write(allureResults);
            }
            return path;
        }

        private static void DeleteBatFile()
        {
            string path = String.Empty;
            if (OperatingSystem.IsWindows())
            {
                path = Browser.RootPath() + "allure serve.bat";
            }
            else if (OperatingSystem.IsMacOS() || OperatingSystem.IsLinux())
            {
                path = Browser.RootPath() + "allure serve.sh";
            }
            FileInfo fileInf = new(path);
            if (fileInf.Exists)
            {
                fileInf.Delete();
            }
        }

        public static void OpenAllureReport()
        {
            Process process = new Process();
            process.StartInfo.FileName = CreateBatFile();
            process.Start();
            process.Close();
            Thread.Sleep(1000);
            DeleteBatFile();
        }

        public static async Task CreateJsonConfigFile()
        {
            await Task.Delay(250);
            ConfigJson json = new()
            {
                Allure = new()
                {
                    Directory = Path.Combine(Browser.RootPath() + "allure-results"),
                    Links = new()
                    {
                        "{link}",
                        "https://testrail.com/browse/{tms}",
                        "https://jira.com/browse/{issue}"
                    }
                },
                Specflow = new()
                {
                    StepArguments = new()
                    {
                        ConvertToParameters = true,
                        ParamNameRegex = "",
                        ParamValueRegex = ""
                    },
                    Grouping = new()
                    {
                        Suites = new()
                        {
                            ParentSuite = "^parentSuite:?(.+)",
                            Suite = "^suite:?(.+)",
                            SubSuite = "^subSuite:?(.+)"
                        },
                        Behaviors = new()
                        {
                            Epic = "^epic:?(.+)",
                            Story = "^story:(.+)"
                        }
                    },
                    Labels = new()
                    {
                        Owner = "^author:?(.+)",
                        Severity = "^(normal|blocker|critical|minor|trivial)"
                    },
                    Links = new()
                    {
                        Tms = "^story:(.+)",
                        Issue = "^issue:(.+)",
                        Link = "^link:(.+)"
                    }
                }
            };

            var path = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory));
            FileInfo fileInf = new(path + "allureConfig.json");
            if (fileInf.Exists == true)
            {
                fileInf.Delete();
            }
            string mainpath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory)) + "allureConfig.json";

            using StreamWriter file = System.IO.File.CreateText(mainpath);
            JsonSerializer serializer = new();
            serializer.Serialize(file, json);
        }
    }
}

namespace CONFIG_JSON
{
    public partial class ConfigJson
    {
        [JsonProperty("allure")]
        public Allure Allure { get; set; }

        [JsonProperty("specflow")]
        public Specflow Specflow { get; set; }
    }

    public partial class Allure
    {
        [JsonProperty("directory")]
        public string? Directory { get; set; }

        [JsonProperty("links")]
        public List<string> Links { get; set; }
    }

    public partial class Specflow
    {
        [JsonProperty("stepArguments")]
        public StepArguments StepArguments { get; set; }

        [JsonProperty("grouping")]
        public Grouping Grouping { get; set; }

        [JsonProperty("labels")]
        public Labels Labels { get; set; }

        [JsonProperty("links")]
        public Links Links { get; set; }
    }

    public partial class Grouping
    {
        [JsonProperty("suites")]
        public Suites Suites { get; set; }

        [JsonProperty("behaviors")]
        public Behaviors Behaviors { get; set; }
    }

    public partial class Behaviors
    {
        [JsonProperty("epic")]
        public string? Epic { get; set; }

        [JsonProperty("story")]
        public string? Story { get; set; }
    }

    public partial class Suites
    {
        [JsonProperty("parentSuite")]
        public string? ParentSuite { get; set; }

        [JsonProperty("suite")]
        public string? Suite { get; set; }

        [JsonProperty("subSuite")]
        public string? SubSuite { get; set; }
    }

    public partial class Labels
    {
        [JsonProperty("owner")]
        public string? Owner { get; set; }

        [JsonProperty("severity")]
        public string? Severity { get; set; }
    }

    public partial class Links
    {
        [JsonProperty("tms")]
        public string? Tms { get; set; }

        [JsonProperty("issue")]
        public string? Issue { get; set; }

        [JsonProperty("link")]
        public string? Link { get; set; }
    }

    public partial class StepArguments
    {
        [JsonProperty("convertToParameters")]
        public bool ConvertToParameters { get; set; }

        [JsonProperty("paramNameRegex")]
        public string? ParamNameRegex { get; set; }

        [JsonProperty("paramValueRegex")]
        public string? ParamValueRegex { get; set; }
    }
}

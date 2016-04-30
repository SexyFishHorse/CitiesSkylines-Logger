# CitiesSkylines-Logger
A friendly logger for Cities Skylines. Also allows for writing the log to a file.

# Nuget package
This project is available as a nuget package. Add the appropriate feed to your Nuget package source list ([how to](https://docs.nuget.org/consume/package-manager-dialog))
* Visual Studio 2015+: https://www.myget.org/F/sexyfishhorse-citiesskylines/api/v3/index.json
* Visual Studio 2012+: https://www.myget.org/F/sexyfishhorse-citiesskylines/api/v2

# Usage

1. Add the using `using SexyFishHorse.CitiesSkylines.Logger`
2. Create the logger `var logger = new Logger("mod_folder_name", "log_file_name.xml", clearLog: false);`
  - `mod_folder_name` is the name of your mods folder in `%LOCALAPPDATA%\Colossal Order\Cities_Skylines\Addons\Mods`
  - `log_file_name.xml` is the name of the log file, it will be stored in the `mod_folder_name` folder
3. Use the loggger `logger.Log("Hello world");`

**Note:** You can have multiple loggers at work at the same time for various log files, but you should only have one logger per log file otherwise you may run into concurrency issues.

## Configuration

The logger contains some configuration possibilities available as properties on the Logger class.

Property|default|Description
--------|-------|-----------
`LogToFile` | `false` | Indicates if messages should be written to the log file
`LogToOutputPanel` | `false` | Indicates if messages should be written to the in-game output panel.<br/>**Note:** Errors are always written to the debug panel

# RamBase IO Extension

This project was generated by the RamBase IO Extension template. It contains a set of test data files than can be altered to match the data your IOX will receive.

The files `Input.txt`, `IoxData.txt`, `Output.txt` and `Result.txt` from the TestData folder will automatically be copied to the output folder when building with Debug configuration.

You should send these files in as arguments to the IOX when testing: `dotnet run MyProjectName.dll Result.txt IoxData.txt Input.txt Output.txt`.